using LeetCodeChallenge.DataStructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace LeetCodeChallenge.DataStructure
{
    public class Trie
    {
        private TrieNode Root;

        public Trie()
        {
            Root = new TrieNode();
        }

        public void Insert(string word)
        {
            var root = Root;
            int startIndex = 0;

            while (startIndex < word.Length)
            {
                var chr = word[startIndex];

                root.Set.Add(word);
                int rootIndex = CharacterUtilty.AlphabetIndex(chr, true);
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

        public bool Contains(string word)
        {
            var root = Root;
            int startIndex = 0;

            while (startIndex < word.Length)
            {
                var chr = word[startIndex];
                int rootIndex = CharacterUtilty.AlphabetIndex(word[startIndex], true);
                var currentRoot = root.Root[rootIndex];

                if (currentRoot == null)
                {
                    return false;
                }
                root = currentRoot;
                startIndex++;
            }

            return root != null && root.IsWord;
        }
    }

    public class TrieNode
    {
        public HashSet<string> Set { get; set; }

        public TrieNode[] Root { get; set; }

        public bool IsWord { get; set; }

        public TrieNode()
        {
            Set = new HashSet<string>();
            Root = new TrieNode[26];
        }
    }
}
