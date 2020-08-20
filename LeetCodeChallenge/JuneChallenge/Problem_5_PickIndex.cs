using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JuneChallenge
{
    [TestClass]
    public class Problem_5_PickIndex
    {

        // 528. Random Pick with Weight [https://leetcode.com/problems/random-pick-with-weight/]
        //Given an array w of positive integers, where w[i] describes the weight of index i, write a function pickIndex which randomly picks an index in proportion to its weight.

        //For example, given an input list of values [1, 9], when we pick up a number out of it, the chance is that 9 times out of 10 we should pick the number 9 as the answer.
        //Example 1:

        //Input: 
        //["Solution","pickIndex"]
        //[[[1]],[]]
        //Output: [null,0]
        //        Example 2:

        //Input: 
        //["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
        //        [[[1,3]],[],[],[],[],[]]
        //Output: [null,0,1,1,1,0]
        //        Explanation of Input Syntax:

        //The input is two lists: the subroutines called and their arguments.Solution's constructor has one argument, the array w. pickIndex has no arguments. Arguments are always wrapped with a list, even if there aren't any.

        //Constraints:

        //1 <= w.length <= 10000
        //1 <= w[i] <= 10^5
        //pickIndex will be called at most 10000 times.


        [TestMethod]
        public void PickIndex()
        {
            //var instance = new RandomPickWithWeight(new int[] { 1, 3, 4, 5, 2 });
            //var p1 = instance.PickIndex();
            //var p2 = instance.PickIndex();
            //var p3 = instance.PickIndex();
            //var p4 = instance.PickIndex();

            var instance_1 = new RandomPickWithWeight(new int[] { 1 });
            var p_1 = instance_1.PickIndex();
        }
    }

    public class RandomPickWithWeight
    {
        private int[] _cumulativeSum;
        private int _sum;
        private Random _random;

        public RandomPickWithWeight(int[] w)
        {
            _random = new Random();
            _cumulativeSum = new int[w.Length];

            for (int index = 0; index < w.Length; index++)
            {
                _sum += w[index];
                _cumulativeSum[index] = _sum;
            }
        }

        public int PickIndex()
        {
            int randomNumber = (_random.Next() % _sum) + 1;
            int start = 0, end = _cumulativeSum.Length - 1;
            int middle = 0;

            while (start < end)
            {
                middle = start + ((end - start) / 2);

                if (_cumulativeSum[middle] < randomNumber)
                    start = middle + 1;
                else
                    end = middle;
            }

            return start;
        }
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */
