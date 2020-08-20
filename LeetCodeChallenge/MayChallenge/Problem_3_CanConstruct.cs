using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MayChallenge
{
    [TestClass]
    public class Problem_3_CanConstruct
    {
        //Ransom Note [ https://leetcode.com/problems/ransom-note/ ]

        //Given an arbitrary ransom note string and another string containing letters from all the magazines, write a function that will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false.

        //Each letter in the magazine string can only be used once in your ransom note.

        //Note:
        //You may assume that both strings contain only lowercase letters.

        //CanConstruct("a", "b") -> false
        //CanConstruct("aa", "ab") -> false
        //CanConstruct("aa", "aab") -> true

        [TestMethod]
        public void CanConstruct()
        {
            //var result_1 = CanConstruct("a", "b"); // false
            //var result_2 = CanConstruct("aa", "ab"); // false
            var result_3 = CanConstruct("aa", "aab"); //-> true
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            foreach (char note in ransomNote)
            {
                int index = magazine.IndexOf(note);

                if (index == -1)
                    return false;

                magazine = magazine.Substring(0, index) + magazine.Substring(index + 1);
            }

            return true;
        }

        // One Hash Map
        public bool CanConstruct_OneHashMap(string ransomNote, string magazine)
        {
            Dictionary<char, int> magazines = new Dictionary<char, int>();

            foreach (char mgz in magazine)
            {
                if (magazines.ContainsKey(mgz))
                    magazines[mgz] += 1;
                else
                    magazines[mgz] = 1;
            }

            foreach (char note in ransomNote)
            {
                if (magazines.ContainsKey(note) && magazines[note] > 0)
                    magazines[note] -= 1;
                else
                    return false;
            }
            return true;
        }
    }


}
