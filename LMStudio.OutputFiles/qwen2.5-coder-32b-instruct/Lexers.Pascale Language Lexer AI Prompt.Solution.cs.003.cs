public abstract class Node { }

public record ProgramNode(Node Block) : Node;
// Define other nodes as per your grammar.