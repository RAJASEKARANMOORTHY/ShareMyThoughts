using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AugustChallenge
{

    //Path Sum III

    //You are given a binary tree in which each node contains an integer value.

    //Find the number of paths that sum to a given value.

    //The path does not need to start or end at the root or a leaf, but it must go downwards(traveling only from parent nodes to child nodes).

    //The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.

    //Example:

    //root = [10,5,-3,3,2,null,11,3,-2,null,1], sum = 8

    //      10
    //     /  \
    //    5   -3
    //   / \    \
    //  3   2   11
    // / \   \
    //3  -2   1

    //Return 3. The paths that sum to 8 are:

    //1.  5 -> 3
    //2.  5 -> 2 -> 1
    //3. -3 -> 11

    [TestClass]
    public class Problem_9_PathSum
    {
        int targetSum = 0;
        int noOfPath = 0;
        Dictionary<int, int> hashMap = new Dictionary<int, int>();

        private int HashGetOrDefault(int key)
        {
            hashMap.TryGetValue(key, out int value);
            return value;
        }

        private void HashPut(int key, int count)
        {
            if (hashMap.ContainsKey(key))
            {
                hashMap[key] += count;
            }
            else
            {
                hashMap.Add(key, count);
            }
        }

        [TestMethod]
        public void PathSum()
        {
            var result_1 = PathSum(TreeNodeUtility.ConvertArrayToCompleteBinaryTree(new int?[] { 10, 5, -3, 3, 2, null, 11, 3, -2, null, 1 }), 8); // 
        }

        public void PreorderPathSum(TreeNode node, int currentSum)
        {
            if (node == null)
                return;

            currentSum += node.val;

            if (currentSum == targetSum)
            {
                noOfPath += 1;
            }

            noOfPath += HashGetOrDefault(currentSum - targetSum);
            HashPut(currentSum, 1);

            PreorderPathSum(node.left, currentSum);
            PreorderPathSum(node.right, currentSum);
            HashPut(currentSum, -1);
        }

        public int PathSum(TreeNode root, int sum)
        {
            targetSum = sum;

            PreorderPathSum(root, 0);
            return noOfPath;
        }
    }
}
