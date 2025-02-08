public class StandardStreams {
    private static readonly StreamWrapper _standardOutput = new StreamWrapper(Console.Out, Console.Out);
    private static readonly StreamWrapper _standardInput = new StreamWrapper(Console.In, Console.In);

    public static void Write(string message) { _standardOutput.Write(message); }
    public static string ReadLine() { return _standardInput.ReadLine(); }
    // Add more methods as required.
}