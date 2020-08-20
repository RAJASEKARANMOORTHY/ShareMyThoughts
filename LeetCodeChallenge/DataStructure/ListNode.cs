using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge.DataStructure
{
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public static class ListNodeUtility
    {
        public static ListNode ConvertArrayToLinkedList(int[] array)
        {
            var head = new ListNode(array[0]);
            var previous = head;
            for (int index = 1; index < array.Length; index++)
            {
                previous.next = new ListNode(array[index]);
                previous = previous.next;
            }

            return head;
        }

        public static ListNode FindByIndex(this ListNode head, int index)
        {
            int counter = 0;
            var node = head;
            while (counter != index)
            {
                node = node.next;
                counter++;
            }

            return node;
        }
    }
}
