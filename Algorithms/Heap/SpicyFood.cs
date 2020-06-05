using Algorithm.Algorithms.Heap;
using Algorithm.Functions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42626?language=cpp
    /// Head
    /// </summary>
    public class SpicyFood 
    {
        /// <summary>
        /// 매운 것을 좋아하는 Leo는 모든 음식의 스코빌 지수를 K 이상으로 만들고 싶습니다. 
        /// 모든 음식의 스코빌 지수를 K 이상으로 만들기 위해 Leo는 스코빌 지수가 가장 낮은 두 개의 음식을 아래와 같이 특별한 방법으로 섞어 새로운 음식을 만듭니다.
        /// 
        /// 섞은 음식의 스코빌 지수 = 가장 맵지 않은 음식의 스코빌 지수 + (두 번째로 맵지 않은 음식의 스코빌 지수 * 2)
        /// Leo는 모든 음식의 스코빌 지수가 K 이상이 될 때까지 반복하여 섞습니다.
        /// 
        /// </summary>
        /// <param name="scoville">가진 음식의 스코빌 지수를 담은 배열</param>
        /// <param name="k">원하는 스코빌 지수</param>
        /// <returns>모든 음식의 스코빌 지수를 K 이상으로 만들기 위해 섞어야 하는 최소 횟수</returns>
        /// 
        /// 제한 사항
        /// scoville의 길이는 2 이상 1,000,000 이하입니다.
        /// K는 0 이상 1,000,000,000 이하입니다.
        /// scoville의 원소는 각각 0 이상 1,000,000 이하입니다.
        /// 모든 음식의 스코빌 지수를 K 이상으로 만들 수 없는 경우에는 -1을 return 합니다.
        public static int Solution(int[] scoville, int k)
        {
            int answer = 0;

            Heap<int> scovilleHeap = new Heap<int>(HeapType.Min);

            foreach(int food in scoville)
                scovilleHeap.Add(food);

            while(scovilleHeap.Peek() < k)
            {
                if(scovilleHeap.Count == 1)
                    return -1;

                int first = scovilleHeap.Remove();
                int second = scovilleHeap.Remove();

                scovilleHeap.Add(first + second * 2);

                answer++;
            }

            return answer;
        } 
    }
}
