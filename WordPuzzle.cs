using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class WordPuzzle
    {
        public static int Solution(string[] strs, string t)
        {
            int infinite = 20001;
            int[] answers = new int[t.Length];

            for(int i = 0 ; i < answers.Length ; i++)
                answers[i] = infinite;

            for(int i = 0 ; i < t.Length ; i++)
            {
                for(int j = 1 ; j <= Math.Min(5, i + 1) ; j++)
                {
                    if(strs.Contains(t.Substring(t.Length - i - 1, j)))
                        answers[i] = Math.Min(answers[i], 1 + (i - j < 0 ? 0 : answers[i - j]));
                }
            }

            return (answers[t.Length - 1] == infinite ? -1 : answers[t.Length - 1]);
        }
    }
}
