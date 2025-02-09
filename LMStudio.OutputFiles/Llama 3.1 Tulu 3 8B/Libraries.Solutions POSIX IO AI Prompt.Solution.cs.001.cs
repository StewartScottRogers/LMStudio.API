public class StdIn : IReadableStream { /* ... */ }
public class StdOut : IWritableStream { /* ... */ }
public class StdErr : IWritableStream { /* ... */ }

// Example of an interface definition:
public interface IReadableStream { byte[] Read(int count); }
public interface IWritableStream { void Write(byte[] data); }