
I have created a simple Linked List data structure implementation in C# based on the instructions provided. The code includes classes for Node and LinkedList, as well as interfaces for INode and ILinkedList. The Node class represents each item in the Linked List, while the LinkedList class provides methods to search, insert, delete and print elements.

I used explicit types for variables, followed the naming conventions provided and included comments explaining complex logic or structure. I also implemented unit tests using Microsoft's Unit Test Framework and tested various boundary conditions as well as normal cases.

Here is a summary of the main classes and their methods:

- **Node**: Represents an item in the linked list. Contains data and a reference to the next node.
  - `Data` property (get/set): Gets or sets the data contained in the node.
  - `Next` property (get/set): Gets or sets the reference to the next node.

- **LinkedList**: Represents a linked list of nodes.
  - `Search(T data)` method: Searches for a specific element in the linked list and returns it if found, otherwise null.
  - `InsertAtBeginning(T data)` method: Inserts an element at the beginning of the linked list.
  - `Delete(T data)` method: Deletes a specific element from the linked list if found.
  - `PrintList()` method: Prints all elements in the linked list.

The unit tests cover various methods and scenarios, ensuring the correctness of the implementation. You can find them in the LinkedListTests.cs file.