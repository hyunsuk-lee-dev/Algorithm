using System;
using System.Collections.Generic;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 
    /// Algorithm.Algorithms.MonthlyChallenge2
    /// </summary>
    public class CorrectParenthese
    {
        private static bool IsCorrect(string s)
        {
            Stack<char> parentheseStack = new Stack<char>();

            for(int i = 0; i<s.Length; i++)
            {
                if(s[i] == '(' || s[i] == '{' || s[i] == '[')
                {
                    parentheseStack.Push(s[i]);
                }
                else if(s[i] == ')')
                {
                    if(parentheseStack.Count > 0 && parentheseStack.Peek() == '(')
                    {
                        parentheseStack.Pop();
                    }
                    else
                    {
                        parentheseStack.Push(s[i]);
                    }
                }
                else if(s[i] == '}')
                {
                    if(parentheseStack.Count > 0 && parentheseStack.Peek() == '{')
                    {
                        parentheseStack.Pop();
                    }
                    else
                    {
                        parentheseStack.Push(s[i]);
                    }
                }
                else if(s[i] == ']')
                {
                    if(parentheseStack.Count > 0 && parentheseStack.Peek() == '[')
                    {
                        parentheseStack.Pop();
                    }
                    else
                    {
                        parentheseStack.Push(s[i]);
                    }
                }
            }

            return parentheseStack.Count == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="absolutes"></param>
        /// <param name="signs"></param>
        /// <returns></returns>
        public static int Solution(string s)
        {
            int answer = 0;
            for(int i = 0; i < s.Length; i++)
            {
                string shiftedString = s.Substring(i) + s.Substring(0, i);

                if(IsCorrect(shiftedString))
                {
                    answer++;
                }
            }

            return answer;
        }
    }
}
