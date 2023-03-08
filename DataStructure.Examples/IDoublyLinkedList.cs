namespace DataStructure.Examples;

internal interface IDoublyLinkedList<T>: IEnumerable<T>
{
    void Add(T data);
    void AddFirst(T data);
    bool Remove(T data);
    int Count { get; }
    bool IsEmpty { get; }
}
