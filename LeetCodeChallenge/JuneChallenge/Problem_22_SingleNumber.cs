using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JuneChallenge
{
    [TestClass]
    public class Problem_22_SingleNumber
    {
        //Single Number II
        //Given a non-empty array of integers, every element appears three times except for one, which appears exactly once.Find that single one.

        //Note:

        //Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

        //Example 1:
        //Input: [2,2,3,2]
        //Output: 3

        //Example 2:
        //Input: [0,1,0,1,0,1,99]
        //Output: 99

        [TestMethod]
        public void SingleNumber()
        {
            //var result_1 = SingleNumber(new int[] { 2, 2, 3, 2 });
            //var result_2 = SingleNumber(new int[] { 2, 2, 1, 2 });
            var result_3 = SingleNumber(new int[] { 0, 1, 0, 1, 0, 1, 99 });

            // Not sorted
            // 1 <= Length >= 4
        }

        public int SingleNumber(int[] nums)
        {
            Array.Sort(nums); // N Log N

            int start = 1;
            while (start < nums.Length - 2)
            {
                if (nums[start - 1] != nums[start])
                    return nums[start - 1];
                else if (nums[start] != nums[start + 1])
                    return nums[start + 1];
                else
                    start += 3;
            }

            return nums[start - 1];
        }
    }
}
