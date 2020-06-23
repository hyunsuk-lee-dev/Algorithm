using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42899
    /// DP
    /// </summary>
    public class TravelFundRaising
    {
        /// <summary>
        /// 서울에서 경산까지 여행을 하면서 모금 활동을 하려 합니다. 여행은 서울에서 출발해 다른 도시를 정해진 순서대로 딱 한 번 방문한 후 경산으로 도착할 예정입니다. 
        /// 도시를 이동할 때에는 도보 혹은 자전거를 이용합니다. 
        /// 이때 도보 이동에 걸리는 시간, 도보 이동 시 얻을 모금액, 자전거 이동에 걸리는 시간, 자전거 이동 시 얻을 모금액이 정해져 있습니다. 
        /// K시간 이내로 여행할 때 모을 수 있는 최대 모금액을 알아보려 합니다.
        /// 
        /// 제한사항
        /// travel 배열의 각 행은 순서대로 [도보 이동에 걸리는 시간, 도보 이동 시 얻을 모금액, 자전거 이동에 걸리는 시간, 자전거 이동 시 얻을 모금액]입니다.
        /// travel 배열 행의 개수는 3 이상 100 이하인 정수입니다.
        /// travel 배열에서 시간을 나타내는 숫자(각 행의 첫 번째, 세 번째 숫자)는 10,000 이하의 자연수, 
        /// 모금액을 나타내는 숫자(각 행의 두 번째, 네 번째 숫자)는 1,000,000 이하의 자연수입니다.
        /// K는 0보다 크고 100,000보다 작거나 같은 자연수입니다.
        /// </summary>
        /// <param name="K">제한시간</param>
        /// <param name="travel">각 도시를 이동할 때 이동 수단별로 걸리는 시간과 모금액을 담은 2차원 배열</param>
        /// <returns>제한시간 안에 여행을 하며 모을 수 있는 최대 모금액</returns>
        public static int Solution(int K, int[,] travel)
        {
            int[,] answers = new int[K + 1, travel.GetLength(0)];

            for(int k = 0 ; k <= K ; k++)
            {
                answers[k, 0] = Math.Max(k >= travel[0, 0] ? travel[0, 1] : -1, k >= travel[0, 2] ? travel[0, 3] : -1);
            }

            for(int i = 1 ; i < travel.GetLength(0) ; i++)
            {
                for(int k = 0 ; k <= K ; k++)
                {
                    answers[k, i] = Math.Max(
                        k >= travel[i, 0] && answers[k - travel[i, 0], i - 1] >= 0 ? answers[k - travel[i, 0], i - 1] + travel[i, 1] : -1,
                        k >= travel[i, 2] && answers[k - travel[i, 2], i - 1] >= 0 ? answers[k - travel[i, 2], i - 1] + travel[i, 3] : -1);
                }
            }

            return answers[K, travel.GetLength(0) - 1];
        }
    }
}
