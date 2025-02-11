using System;

namespace PosixFileSystemLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the PosixFileSystem class
            var fileSystem = new PosixFileSystem();

            // Open a file with a given name and mode
            int fileDescriptor = fileSystem.Open("example.txt", FileMode.Create);

            // Write data to the file
            string dataToWrite = "Hello, World!";
            fileSystem.Write(fileDescriptor, Encoding.UTF8.GetBytes(dataToWrite));

            // Seek to a specific position in the file
            fileSystem.Seek(fileDescriptor, 0, SeekOrigin.Begin);

            // Read data from the file
            byte[] buffer = new byte[12];
            int bytesRead = fileSystem.Read(fileDescriptor, buffer);
            string readData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Read Data: " + readData);

            // Close the file descriptor
            fileSystem.Close(fileDescriptor);
        }
    }
}