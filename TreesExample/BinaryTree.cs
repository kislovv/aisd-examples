namespace TreesExample;

using System;
using System.Collections.Generic;

public class BinaryTree<T> where T : IComparable<T>
{
    private BinaryTree<T> _parent;
    private BinaryTree<T> _left;
    private BinaryTree<T> _right;
    private T? _val;
    private List<T>? _listForPrint = new List<T>();

    public BinaryTree(T val, BinaryTree<T> parent)
    {
        _val = val;
        _parent = parent;
    }

    public void Add(T val)
    {
        if (val.CompareTo(_val) < 0)
        {
            if (_left == null)
            {
                _left = new BinaryTree<T>(val, this);
            }
            else
            {
                _left.Add(val);
            }
        }
        else
        {
            if (_right == null)
            {
                _right = new BinaryTree<T>(val, this);
            }
            else
            {
                _right.Add(val);
            }
        }
    }
    
    public BinaryTree<T>? Search(T val)
    {
        return Search(this, val);
    }

    public bool Remove(T val)
    {
        //Проверяем, существует ли данный узел
        var tree = Search(val);
        if (tree == null)
        {
            //Если узла не существует, вернем false
            return false;
        }

        BinaryTree<T>? curTree;

        //Если удаляем корень
        if (tree == this)
        {
            curTree = tree?._right ?? tree?._left;

            while (curTree?._left != null)
            {
                curTree = curTree._left;
            }

            T temp = curTree._val;
            Remove(temp);
            tree._val = temp;

            return true;
        }

        //Удаление листьев
        if (tree._left == null && tree._right == null && tree._parent != null)
        {
            if (tree == tree._parent._left)
                tree._parent._left = null;
            else
            {
                tree._parent._right = null;
            }

            return true;
        }

        //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
        if (tree._left != null && tree._right == null)
        {
            //Меняем родителя
            tree._left._parent = tree._parent;
            if (tree == tree._parent._left)
            {
                tree._parent._left = tree._left;
            }
            else if (tree == tree._parent._right)
            {
                tree._parent._right = tree._left;
            }

            return true;
        }

        //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
        if (tree._left == null && tree._right != null)
        {
            //Меняем родителя
            tree._right._parent = tree._parent;
            if (tree == tree._parent._left)
            {
                tree._parent._left = tree._right;
            }
            else if (tree == tree._parent._right)
            {
                tree._parent._right = tree._right;
            }

            return true;
        }

        //Удаляем узел, имеющий поддеревья с обеих сторон
        if (tree._right != null && tree._left != null)
        {
            curTree = tree._right;

            while (curTree._left != null)
            {
                curTree = curTree._left;
            }

            //Если самый левый элемент является первым потомком
            if (curTree._parent == tree)
            {
                curTree._left = tree._left;
                tree._left._parent = curTree;
                curTree._parent = tree._parent;
                if (tree == tree._parent._left)
                {
                    tree._parent._left = curTree;
                }
                else if (tree == tree._parent._right)
                {
                    tree._parent._right = curTree;
                }

                return true;
            }
            //Если самый левый элемент НЕ является первым потомком
            else
            {
                if (curTree._right != null)
                {
                    curTree._right._parent = curTree._parent;
                }

                curTree._parent._left = curTree._right;
                curTree._right = tree._right;
                curTree._left = tree._left;
                tree._left._parent = curTree;
                tree._right._parent = curTree;
                curTree._parent = tree._parent;
                if (tree == tree._parent._left)
                {
                    tree._parent._left = curTree;
                }
                else if (tree == tree._parent._right)
                {
                    tree._parent._right = curTree;
                }

                return true;
            }
        }

        return false;
    }
    
    public void Print()
    {
        _listForPrint?.Clear();
        _print(this);
        Console.WriteLine();
    }

    public override string? ToString()
    {
        return _val?.ToString();
    }
    
    private BinaryTree<T>? Search(BinaryTree<T>? tree, T val)
    {
        if (tree == null)
        {
            return null;
        }

        return val.CompareTo(tree._val) switch
        {
            1 => Search(tree._right, val),
            -1 => Search(tree._left, val),
            0 => tree,
            _ => null
        };
    }

    private void _print(BinaryTree<T> node)
    {
        if (node == null) return;
        _print(node._left);
        _listForPrint.Add(node._val);
        Console.Write(node + " ");
        if (node._right != null)
            _print(node._right);
    }
}
