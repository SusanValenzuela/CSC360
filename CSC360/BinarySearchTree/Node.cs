using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.BinarySearchTree
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
            if(data.CompareTo(this.Data) >= 0)
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

        // remove node if no kids
        // 1 kid - replace node with its child
        // 2 kids - replace value w largest left value
        //checks for imbalances after
        public Node<T>? Remove(T value)
        {
            if (value.CompareTo(this.Data) < 0)
            {
                //left
                if (Left != null)
                {
                    //update
                    Left = Left.Remove(value);
                }
                } else if (value.CompareTo(this.Data) > 0)
            {
                //right
                if (Right != null)
                {
                    Right = Right.Remove(value);
                }

            }
            //remove + assigns child to new num
            //stop case 
            //checks if children are null, or if it has 2 
            else
            {
                if(Left == null)
                {
                    return Right;

                 
                } else if(Right == null)
                { 
                    return Left;
                }
                // 2 child
                //max value overrides current data
                this.Data = MaxValue(Left);
                Left = Left.Remove(this.Data);
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
        public bool Contains(T value)
        {
            if (value.CompareTo(Data) == 0)
            {
                return true;
            }

            if (value.CompareTo(Data) < 0)
            {
                if (Left == null)
                {
                    return false;
                }

                return Left.Contains(value);
            }
            else
            {
                if (Right == null)
                {
                    return false;
                }

                return Right.Contains(value);
            }
        
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



