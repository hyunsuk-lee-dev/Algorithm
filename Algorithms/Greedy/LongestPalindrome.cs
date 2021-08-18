using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 가장 긴 팰린드롬
    /// https://programmers.co.kr/learn/courses/30/lessons/12904
    /// Algorithm.Algorithms.Greedy
    /// </summary>
    public class LongestPalindrome
    {
        /// <summary>
        /// 앞뒤를 뒤집어도 똑같은 문자열을 팰린드롬(palindrome)이라고 합니다.
        /// </summary>
        /// <param name="s">문자열</param>
        /// <returns>s의 부분문자열(Substring)중 가장 긴 팰린드롬의 길이</returns>
        public static int Solution(string s)
        {
            if(s.Length == 1)
            {
                return 1;
            }
                
            int[] oddPalindromes = new int[s.Length];
            for(int i = 0; i < s.Length; i++)
            {
                oddPalindromes[i] = 1;
                for(int j = 1; j <= Math.Min(i, s.Length - 1 - i); j++)
                {
                    if(s[i - j] == s[i + j])
                    {
                        oddPalindromes[i] += 2;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            int[] evenPalindromes = new int[s.Length - 1];

            for(int i = 0; i < s.Length - 1; i++)
            {
                evenPalindromes[i] = 0;
                for(int j = 1; j <= Math.Min(i + 1, s.Length - 1 - i); j++)
                {
                    if(s[i+1-j] == s[i + j])
                    {
                        evenPalindromes[i] += 2;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return Math.Max( oddPalindromes.Max(), evenPalindromes.Max());
        }
    }
}
