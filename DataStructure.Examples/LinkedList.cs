using System.Collections;

namespace DataStructure.Examples;

public class LinkedList<T> : ILinkedList<T>
{
    private Node<T> _head;
    private Node<T> _tail;
    private int _count;
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T data)
    {
        var node = new Node<T>(data);
        if (IsEmpty)
        {
            _head = node;
        }
        else
        {
            _tail.Next = node;
        }
        _tail = node;
        _count++;
    }

    public bool Remove(T data)
    {
        var current = _head;
        Node<T> prev = null;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (prev == null)
                {
                    _head = current.Next;
                }

                if (current.Next == null)
                {
                    _tail = prev;
                }

                if (prev != null && current.Next != null)
                {
                    prev.Next = current.Next;
                }
                _count--;
                
                return true;
            }

            prev = current;
            current = current.Next;
        }
        return false;
    }

    public int Count => _count;

    public bool IsEmpty => _count == 0;

    public void Clear()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void AppendFirst(T data)
    {
        var node = new Node<T>(data);
        if (IsEmpty)
        {
            _tail = node;
        }
        else
        {
            node.Next = _head;
        }

        _head = node;
        _count++;
    }
}