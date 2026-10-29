using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360.BinarySearchTree.Strategies
{
    
        public class AscendingStrategy<T> : IComparisonStrategy<T>
            where T : IComparable<T>
        {
            public int Compare(T first, T second)
            {
                return first.CompareTo(second);
            }
        }
    }

