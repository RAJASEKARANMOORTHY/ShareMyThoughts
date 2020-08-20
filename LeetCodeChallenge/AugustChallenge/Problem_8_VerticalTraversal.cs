﻿using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AugustChallenge
{

    //Vertical Order Traversal of a Binary Tree

    //Given a binary tree, return the vertical order traversal of its nodes values.

    //For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and(X+1, Y-1).

    //Running a vertical line from X = -infinity to X = +infinity, whenever the vertical line touches some nodes, we report the values of the nodes in order from top to bottom(decreasing Y coordinates).

    //If two nodes have the same position, then the value of the node that is reported first is the value that is smaller.

    //Return an list of non-empty reports in order of X coordinate.Every report will have a list of values of nodes.



    //Example 1:



    //Input: [3,9,20,null,null,15,7]
    //Output: [[9], [3,15], [20], [7]]
    //Explanation: 
    //Without loss of generality, we can assume the root node is at position(0, 0):
    //Then, the node with value 9 occurs at position(-1, -1);
    //    The nodes with values 3 and 15 occur at positions(0, 0) and(0, -2);
    //    The node with value 20 occurs at position(1, -1);
    //    The node with value 7 occurs at position(2, -2).
    //Example 2:



    //Input: [1,2,3,4,5,6,7]
    //    Output: [[4],[2],[1,5,6],[3],[7]]
    //Explanation: 
    //The node with value 5 and the node with value 6 have the same position according to the given scheme.
    //However, in the report "[1,5,6]", the node value of 5 comes first since 5 is smaller than 6.


    //Note:

    //The tree will have between 1 and 1000 nodes.
    //Each node's value will be between 0 and 1000.

    [TestClass]
    public class Problem_8_VerticalTraversal
    {
        [TestMethod]
        public void VerticalTraversal()
        {
            var result_1 = VerticalTraversal(TreeNodeUtility.ConvertArrayToCompleteBinaryTree(new int?[] { 3, 9, 20, null, null, 15, 7 })); // [[9],[3,15],[20],[7]]
            var result_2 = VerticalTraversal(TreeNodeUtility.ConvertArrayToCompleteBinaryTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 })); // [[4],[2],[1,5,6],[3],[7]]

            //TreeNodeUtility.ConvertArrayToBinaryTree(new int?[] { 0, 2, 1, 3, null, null, null, 4, 5, null, 7, 6, null, 10, 8, 11, 9 })

        }

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var queue = new Queue<(TreeNode node, int distance)>();
            var sortedDictionary = new SortedDictionary<int, List<int>>();

            var node = root;
            queue.Enqueue((node: node, distance: 0));
            IList<IList<int>> result = new List<IList<int>>();

            while (queue.Count > 0)
            {
                int size = queue.Count;
                int counter = 0;

                while (counter < size)
                {
                    var current = queue.Dequeue();

                    if (current.node.left != null)
                    {
                        queue.Enqueue((node: current.node.left, distance: current.distance - 1));
                    }

                    if (current.node.right != null)
                    {
                        queue.Enqueue((node: current.node.right, distance: current.distance + 1));
                    }

                    if (sortedDictionary.ContainsKey(current.distance))
                    {
                        sortedDictionary[current.distance].Add(current.node.val);
                    }
                    else
                    {
                        sortedDictionary[current.distance] = new List<int> { current.node.val };
                    }

                    counter++;
                }
            }

            foreach (var val in sortedDictionary)
            {
                val.Value.Sort();
                result.Add(val.Value);
            }

            return result;
        }
    }
}