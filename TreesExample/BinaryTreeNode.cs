namespace TreesExample;


/// <summary>
/// Узел бинарного дерева
/// </summary>
/// <typeparam name="T"></typeparam>
public class BinaryTreeNode<T> where T : IComparable
{
    /// <summary>
    /// Конструктор класса
    /// </summary>
    /// <param name="data">Данные</param>
    public BinaryTreeNode(T data)
    {
        Data = data;
    }

    /// <summary>
    /// Данные которые хранятся в узле
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Левая ветка
    /// </summary>
    public BinaryTreeNode<T>? LeftNode { get; set; }

    /// <summary>
    /// Правая ветка
    /// </summary>
    public BinaryTreeNode<T>? RightNode { get; set; }

    /// <summary>
    /// Родитель
    /// </summary>
    public BinaryTreeNode<T>? ParentNode { get; set; }

    /// <summary>
    /// Высота поддерева (по умолчанию 0)
    /// </summary>
    public int Hight { get; set; } = 0;

}