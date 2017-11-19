using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Разработать обобщенный класс-коллекцию BinarySearchTree (бинарное дерево поиска). 
Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. 
Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): 
для реализации использовать блок-итератор (yield). Протестировать разработанный класс, используя следующие типы:
System.Int32 (использовать сравнение по умолчанию и подключаемый компаратор); 
System.String (использовать сравнение по умолчанию и подключаемый компаратор); 
пользовательский класс Book, для объектов которого реализовано отношения порядка 
(использовать сравнение по умолчанию и подключаемый компаратор); 
пользовательскую структуру Point, для объектов которого не реализовано отношения порядка 
(использовать подключаемый компаратор). 
*/

namespace BinarySearchTree
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node<T> root;
        private Comparison<T> comparison;

        public BinarySearchTree()
        {
            comparison = DefaultCompare();
        }

        public BinarySearchTree(Comparison<T> comparison)
        {
            if (ReferenceEquals(comparison, null))
            {
                this.comparison = DefaultCompare();
            }
            else
            {
                this.comparison = comparison;
            }
        }

        public BinarySearchTree(IComparer<T> comparer) 
            : this(comparer.Compare)
        {
        }

        public BinarySearchTree(T value)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(nameof(value));
            }

            comparison = DefaultCompare();
            root = new Node<T>(value);
        }

        public BinarySearchTree(T value, IComparer<T> comparer)
            : this(value, comparer.Compare)
        {
        }

        public BinarySearchTree(T value, Comparison<T> comparison) 
            : this(comparison)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(nameof(value));
            }

            root = new Node<T>(value);
        }

        public BinarySearchTree(params T[] values) 
            : this()
        {
            if (ReferenceEquals(values, null))
            {
                throw new ArgumentNullException(nameof(values));
            }
            foreach (T value in values)
            {
                Insert(value);
            }
        }

        public BinarySearchTree(Comparison<T> comparison, params T[] values)
            : this(values)
        {
            if (ReferenceEquals(comparison, null))
            {
                this.comparison = DefaultCompare();
            }
            else
            {
                this.comparison = comparison;
            }
        }

        public BinarySearchTree(IComparer<T> comparer, params T[] values)
            : this(comparer.Compare, values)
        {
        }

        public void Insert(T newNode)
        {
            if (ReferenceEquals(newNode, null))
            {
                throw new ArgumentNullException(nameof(newNode));
            }

            Node<T> node = root;
            Node<T> parent = null;

            while (!ReferenceEquals(node, null))
            {
                if (comparison.Invoke(newNode, node.Value) < 0)
                {
                    parent = node;
                    node = node.Left;
                }
                else if (comparison.Invoke(newNode, node.Value) > 0)
                {
                    parent = node;
                    node = node.Right;
                }
            }
            if (ReferenceEquals(root, null)) root = new Node<T>(newNode);
            else
            {
                if (comparison.Invoke(parent.Value, newNode) > 0)
                    parent.Left = new Node<T>(newNode);
                else
                    parent.Right = new Node<T>(newNode);
            }
        }

        public bool IsContain(T curNode)
        {
            if (ReferenceEquals(curNode, null))
            {
                throw new ArgumentNullException(nameof(curNode));
            }
            Node<T> node = root;
            while (!ReferenceEquals(node, null))
            {
                if (comparison.Invoke(node.Value, curNode) == 0)
                {
                    return true;
                }
                else
                {
                    node = comparison.Invoke(node.Value, curNode) < 0 ? node.Right : node.Left;
                }
            }

            return false;
        }

        public void Remove(T curNode)
        {
            if (ReferenceEquals(curNode, null))
            {
                throw new ArgumentNullException(nameof(curNode));
            }

            if (ReferenceEquals(root, null))
            {
                return;
            }

            if (!IsContain(curNode))
            {
                return;
            }

            Node<T> node = Find(curNode).Item1;
            Node<T> parent = Find(curNode).Item2;

            if (node.Left == null && node.Right == null)
            {
                if (ReferenceEquals(parent, null))
                {
                    root = null;
                    return;
                }
                if (ReferenceEquals(parent.Left, null))
                {
                    if (comparison.Invoke(node.Value, parent.Left.Value) == 0)
                    {
                        parent.Left = null;
                    }
                }
                if (ReferenceEquals(parent.Right, null))
                {
                    if (comparison.Invoke(node.Value, parent.Right.Value) == 0)
                    {
                        parent.Right = null;
                    }
                }
            }
            else
            {
                if (ReferenceEquals(node.Right, null))
                {
                    if (ReferenceEquals(parent, null))
                    {
                        root = node.Left;
                        return;
                    }
                    if (comparison.Invoke(node.Value, parent.Value) < 0)
                    {
                        parent.Left = node.Left;
                    }
                    else
                    {
                        parent.Right = node.Left;
                    }
                }
                else
                {
                    if (ReferenceEquals(node.Right.Left, null))
                    {
                        node.Right.Left = node.Left;
                        if (parent == null)
                        {
                            root = node.Right;
                            return;
                        }
                        node.Right.Left = node.Left;
                        if (comparison.Invoke(node.Value, parent.Value) < 0)
                            parent.Left = node.Right;
                        else
                            parent.Right = node.Right;
                    }
                    else
                    {
                        Node<T> lastLeft = node.Right.Left;
                        Node<T> lastLeftParent = node.Right;
                        while (!ReferenceEquals(lastLeft.Left, null))
                        {
                            lastLeftParent = lastLeft;
                            lastLeft = lastLeft.Left;
                        }
                        lastLeftParent.Left = lastLeft.Right;
                        lastLeft.Left = node.Left;
                        lastLeft.Right = node.Right;
                        if (parent == null)
                        {
                            root = lastLeft;
                            return;
                        }
                        if (comparison.Invoke(node.Value, parent.Value) < 0)
                            parent.Left = lastLeft;
                        else
                            parent.Right = lastLeft;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Comparison<T> DefaultCompare()
        {
            if (typeof(T).GetInterface("IComparable`1") != null || typeof(T).GetInterface("IComparable") != null)
            {
                return Comparer<T>.Default.Compare;
            }
            else
            {
                throw new Exception("There is no comparer.");
            }
        }

        private Tuple<Node<T>, Node<T>> Find(T curNode)
        {
            if (ReferenceEquals(curNode, null))
            {
                throw new ArgumentNullException(nameof(curNode));
            }

            Node<T> node = root;
            Node<T> parentNode = null;

            while (node != null)
            {
                if (comparison.Invoke(node.Value, curNode) == 0)
                {
                    return Tuple.Create(node, parentNode);
                }
                else
                {
                    parentNode = node;
                    node = comparison.Invoke(node.Value, curNode) > 0 ? node.Left : node.Right;
                }
            }

            return null;
        }

        private class Node<T>
        {
            private T value;
            private Node<T> left;
            private Node<T> right;

            public Node()
            {
            }

            public Node(T value)
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Value = value;
            }

            public T Value
            {
                get => value;
                set => this.value = value;
            }

            public Node<T> Left
            {
                get;
                set;
            }

            public Node<T> Right
            {
                get;
                set;
            }
        }
    }
}
