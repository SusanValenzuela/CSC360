using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360.BinarySearchTree.Strategies

    {
        public interface IComparisonStrategy<T>
        {
            int Compare(T first, T second);
        }
    }

