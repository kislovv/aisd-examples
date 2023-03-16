using System.Collections;

namespace DataStructure.Examples;

public class NodeStack<T> : INodeStack<T>
{
    private Node<T>? _head;
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count { get; private set; }
    public bool IsEmpty => Count == 0;
    public void Push(T item)
    {
        var node = new Node<T>(item);
        node.Next = _head;
        _head = node;
        Count++;
    }

    public T? Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("");
        }
        var data = _head!.Data;
        _head = _head.Next;
        Count--;
        return data;
    }

    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException();
        }

        return _head!.Data;
    }
}