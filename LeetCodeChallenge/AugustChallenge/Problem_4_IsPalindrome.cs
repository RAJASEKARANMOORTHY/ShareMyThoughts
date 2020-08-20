using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AugustChallenge
{
    //Valid Palindrome

    //Solution
    //Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

    //Note: For the purpose of this problem, we define empty string as valid palindrome.

    //Example 1:

    //Input: "A man, a plan, a canal: Panama"
    //Output: true
    //Example 2:

    //Input: "race a car"
    //Output: false

    //Constraints: s consists only of printable ASCII characters.

    [TestClass]
    public class Problem_4_IsPalindrome
    {
        [TestMethod]
        public void IsPalindrome()
        {
            var result_1 = IsPalindrome("A man, a plan, a canal: Panama"); // True
            var result_2 = IsPalindrome("race a car"); // False
        }


        public bool IsPalindrome(string s)
        {
            Func<char, bool> IsUpper = (chr) => chr >= 'A' && chr <= 'Z'; // >= 65 && <= 90
            Func<char, bool> IsLower = (chr) => chr >= 'a' && chr <= 'z'; // >= 97 && <= 122
            Func<char, bool> IsNumeric = (chr) => chr >= '0' && chr <= '9'; 

            Func<char, bool> IsAlphabets = (chr) => IsUpper(chr) || IsLower(chr) || IsNumeric(chr);

            Func<char, char> ToLower = (chr) => IsUpper(chr) ? ((char)(chr + 32)) : chr;
            Func<char, char> ToUpper = (chr) => IsLower(chr) ? ((char)(chr - 32)) : chr;

            int start = 0, end = s.Length - 1;

            while (start <= end)
            {
                while (start <= end && !IsAlphabets(s[start]))
                {
                    start++;
                }

                while (start <= end && !IsAlphabets(s[end]))
                {
                    end--;
                }

                if (start <= end && ToLower(s[start]) != ToLower(s[end]))
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }
    }
}
