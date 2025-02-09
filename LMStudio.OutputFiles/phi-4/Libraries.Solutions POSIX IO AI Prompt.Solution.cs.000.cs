using System;

namespace PosixIoSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("POSIX I/O Simulation");
            // Example usage of the library
            var fileSystem = new InMemoryFileSystem();
            var fileDescriptor = fileSystem.OpenFile("example.txt", FileMode.Create);
            
            if (fileDescriptor != null)
            {
                fileSystem.WriteToFile(fileDescriptor, "Hello, POSIX!");
                fileSystem.CloseFile(fileDescriptor);
                
                fileDescriptor = fileSystem.OpenFile("example.txt", FileMode.Read);
                if (fileDescriptor != null)
                {
                    var content = fileSystem.ReadFile(fileDescriptor);
                    Console.WriteLine($"Content: {content}");
                    fileSystem.CloseFile(fileDescriptor);
                }
            }
        }
    }
}