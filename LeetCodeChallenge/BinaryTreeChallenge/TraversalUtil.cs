﻿using LeetCodeChallenge.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeChallenge
{
    public static class TraversalUtil
    {
        public static void PreOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                Console.Write($"{root.val}, ");
                PreOrderTraversal(root.left);
                PreOrderTraversal(root.right);
            }
        }

        public static void InOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                InOrderTraversal(root.left);
                Console.Write($"{root.val}, ");
                InOrderTraversal(root.right);
            }
        }

        public static void PostOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                PostOrderTraversal(root.left);
                PostOrderTraversal(root.right);
                Console.Write($"{root.val}, ");
            }
        }

        public static void LevelOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                List<TreeNode> queue = new List<TreeNode>();
                queue.Add(root);
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    while (count > 0)
                    {
                        TreeNode node = queue.ElementAt(0);
                        queue.RemoveAt(0);
                        Console.Write($"{node.val}, ");
                        if (node.left != null)
                        {
                            queue.Add(node.left);
                        }
                        if (node.right != null)
                        {
                            queue.Add(node.right);
                        }
                        count--;
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void InorderTraversalIterative(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode node = root;
                while ((node != null) || (stack.Count > 0))
                {
                    if (node != null)
                    {
                        stack.Push(node);
                        node = node.left;
                    }
                    else
                    {
                        node = stack.Pop();
                        Console.Write($"{node.val}, ");
                        node = node.right;
                    }
                }
            }
        }
        public static void PreorderTraversalIterative(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode node = root;
                while ((node != null) || (stack.Count > 0))
                {
                    if (node != null)
                    {
                        Console.Write($"{node.val}, ");
                        stack.Push(node);
                        node = node.left;
                    }
                    else
                    {
                        node = stack.Pop();
                        node = node.right;
                    }
                }
            }
        }

        public static void PostOrderTraversalIterative(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                Stack<TreeNode> stack1 = new Stack<TreeNode>();
                Stack<TreeNode> stack2 = new Stack<TreeNode>();
                TreeNode node = root;
                while ((node != null) || (stack1.Count > 0))
                {
                    if (node != null)
                    {
                        stack2.Push(node);
                        stack1.Push(node);
                        node = node.right;
                    }
                    else
                    {
                        node = stack1.Pop();
                        node = node.left;
                    }
                }
                while (stack2.Count > 0)
                {
                    TreeNode element = stack2.Pop();
                    Console.Write($"{element.val}, ");
                }
            }
        }
        class Obj
        {
            public TreeNode node;
            public int dis;
            public Obj(TreeNode node, int dis)
            {
                this.node = node;
                this.dis = dis;
            }
        }
        public static void VerticalOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                SortedDictionary<int, List<TreeNode>> disMap = new SortedDictionary<int, List<TreeNode>>();
                List<Obj> queue = new List<Obj>();
                queue.Add(new Obj(root, 0));
                while (queue.Count > 0)
                {
                    Obj ele = queue.ElementAt(0);
                    queue.RemoveAt(0);
                    if (disMap.ContainsKey(ele.dis))
                    {
                        disMap[ele.dis].Add(ele.node);
                    }
                    else
                    {
                        disMap[ele.dis] = new List<TreeNode>()
                        {
                            ele.node
                        };
                    }
                    if (ele.node.left != null)
                    {
                        queue.Add(new Obj(ele.node.left, ele.dis - 1));
                    }
                    if (ele.node.right != null)
                    {
                        queue.Add(new Obj(ele.node.right, ele.dis + 1));
                    }
                }
                foreach (int dis in disMap.Keys)
                {
                    List<TreeNode> nodeList = disMap[dis];
                    foreach (TreeNode n in nodeList)
                    {
                        Console.Write($"{n.val}, ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void TopViewOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                SortedDictionary<int, TreeNode> disMap = new SortedDictionary<int, TreeNode>();
                List<Obj> queue = new List<Obj>();
                queue.Add(new Obj(root, 0));
                while (queue.Count > 0)
                {
                    Obj ele = queue.ElementAt(0);
                    queue.RemoveAt(0);
                    if (!disMap.ContainsKey(ele.dis))
                    {
                        disMap[ele.dis] = ele.node;
                    }
                    if (ele.node.left != null)
                    {
                        queue.Add(new Obj(ele.node.left, ele.dis - 1));
                    }
                    if (ele.node.right != null)
                    {
                        queue.Add(new Obj(ele.node.right, ele.dis + 1));
                    }
                }
                foreach (int dis in disMap.Keys)
                {
                    Console.Write($"{disMap[dis].val}, ");
                }
            }
        }

        public static void BottomViewOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                SortedDictionary<int, TreeNode> disMap = new SortedDictionary<int, TreeNode>();
                List<Obj> queue = new List<Obj>();
                queue.Add(new Obj(root, 0));
                while (queue.Count > 0)
                {
                    Obj ele = queue.ElementAt(0);
                    queue.RemoveAt(0);
                    disMap[ele.dis] = ele.node;
                    if (ele.node.left != null)
                    {
                        queue.Add(new Obj(ele.node.left, ele.dis - 1));
                    }
                    if (ele.node.right != null)
                    {
                        queue.Add(new Obj(ele.node.right, ele.dis + 1));
                    }
                }
                foreach (int dis in disMap.Keys)
                {
                    Console.Write($"{disMap[dis].val}, ");
                }
            }
        }
        public static void LeftViewOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                List<TreeNode> queue = new List<TreeNode>();
                queue.Add(root);
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    int queueCount = queue.Count;
                    while (count > 0)
                    {
                        TreeNode node = queue.ElementAt(0);
                        queue.RemoveAt(0);
                        if (count == queueCount)
                        {
                            Console.Write($"{node.val}, ");
                        }

                        if (node.left != null)
                        {
                            queue.Add(node.left);
                        }
                        if (node.right != null)
                        {
                            queue.Add(node.right);
                        }
                        count--;
                    }
                    // Console.WriteLine();
                }
            }

        }

        public static void RightViewOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                List<TreeNode> queue = new List<TreeNode>();
                queue.Add(root);
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    int queueCount = queue.Count;
                    while (count > 0)
                    {
                        TreeNode node = queue.ElementAt(0);
                        queue.RemoveAt(0);
                        if (count == 1)
                        {
                            Console.Write($"{node.val}, ");
                        }

                        if (node.left != null)
                        {
                            queue.Add(node.left);
                        }
                        if (node.right != null)
                        {
                            queue.Add(node.right);
                        }
                        count--;
                    }
                    // Console.WriteLine();
                }
            }
        }

        public static void DiagonalTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                SortedDictionary<int, List<TreeNode>> disMap = new SortedDictionary<int, List<TreeNode>>();
                List<Obj> queue = new List<Obj>();
                queue.Add(new Obj(root, 0));
                while (queue.Count > 0)
                {
                    Obj ele = queue.ElementAt(0);
                    queue.RemoveAt(0);
                    if (disMap.ContainsKey(ele.dis))
                    {
                        disMap[ele.dis].Add(ele.node);
                    }
                    else
                    {
                        disMap[ele.dis] = new List<TreeNode>()
                        {
                            ele.node
                        };
                    }
                    if (ele.node.left != null)
                    {
                        queue.Add(new Obj(ele.node.left, ele.dis + 1));
                    }
                    if (ele.node.right != null)
                    {
                        queue.Add(new Obj(ele.node.right, ele.dis));
                    }
                }
                foreach (int dis in disMap.Keys)
                {
                    List<TreeNode> nodeList = disMap[dis];
                    foreach (TreeNode n in nodeList)
                    {
                        Console.Write($"{n.val}, ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public static void PrintLeftNodesExceptLeafNode(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else if ((root.left == null) && (root.right == null))
            {
                return;
            }
            else
            {
                Console.Write($"{root.val}, ");
                PrintLeftNodesExceptLeafNode(root.left);
            }
        }

        public static void PrintLeafOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else if ((root.left == null) && (root.right == null))
            {
                Console.Write($"{root.val}, ");
            }
            else
            {
                PrintLeafOfBinaryTree(root.left);
                PrintLeafOfBinaryTree(root.right);
            }
        }
        public static void PrintRightNodeExceptLeaf(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else if ((root.left == null) && (root.right == null))
            {
                return;
            }
            else
            {
                PrintRightNodeExceptLeaf(root.right);
                Console.Write($"{root.val}, ");
            }
        }
        public static void BoundaryTraversalOfBinaryTree(TreeNode root)
        {
            PrintLeftNodesExceptLeafNode(root);
            PrintLeafOfBinaryTree(root);
            PrintRightNodeExceptLeaf(root.right);
        }

        public static void SpiralLevelOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            else
            {
                Stack<TreeNode> stack1 = new Stack<TreeNode>();
                Stack<TreeNode> stack2 = new Stack<TreeNode>();
                stack1.Push(root);
                while ((stack1.Count > 0) || (stack2.Count > 0))
                {
                    while (stack1.Count > 0)
                    {
                        TreeNode node = stack1.Pop();
                        Console.Write($"{node.val}, ");
                        if (node.left != null)
                        {
                            stack2.Push(node.left);
                        }
                        if (node.right != null)
                        {
                            stack2.Push(node.right);
                        }

                    }
                    while (stack2.Count > 0)
                    {
                        TreeNode node = stack2.Pop();
                        Console.Write($"{node.val}, ");
                        if (node.right != null)
                        {
                            stack1.Push(node.right);
                        }
                        if (node.left != null)
                        {
                            stack1.Push(node.left);
                        }
                    }
                }
            }
        }
    }
}