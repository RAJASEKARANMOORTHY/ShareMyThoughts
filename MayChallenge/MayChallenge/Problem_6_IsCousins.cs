using MayChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MayChallenge
{
    [TestClass]
    public class Problem_6_IsCousins
    {
        //        Cousins in Binary Tree
        //Solution
        //In a binary tree, the root node is at depth 0, and children of each depth k node are at depth k+1.

        //Two nodes of a binary tree are cousins if they have the same depth, but have different parents.

        //We are given the root of a binary tree with unique values, and the values x and y of two different nodes in the tree.
        //Return true if and only if the nodes corresponding to the values x and y are cousins.

        //Example 1:
        //Input: root = [1, 2, 3, 4], x = 4, y = 3
        //Output: false

        //Example 2:
        //Input: root = [1, 2, 3, null, 4, null, 5], x = 5, y = 4
        //Output: true

        //Example 3:
        //Input: root = [1, 2, 3, null, 4], x = 2, y = 3
        //Output: false

        //Constraints:
        //The number of nodes in the tree will be between 2 and 100.
        //Each node has a unique integer value from 1 to 100.
        [TestMethod]
        public void IsCousins()
        {
            var test = new TreeNodeTest();
            //var result1 = IsCousins(test.ConvertArrayToBinary(new int?[] { 1, 2, 3, 4 }), 4, 3);
            var result2 = IsCousins(test.ConvertArrayToBinary(new int?[] { 1, 2, 3, null, 4, null, 5 }), 5, 4);
            //var result3 = IsCousins(test.ConvertArrayToBinary(new int?[] { 1, 2, 3, null, 4 }), 2, 3);
        }

        public bool IsCousins(TreeNode root, int x, int y)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                bool isSiblings = false;
                bool isCousins = false;

                int queueSize = queue.Count;
                while (queueSize > 0)
                {
                    var current = queue.Dequeue();

                    if (current == null)
                        isSiblings = false;
                    else
                    {
                        if (current.val == x || current.val == y)
                        {
                            if (!isCousins)
                                isSiblings = isCousins = true;
                            else
                                return !isSiblings;
                        }

                        if (current.left != null)
                            queue.Enqueue(current.left);

                        if (current.right != null)
                            queue.Enqueue(current.right);

                            queue.Enqueue(null);
                    }
                    queueSize--;
                }

                if (isCousins)
                    return false;
            }
            return false;
        }
    }
}
