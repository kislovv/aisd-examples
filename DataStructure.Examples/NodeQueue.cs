using System.Collections;

namespace DataStructure.Examples;

public class NodeQueue<T> : IQueue<T>
{
    private Node<T> _first;
    private Node<T> _last;
    private int _count;
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enqueue(T data)
    {
        var node = new Node<T>(data);
        if (IsEmpty)
        {
            _first = node;
        }
        else
        {
            _last.Next = node;
        }
        _last = node;
        _count++;
    }

    public T Dequeue()
    {
        var result = _first.Data;
        if (IsEmpty)
        {
            return default;
        }
        else
        {
            _first = _first.Next;
            _count--;
        }
        return result;
    }

    public T First
    {
        get
        {
            if (IsEmpty)
            {
                throw new NullReferenceException();
            }

            return _first.Data;
        }
    }
    public void Clear()
    {
        _first = null;
        _last = null;
        _count = 0;
    }

    public bool Contains(T data)
    {
        var current = _first;
        
        while (current != null)
        {
            if (current.Data.Equals((data)))
            {
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public bool IsEmpty => _count == 0;
}