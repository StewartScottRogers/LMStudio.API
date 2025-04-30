using System;

namespace StackLibrary.Models
{
    public record StackRecord<T>(T Value)
        where T : notnull;
}