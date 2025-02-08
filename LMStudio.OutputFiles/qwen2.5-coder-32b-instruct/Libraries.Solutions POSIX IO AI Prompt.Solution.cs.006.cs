var fileSystem = new InMemoryFileSystem();
int fd = fileSystem.Open("test.txt", FileModeEnum.Write);
byte[] dataToWrite = System.Text.Encoding.UTF8.GetBytes("Hello, World!");
int bytesWritten = fileSystem.Write(fd, dataToWrite, dataToWrite.Length);