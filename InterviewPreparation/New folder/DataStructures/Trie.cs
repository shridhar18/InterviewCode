using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.DataStructures
{
    class Trie
    {
        public TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        } 

        public void insert(string s)
        {
            char[] chars = s.ToArray<char>();
            TrieNode tr = this.root;

            int i = 0;
            while (tr.children.ContainsKey(chars[i]))
            {
                if (i == chars.Length - 1)
                {
                    tr.children[chars[i++]].isCompleteWord = true;
                    break;
                }
                tr = tr.children[chars[i++]];
            }


            while (i < chars.Length)
            {
                //TrieNode tn = new TrieNode();
                tr.children[chars[i]] = new TrieNode();
                tr.children[chars[i]].isCompleteWord = i == chars.Length-1;

                //tr.children[chars[i++]] = tn;

                tr = tr.children[chars[i++]];
            }
        }
    }

    class TrieNode
    {
        public Dictionary<char, TrieNode> children;
        public bool isCompleteWord;

        public TrieNode()
        {
            this.children = new Dictionary<char, TrieNode>();
            this.isCompleteWord = false;
        }

        public TrieNode(char c, TrieNode t, bool complete)
        {
            this.children = new Dictionary<char, TrieNode>();
            this.children[c] = t;
            this.isCompleteWord = complete;
        }
    }
}
