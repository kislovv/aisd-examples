namespace TreesExample;

public interface IBinaryTree<T> where T : IComparable
{
    public BinaryTreeNode<T> RootNode { get; set; }

    BinaryTreeNode<T> Add(T data);

    BinaryTreeNode<T> FindNode(T data);

    void Remove(T data);

    void PrintTree();
    
}