// Class File - StackLibrary\Stack.cs

namespace StackLibrary;

public class Stack : IStack
{
	private readonly int[] stackArray;
	private StackParametersRecord stackParameters;

	public Stack(int capacity)
	{
		stackArray = new int[capacity];
		stackParameters = new StackParametersRecord(capacity, -1); // Initialize top to -1 for an empty stack.
	}

	public bool IsEmpty()
	{
		// Check if the stack is empty by verifying if the top index is -1.
		return stackParameters.TopIndex == -1;
	}

	public bool IsFull()
	{
		// Check if the stack is full by comparing the top index with the capacity minus 1.
		return stackParameters.TopIndex == stackParameters.Capacity - 1;
	}

	public void Push(int data)
	{
		// Check for stack overflow before pushing an element.
		if (IsFull())
		{
			throw new StackOverflowException("Stack is full.");
		}

		// Increment the top index and then add the data to the stack array at the new top index.
		stackParameters = new StackParametersRecord(stackParameters.Capacity, ++stackParameters.TopIndex);
		stackArray[stackParameters.TopIndex] = data;
	}

	public int Pop()
	{
		// Check for stack underflow before popping an element.
		if (IsEmpty())
		{
			throw new InvalidOperationException("Stack is empty.");
		}

		// Get the value at the top of the stack and then decrement the top index.
		int data = stackArray[stackParameters.TopIndex];
		stackParameters = new StackParametersRecord(stackParameters.Capacity, --stackParameters.TopIndex);
		return data;
	}

	public int Peek()
	{
		// Check if the stack is empty before peeking at the top element.
		if (IsEmpty())
		{
			throw new InvalidOperationException("Stack is empty.");
		}

		// Return the value at the top of the stack without removing it.
		return stackArray[stackParameters.TopIndex];
	}
}