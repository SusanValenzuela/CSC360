using CSC360.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTestsProject
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        [TestMethod]
        public void BST_CanAddRootNode()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 67;
            string expectedInOrderString = expected + "";

            bst.Add(expected);

            Assert.AreEqual(expectedInOrderString, bst.InOrder());
        }

        [TestMethod]
        public void BST_CanMultiplyValues()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            string expectedInOrderString = "25, 50, 75";

            bst.Add(50);
            bst.Add(25);
            bst.Add(75);

            Assert.AreEqual(expectedInOrderString, bst.InOrder());
        }

        [TestMethod]
        public void BST_CountUpdatesProperlyWithAdd()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            int expected = 3;

            bst.Add(50);
            bst.Add(25);
            bst.Add(75);

            Assert.AreEqual(expected, bst.Count);
        }

        [TestMethod]
        public void BST_AddProperlyPlacesValuesInTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(100);
            bst.Add(50);
            bst.Add(150);

            string expected = "50, 100, 150";

            Assert.AreEqual(expected, bst.InOrder());
        }

        [TestMethod]
        public void BST_ClearProperlyClearsOutTheTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(25);
            bst.Add(75);

            string expectedInOrderInString = "";

            bst.Clear();

            Assert.AreEqual(expectedInOrderInString, bst.InOrder());
        }

        [TestMethod]
        public void BST_ClearProperlyResetsCount()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(25);
            bst.Add(75);

            bst.Clear();

            Assert.AreEqual(0, bst.Count);
        }

        [TestMethod]
        public void BST_InOrderReturnsProperString()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(201);
            bst.Add(100);
            bst.Add(10);
            bst.Add(25);

            string expected = "10, 25, 50, 100, 201";

            string actual = bst.InOrder();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_InOrderReturnsEmptyOnEmptyTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            string expected = "";
            string actual = bst.InOrder();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_InOrderReturnsProperStringOnLeftHeavyTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(40);
            bst.Add(30);
            bst.Add(20);

            string expected = "20, 30, 40, 50";
            string actual = bst.InOrder();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_InOrderReturnsProperStringOnRightHeavyTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(10);
            bst.Add(20);
            bst.Add(30);
            bst.Add(40);

            string expected = "10, 20, 30, 40";
            string actual = bst.InOrder();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_HeightIsProperlyCalculated()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(40);
            bst.Add(30);
            bst.Add(20);

            int expected = 4;

            int actual = bst.Height();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_HeightIsProperlyCalculatedOnEmptyTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            int expected = 0;

            int actual = bst.Height();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_HeightIsProperlyCalculatedOnBalancedTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(25);
            bst.Add(75);

            int expected = 2;

            int actual = bst.Height();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_ToArrayRreturnsProperSetInPopulatedTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(40);
            bst.Add(30);
            bst.Add(20);

            int[] expected = new int[] { 20, 30, 40, 50 };

            int[] actual = bst.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_ToArrayReturnsEmptyArrayOnEmptyTree()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            int[] expected = new int[] { };

            int[] actual = bst.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_ToArrayReturnsSortedValues()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(100);
            bst.Add(50);
            bst.Add(150);
            bst.Add(25);

            int[] expected = new int[] { 25, 50, 100, 150 };

            int[] actual = bst.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BST_RemoveProperlyDeletesLeafNode()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(25);
            bst.Add(75);

            bst.Remove(25);

            string expected = "50, 75";

            Assert.AreEqual(expected, bst.InOrder());
        }

        [TestMethod]
        public void BST_RemoveProperlyUpdatesCount()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(50);
            bst.Add(25);
            bst.Add(75);

            bst.Remove(25);

            Assert.AreEqual(2, bst.Count);
        }
    }
}
