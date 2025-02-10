using System;
using System.Collections.Generic;
using System.Linq;

public record Merger<T> where T : IComparable<T>
{
    private readonly Queue<IEnumerable<T>> _queues = new();
    private readonly HashSet<T> _visitedElements = new();

    public Merger<T> Add(IEnumerable<T> list)
    {
        if (list == null) return this;
        
        if (_queues.Count == 0)
        {
            foreach (T element in list)
            {
                if (!_visitedElements.Add(element))
                {
                    AddElementToResult(element);
                }
            }
            return this;
        }

        _queues.Enqueue(list);

        return this;
    }

    private void Merge()
    {
        if (_queues.Count == 0)
            return;

        var currentList = _queues.Dequeue();
        var nextList = _queues.Peek();

        int compareResult = Comparer.Default.Compare(currentList.First(), nextList.First());

        if (compareResult <= 0)
        {
            AddElementToResult(currentList.First());
            currentList = currentList.SkipFirst();
        }

        if (!currentList.MoveNext() && !nextList.MoveNext())
            return;

        if (compareResult > 0)
        {
            AddElementToResult(nextList.First());
            nextList = nextList.SkipFirst();
        }
    }

    private void AddElementToResult(T element)
    {
        _visitedElements.Add(element);
        Result.Add(element);
    }

    public IEnumerable<T> Result { get; private set; }

    public static Merger<T> New => new Merger<T>();
}