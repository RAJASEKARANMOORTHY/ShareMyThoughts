using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MayChallenge
{
    [TestClass]
    public class PRoblem_4_FindComplement
    {
        // 476. Number Complement [https://leetcode.com/problems/number-complement/]
        //Given a positive integer, output its complement number.The complement strategy is to flip the bits of its binary representation.

        //Example 1:

        //Input: 5
        //Output: 2
        //Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.

        //Example 2:

        //Input: 1
        //Output: 0
        //Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.

        //Note:

        //The given integer is guaranteed to fit within the range of a 32-bit signed integer.
        //You could assume no leading zero bit in the integer’s binary representation.
        //This question is the same as 1009: https://leetcode.com/problems/complement-of-base-10-integer/

        [TestMethod]
        public void FindComplement()
        {
            var result_1 = FindComplement_BackwardTrace_ByteArray(5);
            var result_2 = FindComplement(1);
        }

        public int FindComplement(int num)
        {
            if (num == 0)
                return 1;

            int rightShift = num;
            int baseValue = 1;

            while (rightShift > 0)
            {
                num ^= baseValue;
                baseValue <<= 1; // 1->10->100->1000
                rightShift >>= 1; // 100 -> 10 -> 1 -> 0
            }

            return num;
        }
        public int FindComplement_CharArray(int num)
        {
            var binaries = ConvertToBinaryCharArray(num);
            int total = 0;

            foreach (char binary in binaries)
                total = total * 2 + (binary - '0' == 0 ? 1 : 0);

            return total;
        }

        public int FindComplement_LinkedList(int num)
        {
            if (num == 0)
                return 1;

            var binaries = ConvertToBinaryLinkedList(num);
            int total = 0;
            var node = binaries.First;

            while (node != null)
            {
                total = total * 2 + (node.Value == 0 ? 1 : 0);
                node = node.Next;
            }
            return total;
        }

        public int FindComplement_ForwardTrace_ByteArray(int num)
        {
            if (num == 0)
                return 1;

            var binaries = ConvertToBinaryByteArray(num);
            int total = 0;

            foreach (byte binary in binaries)
                total = total * 2 + (binary == 0 ? 1 : 0);

            return total;
        }

        public int FindComplement_BackwardTrace_ByteArray(int num)
        {
            if (num == 0)
                return 1;

            var binaries = ConvertToBinaryByteArray(num);
            int total = 0;
            int length = binaries.Length - 1;

            for (int index = length; index >= 0; index--)
                total = total +(binaries[index] == 0 ? 1 : 0) * (1 << length - index);

            return total;
        }

        public char[] ConvertToBinaryCharArray(int number)
        {
            return Convert.ToString(number, 2).ToCharArray();
        }

        public LinkedList<byte> ConvertToBinaryLinkedList(int number)
        {
            LinkedList<byte> binaries = new LinkedList<byte>();
            byte baseNumber = 2;
            while (number > baseNumber - 1)
            {
                binaries.AddFirst((byte)(number % baseNumber));
                number = number / baseNumber;
            }

            if (number > 0)
                binaries.AddFirst((byte)number);

            return binaries;
        }

        public byte[] ConvertToBinaryByteArray(int number)
        {
            List<byte> binaries = new List<byte>();
            byte baseNumber = 2;
            while (number > baseNumber - 1)
            {
                binaries.Insert(0, (byte)(number % baseNumber));
                number = number / baseNumber;
            }

            if (number > 0)
                binaries.Insert(0, (byte)number);

            return binaries.ToArray();
        }
    }
}
