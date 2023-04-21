using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesExample
{
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> RootNode { get ; set ; }

        public BinaryTree(T rootData)
        {
            RootNode = new BinaryTreeNode<T>(rootData);
        }

        public BinaryTreeNode<T> Add(T data)
        {
            throw new NotImplementedException();
        }

        public T BoundaryLeft(T data)
        {
            throw new NotImplementedException();
        }

        public T BoundaryRight(T data)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T data)
        {
            throw new NotImplementedException();
        }

        public BinaryTreeNode<T> FindNode(T data)
        {
            throw new NotImplementedException();
        }

        public void PrintTree()
        {
            throw new NotImplementedException();
        }

        public void Remove(T data)
        {
            throw new NotImplementedException();
        }
    }
}
