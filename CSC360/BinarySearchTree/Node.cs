using CSC360.BinarySearchTree.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360.BinarySearchTree
{
    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }
        public Node(T data)
        {
            Data = data;
        }
        public void Add(T data)

        {
            //75.compareto(50)
            //25.compareto(50)
            if (data.CompareTo(this.Data) >= 0)
            {
                if (Right == null)
                {
                    Right = new Node<T>(data);
                }
                else
                {
                    Right.Add(data);
                }
            }
            else
            {
                if (Left == null)
                {
                    Left = new Node<T>(data);
                }
                else
                {
                    Left.Add(data);
                }
            }
        }
        public void Add(T data, IComparisonStrategy<T> strategy)
        {
            if (strategy.Compare(data, Data) >= 0)
            {
                if (Right == null)
                {
                    Right = new Node<T>(data);
                }
                else
                {
                    Right.Add(data, strategy);
                }
            }
            else
            {
                if (Left == null)
                {
                    Left = new Node<T>(data);
                }
                else
                {
                    Left.Add(data, strategy);
                }
            }
        }

        // remove node if no kids
        // 1 kid - replace node with its child
        // 2 kids - replace value w largest left value
        //checks for imbalances after
        public Node<T>? Remove(T value, IComparisonStrategy<T> strategy)
        {
            int comparison = strategy.Compare(value, Data);

            if (comparison < 0)
            {
                if (Left != null)
                {
                    Left = Left.Remove(value, strategy);
                }
            }
            else if (comparison > 0)
            {
                if (Right != null)
                {
                    Right = Right.Remove(value, strategy);
                }
            }
            else
            {
                if (Left == null)
                {
                    return Right;
                }

                if (Right == null)
                {
                    return Left;
                }

                Data = MaxValue(Left);
                Left = Left.Remove(Data, strategy);
            }

            return this;
        }
        private T MaxValue(Node<T> root)
        {
            while (root.Right != null)
            {
                root = root.Right;
            }
            return root.Data;
        }

        public int Height()
        {
            int LeftHeight = 0;
            int RightHeight = 0;
            if (Left != null)
            {
                LeftHeight = Left.Height();
            }
            if (Right != null)
            {
                RightHeight = Right.Height();
            }
            return Math.Max(LeftHeight, RightHeight) + 1;
        }
                
        //toarray method
        public int ToArray(T[] arr, int currentIndex)
        {
            if (Left != null)
            {
                currentIndex = Left.ToArray(arr, currentIndex);
            }
            arr[currentIndex++] = this.Data;

            if (Right != null)
            {
                currentIndex = Right.ToArray(arr, currentIndex);
            }
            
            return currentIndex;
        }

        //dont go through every node
        public bool Contains(T value, IComparisonStrategy<T> strategy)
        {
            int comparison = strategy.Compare(value, Data);

            if (comparison == 0)
            {
                return true;
            }

            if (comparison < 0)
            {
                return Left != null && Left.Contains(value, strategy);
            }

            return Right != null && Right.Contains(value, strategy);
        }

        public string InOrder()
        {
            string leftInOrder = ""; // 
            string rightInOrder = "";

            if (Left != null)
            {
                leftInOrder = Left.InOrder() + ", ";
            }
            if (Right != null)
            {
                rightInOrder = ", " + Right.InOrder();
            }
            // left, root, right
            return leftInOrder + this.Data + rightInOrder;
        }

        public string PreOrder()
        {
            string leftPreOrder = "";
            string rightPreOrder = "";

            if (Left != null)
            {
                leftPreOrder = ", " + Left.PreOrder();
            }

            if (Right != null)
            {
                rightPreOrder = ", " + Right.PreOrder();
            }
            // root, left, right
            return this.Data + leftPreOrder + rightPreOrder;
        }
        public string PostOrder()
        {
            string leftPostOrder = "";
            string rightPostOrder = "";

            if (Left != null)
            {
                leftPostOrder = Left.PostOrder() + ", ";
            }

            if (Right != null)
            {
                rightPostOrder = Right.PostOrder() + ", ";
            }
            // left, right, root
            return leftPostOrder + rightPostOrder + this.Data;
        }

    }

}



