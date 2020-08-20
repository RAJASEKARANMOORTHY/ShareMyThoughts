using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JuneChallenge
{
    [TestClass]
    public class Problem_23_CountNodes
    {
        //Count Complete Tree Nodes
        //Given a complete binary tree, count the number of nodes.

        //Note:
        //In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible.It can have between 1 and 2h nodes inclusive at the last level h.

        //Example:

        //Input: 
        //    1
        //   / \
        //  2   3
        // / \  /
        //4  5 6


        //Output: 6

        [TestMethod]
        public void CountNodes()
        {
            var result1 = CountNodes(TreeNodeUtility.ConvertArrayToCompleteBinaryTree(new int?[] { 1, 2, 3, 4, 5, 6 }));
        }

        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftCount = root.left != null ? CountNodes(root.left) : 0;
            int rightCount = root.right != null ? CountNodes(root.right) : 0;

            return leftCount + rightCount + 1;
        }
    }
}

