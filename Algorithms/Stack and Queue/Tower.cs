using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42588
    /// Stack/Queue
    /// </summary>
    public class Tower
    {
        public static int[] Solution(int[] heights)
        {
            int[] answer = new int[heights.Length];

            for(int i = heights.Length - 1 ; i >= 0 ; i--)
            {
                for(int j = i - 1 ; j >= 0 ; j--)
                {
                    if(heights[j] > heights[i])
                    {
                        answer[i] = j + 1;
                        break;
                    }
                }
            }

            return answer;
        }

    }
}
