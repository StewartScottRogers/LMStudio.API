public class StackOverflowException : Exception
{
    public StackOverflowException(string message) : base(message)
    {
    }
}

public class StackUnderflowException : Exception
{
    public StackUnderflowException(string message) : base(message)
    {
    }
}