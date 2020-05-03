using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MayChallenge
{
    [TestClass]
    public class clsNumJewelsInStones
    {
        //Jewels and Stones

        //You're given strings J representing the types of stones that are jewels, and S representing the stones you have.  Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.

        //The letters in J are guaranteed distinct, and all characters in J and S are letters.Letters are case sensitive, so "a" is considered a different type of stone from "A".

        //Example 1:

        //Input: J = "aA", S = "aAAbbbb"
        //Output: 3
        //Example 2:

        //Input: J = "z", S = "ZZ"
        //Output: 0
        //Note:

        //S and J will consist of letters and have length at most 50.
        //The characters in J are distinct.

        [TestMethod]
        public void NumJewelsInStones()
        {
            var result_1 = NumJewelsInStones("aA", "aAAbbbb");
            var result_2 = NumJewelsInStones("z", "ZZ");
        }

        public int NumJewelsInStones(string J, string S)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach(var chr in J)
            {
                if(!dictionary.ContainsKey(chr))
                    dictionary[chr] = 1;
            }
            int total = 0;

            foreach(var chr in S)
            {
                if (dictionary.ContainsKey(chr))
                    total += 1;
            }

            return total;
        }
    }
}
