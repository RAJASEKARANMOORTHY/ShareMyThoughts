using AmazonOnlineAssessment.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonOnlineAssessment
{
    [TestClass]
    public class clsReorganizeString
    {
        //https://leetcode.com/problems/reorganize-string/submissions/

        //Given a string S, check if the letters can be rearranged so that two characters that are adjacent to each other are not the same.
        //If possible, output any possible result.If not possible, return the empty string.
        //Example 1:

        //Input: S = "aab"
        //Output: "aba"
        //Example 2:

        //Input: S = "aaab"
        //Output: ""
        //Note:

        //S will consist of lowercase letters and have length in range[1, 500].
        [TestMethod]
        public void ReorganizeString()
        {
            //var result_1 = ReorganizeString("aab");
            var result_2 = ReorganizeString("aaab");
            //var result_3 = ReorganizeString("vvvlo");
        }

        public string ReorganizeString(string S)
        {
            Dictionary<char, int> hashMap = new Dictionary<char, int>();

            foreach (var chr in S)
            {
                if (hashMap.ContainsKey(chr))
                {
                    hashMap[chr] += 1;
                }
                else
                {
                    hashMap[chr] = 1;
                }
            }

            // Max Heap
            PriorityQueue<QueueItem> priorityQueue = new PriorityQueue<QueueItem>();

            foreach (var itm in hashMap)
            {
                priorityQueue.Enqueue(new QueueItem(itm.Key, itm.Value));
            }

            string formattedString = string.Empty;
            QueueItem previousQueueItem = null;
            char previous = ' ';

            while (priorityQueue.Size > 0)
            {
                QueueItem queueItem = priorityQueue.Dequeue();
                var currentValue = (char)queueItem.Value;
                if (previous != currentValue)
                {
                    previous = currentValue;
                    formattedString += currentValue;
                    queueItem.Priority -= 1;
                    if (previousQueueItem != null && previousQueueItem.Priority > 0)
                    {
                        priorityQueue.Enqueue(previousQueueItem);
                    }
                    previousQueueItem = queueItem;
                }
                else
                {
                    formattedString = string.Empty;
                    break;
                }
            }

            return previousQueueItem.Priority > 0 ? "" :formattedString;
        }
    }
}
