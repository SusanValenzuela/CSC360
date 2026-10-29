using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC360.BinarySearchTree.Strategies;

namespace CSC360.BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T>? Root { get; private set; }
        public int Count { get; set; }

        private readonly IComparisonStrategy<T> _strategy;

        public BinarySearchTree(
            IComparisonStrategy<T>? strategy = null)
        {
            _strategy = strategy ?? new AscendingStrategy<T>();
        }

        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
            }
            else
            {
                Root.Add(data, _strategy);
            }

            Count++;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }


        public void Remove(T value)
        {
            if (Root == null)
            {
                return;
            }

            if (Contains(value))
            {
                Root = Root.Remove(value, _strategy);
                Count--;
            }
        }

        //gets the hieght o f tree
        // a tree with a sing,e node is conisdered height = 1
        //child + 1 
        //
        public int Height()
        {
            if (Root == null)
            {
                return 0;
            }
            else
            {
                return Root.Height();
            }
        }

        public T[] ToArray()
        {
            if (Root == null)
            {
                return new T[Count];
            }
            T[] returnArray = new T[Count];
            Root.ToArray(returnArray, 0);
            return returnArray;
        }

        public bool Contains(T value)
        {
            if (Root == null)
            {
                return false;
            }

            return Root.Contains(value, _strategy);
        }

        public string InOrder()
        {
            if (Root == null)
            {
                return string.Empty;
            }
            else
            {
                return Root.InOrder();
            }
        }

        public string PreOrder()
        {
            if (Root == null)
            {
                return string.Empty;
            }

            return Root.PreOrder();
        }

        public string PostOrder()
        {
            if (Root == null)
            {
                return string.Empty;
            }

            return Root.PostOrder();
        }
    }
}
