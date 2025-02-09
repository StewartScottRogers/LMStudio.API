public static class ExceptionHandling
{
    public static void HandleException(Exception ex, string message)
    {
        // Implement exception handling logic here
        Console.WriteLine($"{message}: {ex.Message}");
    }
}