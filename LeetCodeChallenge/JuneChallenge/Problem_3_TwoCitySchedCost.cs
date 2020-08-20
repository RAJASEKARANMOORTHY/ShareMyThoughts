using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JuneChallenge
{
    [TestClass]
    public class Problem_3_TwoCitySchedCost
    {

        //Two City Scheduling [https://leetcode.com/problems/two-city-scheduling/]
        //There are 2N people a company is planning to interview.The cost of flying the i-th person to city A is costs[i][0], and the cost of flying the i-th person to city B is costs[i][1].

        //Return the minimum cost to fly every person to a city such that exactly N people arrive in each city.

        //Example 1:

        //Input: [[10,20], [30,200], [400,50], [30,20]]
        //Output: 110
        //Explanation: 
        //The first person goes to city A for a cost of 10.
        //The second person goes to city A for a cost of 30.
        //The third person goes to city B for a cost of 50.
        //The fourth person goes to city B for a cost of 20.

        //The total minimum cost is 10 + 30 + 50 + 20 = 110 to have half the people interviewing in each city.

        //Note:

        //1 <= costs.length <= 100
        //It is guaranteed that costs.length is even.
        //1 <= costs[i][0], costs[i][1] <= 1000

        [TestMethod]
        public void TwoCitySchedCost()
        {
            var costs_1 = new int[][]
            {
                new[]{10, 20 },
                new[]{30, 200 },
                new[]{400, 50 },
                new[]{30, 20 }
            };

            var totalCost = TwoCitySchedCost(costs_1);
        }

        public int TwoCitySchedCost(int[][] costs)
        {
            // Sort the two dimensional array
            Array.Sort(costs, (x, y) => (x[0] - x[1]) - (y[0] - y[1]));
            int noOfPeople = costs.Length / 2;
            int totalCost = 0;

            for (int index = 0; index < noOfPeople; index++)
                totalCost += costs[index][0];

            for (int index = noOfPeople; index < costs.Length; index++)
                totalCost += costs[index][1];

            return totalCost;
        }
    }
}
