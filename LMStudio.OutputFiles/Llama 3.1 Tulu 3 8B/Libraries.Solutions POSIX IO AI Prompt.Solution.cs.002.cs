public class Pipe : IWritableStream, IReadableStream { /* ... */ }

// Example usage for redirecting stdout to a pipe:
var myPipe = new Pipe();
Process p = Process.Start(...);
p.StandardOutput = myPipe;