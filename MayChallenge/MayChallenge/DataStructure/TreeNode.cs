using System;
using System.Collections.Generic;
using System.Text;

namespace MayChallenge.DataStructure
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

    internal class TreeNodeTest
    {
        public TreeNode ConvertArrayToBinary(int?[] array)
        {
            TreeNode[] nodes = new TreeNode[array.Length];

            for(int index = 0; index< array.Length; index++)
            {
                if(array[index] != null)
                    nodes[index] = new TreeNode(val: array[index].Value);
            }

            for(int rootIndex = array.Length / 2; rootIndex >= 0; rootIndex--) {
                var root = nodes[rootIndex];
                int leftIndex = rootIndex * 2 + 1;
                int rightIndex = rootIndex * 2 + 2;

                if(root != null)
                {
                    if(leftIndex >=0 && leftIndex < array.Length && nodes[leftIndex] != null)
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
    }

}

