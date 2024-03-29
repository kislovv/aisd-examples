﻿namespace DataStructure.Examples;

public interface IQueue<T> : IEnumerable<T>
{
    void Enqueue(T data);
    T Dequeue();
    public T First { get; }
    void Clear();
    bool Contains(T data);
    bool IsEmpty { get; }
}
