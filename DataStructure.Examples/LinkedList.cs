using System.Collections;

namespace DataStructure.Examples;

public class LinkedList<T> : ILinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
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
            _tail!.Next = node;
        }
        _tail = node;
        Count++;
    }

    public bool Remove(T data)
    {
        var current = _head;
        Node<T>? prev = null;
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
                Count--;
                
                return true;
            }

            prev = current;
            current = current.Next;
        }
        return false;
    }

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public void Clear()
    {
        _head = null;
        _tail = null;
        Count = 0;
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
        Count++;
    }
}