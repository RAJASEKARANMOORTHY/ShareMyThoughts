using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AugustChallenge
{
    [TestClass]
    public class Problem_5_IsPowerOfFour
    {
        //Power of Four

        //Solution
        //Given an integer(signed 32 bits), write a function to check whether it is a power of 4.

        //Example 1:

        //Input: 16
        //Output: true
        //Example 2:

        //Input: 5
        //Output: false
        //Follow up: Could you solve it without loops/recursion?

        [TestMethod]
        public void IsPowerOfTwo()
        {
            var result_1 = IsPowerOfTwo(4); // True
            var result_2 = IsPowerOfTwo(8); // True
            var result_3 = IsPowerOfTwo(16); // True
            var result_4 = IsPowerOfTwo(32); // True
        }

        public bool IsPowerOfTwo(int num)
        {
            return (num & num - 1) == 0;

            // Example 16 & 16 - 1 => 16 & 15 => Binary Format 1000 &  0111 => 0
            // Hence its power of two
        }

        [TestMethod]
        public void IsPowerOfFour()
        {
            var result_1 = IsPowerOfFour(16); // True
            var result_2 = IsPowerOfFour(5); // False
            var result_3 = IsPowerOfFour(1); // True
            var result_4 = IsPowerOfFour(4); // True
        }


        public bool IsPowerOfFour(int num)
        {
            return IsPowerOfTwo(num) && (num % 3) == 1;
        }

        public bool IsPowerOfFour_Log4OfN(int num)
        {
            if (num < 1)
                return false;

            int n = num, count = 0;

            while(num > 1)
            {
                num >>= 2;
                count += 2;
            }

            return (n << count) == num;
        }
    }
}
