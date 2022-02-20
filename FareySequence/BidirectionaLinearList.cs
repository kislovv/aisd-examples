namespace FareySequence;

public class BidirectionaLinearList<T>
{
    public Node<T> Head { get; private set; }
    private Node<T> _tail; // последний/хвостовой элемент
    public int Count { get; private set; }

        // добавление элемента
        public void Add(T data)
        {
            var node = new Node<T>(data);
 
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }
            _tail = node;
            Count++;
        }
        
        // удаление
        public bool Remove(T data)
        {
            Node<T> current = Head;
 
            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if(current!=null)
            {
                // если узел не последний
                if(current.Next!=null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    _tail = current.Previous;
                }
 
                // если узел не первый
                if(current.Previous!=null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    Head = current.Next;
                }
                Count--;
                return true;
            }
            return false;
        }

        public void Clear()
        {
            Head = null;
            _tail = null;
            Count = 0;
        }
        
}

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Previous { get; set; }
    public Node<T> Next { get; set; }
    
    public Node(T data)
    {
        Data = data;
    }
    
}

public class Fraction 
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }
}