using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AugustChallenge
{
    [TestClass]
    public class Problem_6_WordDictionary
    {
        [TestMethod]
        public void Test()
        {
            var trie = new WordDictionary();
            var output = new List<bool?>();

            //List<string[]> testData = new List<string[]>
            //{
            //    new string[] { "AddWord", "bad" },
            //    new string[] { "AddWord", "dad" },
            //    new string[] { "AddWord", "mad" },
            //    new string[] { "Search", "pad" },
            //    new string[] { "Search", "bad" },
            //    new string[] { "Search", ".ad" },
            //    new string[] { "Search", "b.." },
            //};

            var operation = new string[] { "WordDictionary", "addWord", "addWord", "search", "search", "search", "search", "search", "search" };
            var input = new string[] { "", "a", "a", ".", "a", "aa", "a", ".a", "a." };

            int startIndex = 0;

            while (startIndex < operation.Length)
            {
                switch (operation[startIndex])
                {
                    case "addWord":
                        trie.AddWord(input[startIndex]);
                        output.Add(null);
                        break;
                    case "search":
                        output.Add(trie.Search(input[startIndex]));
                        break;
                    default:
                        output.Add(null);
                        break;
                }

                startIndex++;
            }
        }
    }

    public class WordDictionary
    {
        private TrieNode Trie;

        private Func<char, bool, int> AlphabetIndex = (chr, isLower) => chr - (isLower ? 'a' : 'A');

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            Trie = new TrieNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            var root = Trie;
            int startIndex = 0;

            while (startIndex < word.Length)
            {
                var chr = word[startIndex];

                root.Set.Add(word);
                int rootIndex = AlphabetIndex(chr, true);
                var currentRoot = root.Root[rootIndex];

                if (currentRoot == null)
                {
                    currentRoot = new TrieNode();
                    root.Root[rootIndex] = currentRoot;
                }

                root = currentRoot;
                startIndex++;
            }

            root.Set.Add(word);
            root.IsWord = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return SearchInNode(word, Trie);
        }

        public bool SearchInNode(string word, TrieNode trieNode)
        {
            var root = trieNode;
            int startIndex = 0;

            while (startIndex < word.Length)
            {
                var chr = word[startIndex];

                if (chr == '.')
                {
                    int currentIndex = startIndex + 1;
                    int remainingLength = word.Length - currentIndex;
                    string currentWords = word.Substring(currentIndex, remainingLength);

                    if (string.IsNullOrWhiteSpace(currentWords))
                    {
                        return true;
                    }

                    foreach (var node in root.Root)
                    {
                        if (node != null && SearchInNode(currentWords, node))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    int rootIndex = AlphabetIndex(word[startIndex], true);
                    var currentRoot = root.Root[rootIndex];

                    if (currentRoot == null)
                    {
                        return false;
                    }
                    root = currentRoot;
                }

                startIndex++;
            }

            return root != null && root.IsWord;
        }
    }

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */
}

