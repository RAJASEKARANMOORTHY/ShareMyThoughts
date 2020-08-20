using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge.DataStructure
{

    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static class TreeNodeUtility
    {
        //public static TreeNode ConvertArrayToBinaryTree(int?[] array)
        //{
        //    TreeNode[] nodes = new TreeNode[array.Length];

        //    for (int index = 0; index < array.Length; index++)
        //    {
        //        if (array[index] != null)
        //            nodes[index] = new TreeNode(val: array[index].Value);
        //    }
        //    var queue = new Queue<TreeNode>();
        //    queue.Enqueue(nodes[0]);
        //    int level = 0;

        //    while (queue.Count > 0)
        //    {
        //        int count = queue.Count;
        //        int childNodes = (int)Math.Pow(2, level);

        //        while (count > 0)
        //        {
        //            var current = queue.Dequeue();

        //        }

        //        level += 1;
        //    }

        //    return nodes[0];
        //}
        public static TreeNode ConvertArrayToCompleteBinaryTree(int?[] array)
        {
            TreeNode[] nodes = new TreeNode[array.Length];

            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] != null)
                    nodes[index] = new TreeNode(val: array[index].Value);
            }

            for (int rootIndex = array.Length / 2; rootIndex >= 0; rootIndex--)
            {
                var root = nodes[rootIndex];

                if (root != null)
                {
                    int leftIndex = rootIndex * 2 + 1;
                    int rightIndex = rootIndex * 2 + 2;

                    if (leftIndex >= 0 && leftIndex < array.Length && nodes[leftIndex] != null)
                    {
                        root.left = nodes[leftIndex];
                    }

                    if (rightIndex >= 0 && rightIndex < array.Length && nodes[rightIndex] != null)
                    {
                        root.right = nodes[rightIndex];
                    }
                }
            }


            return nodes[0];
        }

        public static TreeNode ConvertArrayToDegenerateTree(int[] array, bool isLeft)
        {
            var root = new TreeNode(array[0]);
            var node = root;

            for (int index = 1; index < array.Length; index++)
            {
                if (isLeft)
                {
                    node.left = new TreeNode(array[index]);
                    node = node.left;
                }
                else
                {
                    node.right = new TreeNode(array[index]);
                    node = node.right;
                }
            }

            return root;
        }

        public static TreeNode ConvertArrayToPerfectBinaryTree(int height)
        {
            int noOfNodes = (int)Math.Pow(2, height) - 1;

            int?[] nodes = new int?[noOfNodes];

            for (int index = 0; index < noOfNodes; index++)
            {
                nodes[index] = index + 1;
            }

            return ConvertArrayToCompleteBinaryTree(nodes);
        }
    }
}

