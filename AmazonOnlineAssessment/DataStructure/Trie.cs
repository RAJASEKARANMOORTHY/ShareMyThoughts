using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonOnlineAssessment.DataStructure
{
    public class TrieNode
    {
        public TrieNode[] Childrens { get; }
        public HashSet<string> Set { get; }
        public bool Isword { get; set; }

        public TrieNode()
        {
            Childrens = new TrieNode[26];
            Set = new HashSet<string>();
            Isword = false;
        }
    }

    public class Trie
    {
        private TrieNode Root { get; }        

        public Trie()
        {
            Root = new TrieNode();
        }

        public void Insert(IEnumerable<string> words)
        {
            foreach(string word in words)
            {
                TrieNode root = this.Root;

                foreach(char letter in word)
                {
                    int childrenIndex = letter - 'a';

                    if(root.Childrens[childrenIndex] == null)
                        root.Childrens[childrenIndex] = new TrieNode();

                    root = root.Childrens[childrenIndex];
                    root.Set.Add(word);
                }

                root.Isword = true;
            }
        }
    }
}
