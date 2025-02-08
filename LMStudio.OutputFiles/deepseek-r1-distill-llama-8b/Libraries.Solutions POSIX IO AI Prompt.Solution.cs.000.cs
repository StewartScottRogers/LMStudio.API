using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InMemoryPosixIO
{
    public abstract class Device : IDisposable
    {
        protected Device(string name, bool isBlocking)
        {
            Name = name;
            IsBlocking = isBlocking;
            ReadBuffer = new byte[4096];
        }

        ~Device()
        {
            Close();
        }

        public void Dispose()
        {
            Close();
        }

        public string Name { get; }
        public bool IsBlocking { get; set; }
        public byte[] ReadBuffer { get; set; }

        public abstract Task<int> ReadAsync(int offset, int length, out int bytesRead);
        public abstract Task<int> WriteAsync(byte[] buffer, int offset, int length, out int written);

        public virtual void Close()
        {
            throw new IOException("Device closed");
        }
    }

    public class FileDescriptor : Device
    {
        private readonly Stream _stream;

        public FileDescriptor(string name) : base(name, false)
        {
            _stream = new MemoryStream();
        }

        public override async Task<int> ReadAsync(int offset, int length, out int bytesRead)
        {
            try
            {
                var data = await _stream.ReadAsync((int?)length);
                if (data == 0 && length != 0)
                    throw new IOException("End of stream reached");
                return data;
            }
            catch (Exception e)
            {
                if (e is IOException)
                    throw new IOException($"Read error: {e.Message}");
                else
                    throw new IOException("Unexpected error during read", e);
            }
        }

        public override async Task<int> WriteAsync(byte[] buffer, int offset, int length, out int written)
        {
            try
            {
                var bytesWritten = await _stream.WriteAsync(buffer, (int?)length);
                written = bytesWritten;
                return bytesWritten;
            }
            catch (Exception e)
            {
                if (e is IOException)
                    throw new IOException($"Write error: {e.Message}");
                else
                    throw new IOException("Unexpected error during write", e);
            }
        }

        public override void Close()
        {
            _stream.Dispose();
            base.Close();
        }
    }

    public class Pipe : Device
    {
        private FileDescriptor _readDescriptor;
        private FileDescriptor _writeDescriptor;
        private ReaderWriterLock _synchronizer;

        public Pipe(string name) : base(name, true)
        {
            _readDescriptor = new FileDescriptor("Pipe Read");
            _writeDescriptor = new FileDescriptor("Pipe Write");
            _synchronizer = new ReaderWriterLock();
        }

        public override async Task<int> ReadAsync(int offset, int length, out int bytesRead)
        {
            try
            {
                _synchronizer.AcquireReaderLock();
                return await _readDescriptor.ReadAsync(offset, length, out bytesRead);
            }
            catch (Exception e)
            {
                if (e is IOException)
                    throw new IOException($"Pipe read error: {e.Message}");
                else
                    throw new IOException("Unexpected pipe error", e);
            }
            finally
            {
                _synchronizer.ReleaseReaderLock();
            }
        }

        public override async Task<int> WriteAsync(byte[] buffer, int offset, int length, out int written)
        {
            try
            {
                _synchronizer.AcquireWriterLock();
                return await _writeDescriptor.WriteAsync(buffer, offset, length, out written);
            }
            catch (Exception e)
            {
                if (e is IOException)
                    throw new IOException($"Pipe write error: {e.Message}");
                else
                    throw new IOException("Unexpected pipe error", e);
            }
            finally
            {
                _synchronizer.ReleaseWriterLock();
            }
        }

        public override void Close()
        {
            _readDescriptor.Close();
            _writeDescriptor.Close();
            base.Close();
        }
    }

    public enum ErrorCodes : int
    {
        Success = 0,
        EOF = 1,
        PermissionDenied = 2,
        FileNotFound = 3,
        PipeDisconnected = 4,
    }

    [TestClass]
    public class PosixIoTests
    {
        private readonly FileDescriptor _stdIn;
        private readonly FileDescriptor _stdOut;
        private readonly Pipe _pipe;

        public PosixIoTests()
        {
            _stdIn = new FileDescriptor("stdin");
            _stdOut = new FileDescriptor("stdout");
            _pipe = new Pipe("test_pipe");
        }

        [TestMethod]
        public async Task ReadFromPipe()
        {
            var readBuffer = new byte[1024];
            int bytesRead;
            for (int i = 0; i < 2; i++)
            {
                await _pipe.ReadAsync(0, 1024, out bytesRead);
                Assert.AreEqual(1024, bytesRead);
            }
        }

        [TestMethod]
        public async Task WriteToPipe()
        {
            var writeBuffer = new byte[1024];
            int written;
            for (int i = 0; i < 2; i++)
            {
                writeBuffer.FillBytes(i);
                await _pipe.WriteAsync(writeBuffer, 0, 1024, out written);
                Assert.AreEqual(1024, written);
            }
        }

        [TestMethod]
        public async Task ReadFromStdIn()
        {
            var buffer = new byte[16];
            int bytesRead;
            await _stdIn.ReadAsync(0, 16, out bytesRead);
            Assert.AreEqual(16, bytesRead);
        }

        [TestMethod]
        public void PipeConnectionTest()
        {
            var reader = new FileDescriptor("pipe_reader");
            var writer = new FileDescriptor("pipe_writer");
            pipe.Connect(reader, writer);

            try
            {
                reader.ReadAsync(0, 1024, out _);
                Assert.Fail("Pipe connection failed to read");
            }
            finally
            {
                pipe.Close();
                writer.Close();
                reader.Close();
            }
        }

        [TestMethod]
        public async Task LseekTest()
        {
            var file = new FileDescriptor("test_file");
            await file.ReadAsync(0, 4096, out _);
            await file.Lseek(100);
            await file.ReadAsync(100, 1024, out _);
            Assert.Pass();
        }
    }
}