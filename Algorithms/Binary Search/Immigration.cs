using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43238
    /// BS
    /// </summary>
    public class Immigration
    {
        /// <summary>
        /// n명이 입국심사를 위해 줄을 서서 기다리고 있습니다. 각 입국심사대에 있는 심사관마다 심사하는데 걸리는 시간은 다릅니다.
        /// 처음에 모든 심사대는 비어있습니다. 한 심사대에서는 동시에 한 명만 심사를 할 수 있습니다. 
        /// 가장 앞에 서 있는 사람은 비어 있는 심사대로 가서 심사를 받을 수 있습니다. 
        /// 하지만 더 빨리 끝나는 심사대가 있으면 기다렸다가 그곳으로 가서 심사를 받을 수도 있습니다.
        /// 모든 사람이 심사를 받는데 걸리는 시간을 최소로 하고 싶습니다.
        /// 
        /// 제한사항
        /// 입국심사를 기다리는 사람은 1명 이상 1,000,000,000명 이하입니다.
        /// 각 심사관이 한 명을 심사하는데 걸리는 시간은 1분 이상 1,000,000,000분 이하입니다.
        /// 심사관은 1명 이상 100,000명 이하입니다.
        /// </summary>
        /// <param name="n">입국심사를 기다리는 사람 수</param>
        /// <param name="times">각 심사관이 한 명을 심사하는데 걸리는 시간이 담긴 배열</param>
        /// <returns>모든 사람이 심사를 받는데 걸리는 시간의 최솟값</returns>
        public static long Solution(long n, int[] times)
        {
            long lowTime = 0;
            long minimumLowTime = 0;
            long highTime = times.Max() * n;

            while(lowTime <= highTime)
            {
                long midTime = (lowTime + highTime) / 2;
                long nCount = 0;

                foreach(int time in times)
                    nCount += midTime / time;

                if(nCount >= n)
                {
                    highTime = midTime - 1;
                    minimumLowTime = midTime;
                }
                else
                {
                    lowTime = midTime + 1;
                }
            }

            return minimumLowTime;
        }
    }
}
