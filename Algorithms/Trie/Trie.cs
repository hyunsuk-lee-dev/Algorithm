using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    public class Trie
    {
        const int ALPHABETS = 26;

        int IndexOf(char c)
        {
            return char.ToUpper(c) - 'A';
        }

        private bool isTerminal;
        private Trie[] children;
        
        public Trie(bool isTerminal = false)
        {
            this.isTerminal = isTerminal;
            children = new Trie[ALPHABETS];
        }

        public void Insert(string key)
        {
            if(string.IsNullOrEmpty(key))
                isTerminal = true;
            else
            {
                int index = IndexOf(key[0]);
                if(children[index] == null)
                    children[index] = new Trie();

                children[index].Insert(key.Substring(1));
            }
        }

        public Trie Find(string key)
        {
            if(string.IsNullOrEmpty(key))
                return this;

            int index = IndexOf(key[0]);

            if(children[index] == null)
                return null;

            return children[index].Find(key.Substring(1));
        }

        public Trie ExactFind(string key)
        {
            if(string.IsNullOrEmpty(key))
                return isTerminal ? this : null;

            int index = IndexOf(key[0]);

            if(children[index] == null)
                return null;

            return children[index].ExactFind(key.Substring(1));
        }
    }
}
