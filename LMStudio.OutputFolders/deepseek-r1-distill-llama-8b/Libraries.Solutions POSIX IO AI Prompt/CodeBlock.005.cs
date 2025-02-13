// Example: Reading from stdin
var stdin = FileDescriptor.OpenFile("stdin", OpenMode.Read);
byte[] buffer = new byte[1024];
ReadResult result = ReadFile(stdin, buffer, out long readBytes);

// Example: Writing to stdout
StreamWriter writer = new StreamWriterWrapper(FileDescriptor.OpenFile("stdout", "w"));
writer.WriteLine("Hello World");