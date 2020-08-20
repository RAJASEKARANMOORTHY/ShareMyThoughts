using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeChallenge.DataStructure.Utility
{
    public static class CharacterUtilty
    {
        private static int Difference = 'a' - 'A';

        public static Func<char, bool> IsNumber = (chr) => chr >= '0' && chr <= '9';

        public static Func<char, bool> IsLower = (chr) => chr >= 'a' && chr <= 'z';

        public static Func<char, bool> IsUpper = (chr) => chr >= 'A' && chr <= 'Z';

        public static Func<char, bool> IsAphabets = (chr) => IsLower(chr) && IsUpper(chr);

        public static Func<char, char> ToLower = (chr) => IsUpper(chr) ? (char)(chr + Difference) : chr;

        public static Func<char, char> ToUpper = (chr) => IsLower(chr) ? (char)(chr - Difference) : chr;

        public static Func<char, bool, int> AlphabetIndex = (chr, isLower) => chr - (isLower ? 'a': 'A');
    }
}
