using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42587
    /// Stack and Queue
    /// </summary>
    public static class PrinterQueue
    {
        /// <summary>
        /// 일반적인 프린터는 인쇄 요청이 들어온 순서대로 인쇄합니다. 그렇기 때문에 중요한 문서가 나중에 인쇄될 수 있습니다. 
        /// 이런 문제를 보완하기 위해 중요도가 높은 문서를 먼저 인쇄하는 프린터를 개발했습니다. 
        /// 이 새롭게 개발한 프린터는 아래와 같은 방식으로 인쇄 작업을 수행합니다.
        /// 
        /// 1. 인쇄 대기목록의 가장 앞에 있는 문서(J)를 대기목록에서 꺼냅니다.
        /// 2. 나머지 인쇄 대기목록에서 J보다 중요도가 높은 문서가 한 개라도 존재하면 J를 대기목록의 가장 마지막에 넣습니다.
        /// 3. 그렇지 않으면 J를 인쇄합니다.
        /// </summary>
        /// <param name="priorities">현재 대기목록에 있는 문서의 중요도가 순서대로 담긴 배열</param>
        /// <param name="location">내가 인쇄를 요청한 문서가 현재 대기목록의 어떤 위치에 있는지</param>
        /// <returns>내가 인쇄를 요청한 문서가 몇 번째로 인쇄되는지</returns>
        public static int Solution(int[] priorities, int location)
        {
            int answer = 0;

            int max;
            int maxIndex = -1;
            int maxIndexIndex = -1;

            List<int> indices = new List<int>();

            for(int i = 0 ; i < priorities.Length ; i++)
            {
                indices.Add(i);
            }

            while(maxIndex != location)
            {
                max = -1;
               
                for(int i = 0 ; i< indices.Count ; i++)
                {
                    if(priorities[indices[i]] > max)
                    {
                        max = priorities[indices[i]];
                        maxIndex = indices[i];
                        maxIndexIndex = i;
                    }
                }

                List<int> newIndices = new List<int>();
                for(int i = maxIndexIndex + 1 ; i < indices.Count ; i++)
                    newIndices.Add(indices[i]);
                for(int i = 0 ; i < maxIndexIndex ; i++)
                    newIndices.Add(indices[i]);

                indices = newIndices;

                answer++;
            }

            return answer;
        }
    }
}
