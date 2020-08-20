using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JuneChallenge
{
    [TestClass]
    public class Problem_6_ReconstructQueue
    {

        // Queue Reconstruction by Height [https://leetcode.com/problems/queue-reconstruction-by-height/]
        //Suppose you have a random list of people standing in a queue.Each person is described by a pair of integers (h, k), where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h.Write an algorithm to reconstruct the queue.

        //Note:
        //The number of people is less than 1,100.
        //Example

        //Input:
        //[[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]

        //Output:
        //[[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]

        [TestMethod]
        public void ReconstructQueue()
        {
            var output = ReconstructQueue(new int[][] {
                new int[] { 7, 0 },
                new int[] { 4, 4 },
                new int[] { 7, 1 },
                new int[] { 5, 0 },
                new int[] { 6, 1 },
                new int[] { 5, 2 }
            });

        }

        public int[][] ReconstructQueue(int[][] people)
        {
            Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();

            for (int index = 0; index < people.Length; index++)
            {
                if (keyValuePairs.ContainsKey(people[index][1]))
                    keyValuePairs[people[index][1]].Add(people[index][0]);
                else
                    keyValuePairs[people[index][1]] = new List<int> { people[index][0] };
            }

            List<int[]> lst = new List<int[]>();
            int total = 0;

            for (int index = 0; index < people.Length; index++)
            {
                if (keyValuePairs.ContainsKey(total))
                {
                    foreach (var height in keyValuePairs[total])
                        lst.Add(new int[] { height, total });

                    int size = keyValuePairs[total].Count;
                    keyValuePairs.Remove(total);
                    total += size;
                }
                else if (keyValuePairs.ContainsKey(1))
                {
                    total = 1;

                    foreach (var height in keyValuePairs[total])
                        lst.Add(new int[] { height, total });

                    int size = keyValuePairs[total].Count;
                    keyValuePairs.Remove(total);
                    total += size;
                }
            }

            return lst.ToArray();
        }
    }
}
