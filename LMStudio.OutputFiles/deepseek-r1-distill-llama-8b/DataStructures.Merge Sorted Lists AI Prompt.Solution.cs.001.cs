using System.Collections.Generic;

public record MergedList<T> : List<T>
{
    public MergedList(IEnumerable<T> list) 
        : base(list)
    {
    }
}