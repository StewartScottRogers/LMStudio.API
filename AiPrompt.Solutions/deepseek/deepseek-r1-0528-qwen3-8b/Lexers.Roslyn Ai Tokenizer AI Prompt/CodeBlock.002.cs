using System;

public record Part { 
    public string? PartNumber { get; set; }
    public int Quantity { get; set; }

    // Constructor for the Part class. Note: We are using a read-only property.
}

But wait, the prompt says "From an external source or not", but we don't have that.

I think I need to create something useful.

Let me define:

1. A PartInventoryService interface and its implementation with bounding conditions for unit tests.
2. Unit test all methods in PartRepository.

Since no description is given, I will create a simple inventory system for parts (parts) or items? Let's use Parts as the main entity.

But note: "Application Description" says business analysts or entry-level programmers.