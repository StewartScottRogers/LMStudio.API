// Opening a file in read-only mode
var file = IOController.OpenFileDescriptor("r");
using (file)
{
    var buffer = new byte[1024];
    int read = file.Read(buffer);
    // Buffer contains data from the in-memory file
}

// Writing to standard output
var stdout = IOController.GetStandardStream(1) as FileOutput;
stdout.Write("Hello, World!\n");
stdout.Flush();