using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;
using AmazonOnlineAssessment.DataStructure;

namespace AmazonOnlineAssessment
{
    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void MaxPriority_PriorityQueue_Array_Test()
        {
            PriorityQueue<QueueItem> priorityQueue = new PriorityQueue<QueueItem>();

            priorityQueue.Enqueue(new QueueItem(new int[] { 2, 3, 4 }, 1));
            priorityQueue.Enqueue(new QueueItem(new int[] { 4, 5, 6 }, 2));
            priorityQueue.Enqueue(new QueueItem(new int[] { 7, 8, 9 }, 1));
            priorityQueue.Enqueue(new QueueItem(new int[] { 10, 11, 12 }, 3));

            var first = priorityQueue.Dequeue().Value;
            var second = priorityQueue.Dequeue().Value;
            var third = priorityQueue.Dequeue().Value;
            var four = priorityQueue.Dequeue().Value;

            var blank = priorityQueue.Dequeue()?.Value;
        }

        [TestMethod]
        public void MaxPriority_PriorityQueue_String_Test()
        {
            PriorityQueue<QueueItem> priorityQueue = new PriorityQueue<QueueItem>();

            priorityQueue.Enqueue(new QueueItem("Apple", 1));
            priorityQueue.Enqueue(new QueueItem("Microsoft", 2));
            priorityQueue.Enqueue(new QueueItem("Starbuck", 1));
            priorityQueue.Enqueue(new QueueItem("Amazon", 3));

            var first = priorityQueue.Dequeue().Value;
            var second = priorityQueue.Dequeue().Value;
            var third = priorityQueue.Dequeue().Value;
            var four = priorityQueue.Dequeue().Value;

            var blank = priorityQueue.Dequeue()?.Value;
        }

        [TestMethod]
        public void MinPriority_PriorityQueue_Array_Test()
        {
            PriorityQueue<QueueItem> priorityQueue = new PriorityQueue<QueueItem>(true);

            priorityQueue.Enqueue(new QueueItem(new int[] { 2, 3, 4 }, 1));
            priorityQueue.Enqueue(new QueueItem(new int[] { 4, 5, 6 }, 2));
            priorityQueue.Enqueue(new QueueItem(new int[] { 7, 8, 9 }, 1));
            priorityQueue.Enqueue(new QueueItem(new int[] { 10, 11, 12 }, 3));

            var first = priorityQueue.Dequeue().Value;
            var second = priorityQueue.Dequeue().Value;
            var third = priorityQueue.Dequeue().Value;
            var four = priorityQueue.Dequeue().Value;

            var blank = priorityQueue.Dequeue()?.Value;
        }

        [TestMethod]
        public void MinPriority_PriorityQueue_String_Test()
        {
            PriorityQueue<QueueItem> priorityQueue = new PriorityQueue<QueueItem>(true);

            priorityQueue.Enqueue(new QueueItem("Apple", 1));
            priorityQueue.Enqueue(new QueueItem("Microsoft", 2));
            priorityQueue.Enqueue(new QueueItem("Starbuck", 1));
            priorityQueue.Enqueue(new QueueItem("Amazon", 3));

            var first = priorityQueue.Dequeue().Value;
            var second = priorityQueue.Dequeue().Value;
            var third = priorityQueue.Dequeue().Value;
            var four = priorityQueue.Dequeue().Value;

            var blank = priorityQueue.Dequeue()?.Value;
        }
    }
}

