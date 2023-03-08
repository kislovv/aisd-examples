namespace DataStructure.Examples;

public interface INodeStack<T> : IEnumerable<T>
{
    int Count { get; }
    bool IsEmpty { get; }
    void Push(T item);
    T Pop();
    T Peek();
}