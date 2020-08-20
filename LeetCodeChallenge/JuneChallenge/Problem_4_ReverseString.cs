using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace JuneChallenge
{
    [TestClass]
    public class Problem_5_ReverseString
    {

        // Reverse String [https://leetcode.com/problems/reverse-string/]
        //Write a function that reverses a string. The input string is given as an array of characters char[].
        //Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.

        //You may assume all the characters consist of printable ascii characters.

        //Example 1:

        //Input: ["h","e","l","l","o"]
        //Output: ["o","l","l","e","h"]
        //Example 2:

        //Input: ["H","a","n","n","a","h"]
        //Output: ["h","a","n","n","a","H"]

        [TestMethod]
        public void ReverseString()
        {
            //ReverseString("Hello".ToCharArray());
            ReverseString("Hello Rajasekaran".ToCharArray());
        }

        public void ReverseString(char[] s)
        {
            int start = 0, end = s.Length - 1;

            while (start < end - start)
            {
                var temp = s[start];
                s[start] = s[end - start];
                s[end - start] = temp;
                start++;
            }
        }
    }
}
