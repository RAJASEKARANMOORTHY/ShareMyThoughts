using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JuneChallenge
{
    [TestClass]
    public class Problem_1_InvertTree
    {

        //Invert Binary Tree [https://leetcode.com/problems/invert-binary-tree/]
        //Example:

        //Input:

        //     4
        //   /   \
        //  2     7
        // / \   / \
        //1   3 6   9
        //Output:

        //     4
        //   /   \
        //  7     2
        // / \   / \
        //9   6 3   1
        //Trivia:
        //This problem was inspired by this original tweet by Max Howell:

        [TestMethod]
        public void InvertTree()
        {
            var result1 = InvertTree(TreeNodeUtility.ConvertArrayToCompleteBinaryTree(new int?[] { 4, 2, 7, 1, 3, 6, 9 }));
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return root;

            var leftSubTree = root.left != null ? InvertTree(root.left) : null;
            var rightSubTree = root.right != null ? InvertTree(root.right) : null;

            root.left = rightSubTree;
            root.right = leftSubTree;

            return root;
        }
    }
}
