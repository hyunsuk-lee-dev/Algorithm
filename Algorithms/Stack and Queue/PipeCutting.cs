using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42585
    /// Stack and Queue
    /// </summary>
    public static class PipeCutting
    {
        public static int Solution(string arrangement)
        {
            int answer = 0;
            int overlaped = 0;

            for(int i = 0 ; i < arrangement.Length ; i++)
            {
                if(arrangement[i] == '(')
                {
                    if(arrangement[i+1] == ')')
                    {
                        answer += overlaped;
                        i++;
                    }
                    else
                    {
                        overlaped++;
                    }
                }
                else
                {
                    answer++;
                    overlaped--;
                }
            }

            return answer;
        }
    }
}
