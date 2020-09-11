using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 
    /// Algorithm.Algorithms.Trie
    /// </summary>
    public class TrieTest
    {
        public static int Solution()
        {
            int answer = 0;

            Trie trie = new Trie();

            trie.Insert("Bee");
            trie.Insert("Best");
            trie.Insert("Bit");

            Console.WriteLine(trie.Find("Btt") != null);

            return answer;
        }
    }
}
