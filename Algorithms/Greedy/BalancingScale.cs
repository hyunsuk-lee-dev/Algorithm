using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42886?language=java
    /// Greedy
    /// </summary>
    public class BalancingScale
    {
        /// <summary>
        /// 하나의 양팔 저울을 이용하여 물건의 무게를 측정하려고 합니다. 
        /// 이 저울의 양팔의 끝에는 물건이나 추를 올려놓는 접시가 달려 있고, 양팔의 길이는 같습니다. 
        /// 또한, 저울의 한쪽에는 저울추들만 놓을 수 있고, 다른 쪽에는 무게를 측정하려는 물건만 올려놓을 수 있습니다.
        /// 예를 들어, 무게가 각각 [3, 1, 6, 2, 7, 30, 1] 인 7개의 저울추를 주어졌을 때, 
        /// 이 추들로 측정할 수 없는 양의 정수 무게 중 최솟값은 21입니다.
        /// 
        /// 제한 사항
        /// 저울추의 개수는 1개 이상 10,000개 이하입니다.
        /// 각 추의 무게는 1 이상 1,000,000 이하입니다.
        /// </summary>
        /// <param name="weight">저울추가 담긴 배열</param>
        /// <returns>이 추들로 측정할 수 없는 양의 정수 무게 중 최솟값</returns>
        public static int Solution(int[] weight)
        {
            Array.Sort(weight);
            int minWeight = 0;
            int maxWeight = 0;

            foreach(int w in weight)
            {
                if(minWeight + w > maxWeight + 1)
                    return maxWeight + 1;
                maxWeight += w;
            }

            return maxWeight + 1;
        }
    }
}
