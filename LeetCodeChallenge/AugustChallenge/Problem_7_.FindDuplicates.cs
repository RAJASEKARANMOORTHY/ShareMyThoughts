using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AugustChallenge
{
    [TestClass]
    public class Problem_7_FindDuplicates
    {
        //Find All Duplicates in an Array
        //Given an array of integers, 1 ≤ a[i] ≤ n(n = size of array), some elements appear twice and others appear once.

        //Find all the elements that appear twice in this array.

        //Could you do it without extra space and in O(n) runtime?


        //Example:
        //Input:
        //[4,3,2,7,8,2,3,1]

        //Output:
        //[2,3]

        [TestMethod]
        public void FindDuplicates()
        {
            // No negative values.
            var result = FindDuplicates(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });  // 2,3 
        }

        public IList<int> FindDuplicates(int[] nums)
        {
            var output = new List<int>();

            foreach (var number in nums)
            {
                int absValue = Math.Abs(number);

                if (nums[absValue - 1] > 0)
                {
                    nums[absValue - 1] *= -1;
                }
                else
                {
                    output.Add(absValue);
                }
            }

            return output;
        }
    }
}
