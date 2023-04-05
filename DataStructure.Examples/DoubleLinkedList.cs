using System.Collections;

namespace DataStructure.Examples;

public class DoubleLinkedList<TData> : IDoublyLinkedList<TData>
{
    private DoublyNode<TData>? _head;
    private DoublyNode<TData>? _tail;
    
    public IEnumerator<TData> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(TData data)
    {
        var node = new DoublyNode<TData>(data);
        if (IsEmpty || _tail == null)
        {
            _head = node;
        }
        else
        {
            node.Previous = _tail;
            _tail.Next = node;
        }
        _tail = node;
        Count++;
    }

    public void AddFirst(TData data)
    {
        var node = new DoublyNode<TData>(data);
        if (IsEmpty || _head == null)
        {
            _tail = node;
        }
        else
        {
            node.Next = _head;
            _head.Previous = node;
        }
        _head = node;
        Count++;
    }

    public bool Remove(TData data)
    {
        if (IsEmpty || !Contains(data)) return false;
        
        var current = _head;
        while (current != null && current.Data != null)
        {
            if (current.Data.Equals(data))
            {
                if (Count == 1)
                {
                    _head = null;
                    _tail = null;
                }
                else if (current == _head)
                {
                    _head = _head.Next!;
                    _head.Previous = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail.Previous!;
                    _tail.Next = null;
                }
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
                
                Count--;
                return true;
            }
            
            current = current.Next;
        }

        return false;
    }

    public bool Contains(TData data)
    {
        return Enumerable.Contains(this, data);
    }

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;
}