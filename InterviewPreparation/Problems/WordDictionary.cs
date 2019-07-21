using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Problems
{
    public class WordDictionary
    {
        TrieNode root;
        /** Initialize your data structure here. */
        public WordDictionary()
        {
            this.root = new TrieNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            TrieNode node = this.root;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.children[word[i] - 'a'] == null)
                {
                    node.children[word[i] - 'a'] = new TrieNode();
                }

                node = node.children[word[i] - 'a'];
            }
            node.end = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return word.Length != 0 && this.match(word, 0, this.root);

        }

        bool match(string s, int l, TrieNode node)
        {
            if (l == s.Length - 1 && s[l] != '.')
                return node.children[s[l] - 'a'] != null && node.children[s[l] - 'a'].end;

            if (s[l] == '.')
            {
                bool x = false;
                for (int i = 0; i < 26; i++)
                {
                    if (node.children[i] != null)
                    {
                        x = x || l == s.Length - 1 || this.match(s, l + 1, node.children[i]);
                    }
                }

                return x;
            }
            
            
            if (node.children[s[l] - 'a'] != null)
            {
                return this.match(s, l + 1, node.children[s[l] - 'a']);
            }
            else
                return false;
        }
    }

    public class TrieNode 
    {
        public TrieNode[] children;
        public bool end;

        public TrieNode()
        {
            children = new TrieNode[26];
            end = false;
        }
    }
}
