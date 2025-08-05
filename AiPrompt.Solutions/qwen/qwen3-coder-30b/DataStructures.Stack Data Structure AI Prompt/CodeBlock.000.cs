namespace StackLibrary;

/// <summary>
/// Defines the contract for a stack data structure
/// </summary>
/// <typeparam name="T">The type of elements in this stack</typeparam>
public interface IStack<T>
{
    /// <summary>
    /// Adds an element to the top of the stack
    /// </summary>
    /// <param name="value">The element to add</param>
    void Push(T value);
    
    /// <summary>
    /// Removes and returns the element at the top of the stack
    /// </summary>
    /// <returns>The element that was removed from the top of the stack</returns>
    T Pop();
    
    /// <summary>
    /// Returns the element at the top of the stack without removing it
    /// </summary>
    /// <returns>The element at the top of the stack</returns>
    T Peek();
    
    /// <summary>
    /// Checks if the stack is empty
    /// </summary>
    /// <returns>True if the stack is empty, false otherwise</returns>
    bool IsEmpty();
    
    /// <summary>
    /// Checks if the stack is full
    /// </summary>
    /// <returns>True if the stack is full, false otherwise</returns>
    bool IsFull();
}