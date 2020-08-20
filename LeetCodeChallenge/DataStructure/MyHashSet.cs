using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge.DataStructure
{
    public class MyHashSet
    {
        const int maxValue = 1000000;
        const int bucketSize = 1000;

        LinkedList<int>[] set;
        int capacity = 0;

        private int HashCode(int value)
        {
            return value / bucketSize;
        }

        /** Initialize your data structure here. */
        public MyHashSet()
        {
            this.set = new LinkedList<int>[HashCode(maxValue / bucketSize)];
        }

        public void Add(int key)
        {
            var bucketId = HashCode(key);
            var head = set[bucketId];

            if (head == null)
            {
                head = new LinkedList<int>();
                head.AddFirst(key);
                set[bucketId] = head;
            }
            else if (!head.Contains(key))
            {
                head.AddLast(key);
            }
        }

        public void Remove(int key)
        {
            var bucketId = HashCode(key);
            var head = set[bucketId];

            if (head != null)
            {
                head.Remove(key);
            }
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            var bucketId = HashCode(key);
            var head = set[bucketId];

            if (head != null)
            {
                return head.Contains(key);
            }

            return false;
        }
    }
}
