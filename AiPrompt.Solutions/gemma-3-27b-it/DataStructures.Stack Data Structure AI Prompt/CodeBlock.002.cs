// Interface File - StackLibrary\IStack.cs

namespace StackLibrary;

public interface IStack
{
	bool IsEmpty();
	bool IsFull();
	void Push(int data);
	int Pop();
	int Peek();
}