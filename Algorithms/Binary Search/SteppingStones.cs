
using System;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43236
    /// BS
    /// </summary>
    public class SteppingStones
    {
        /// <summary>
        /// 출발지점부터 distance만큼 떨어진 곳에 도착지점이 있습니다. 그리고 그사이에는 바위들이 놓여있습니다. 바위 중 몇 개를 제거하려고 합니다.
        /// 예를 들어, 도착지점이 25만큼 떨어져 있고, 바위가[2, 14, 11, 21, 17] 지점에 놓여있을 때 바위 2개를 제거하면 
        /// 출발지점, 도착지점, 바위 간의 거리가 아래와 같습니다.
        /// 제거한 바위의 위치     각 바위 사이의 거리   거리의 최솟값
        /// [21, 17]            [2, 9, 3, 11]	    2
        /// [2, 21]             [11, 3, 3, 8]	    3
        /// [2, 11]             [14, 3, 4, 4]	    3
        /// [11, 21]            [2, 12, 3, 8]	    2
        /// [2, 14]             [11, 6, 4, 4]	    4
        /// 위에서 구한 거리의 최솟값 중에 가장 큰 값은 4입니다.
        /// 
        /// 제한사항
        /// 도착지점까지의 거리 distance는 1 이상 1,000,000,000 이하입니다.
        /// 바위는 1개 이상 50,000개 이하가 있습니다.
        /// n 은 1 이상 바위의 개수 이하입니다.
        /// </summary>
        /// <param name="distance">출발지점부터 도착지점까지의 거리</param>
        /// <param name="rocks">바위들이 있는 위치를 담은 배열</param>
        /// <param name="n">제거할 바위의 수</param>
        /// <returns>바위를 n개 제거한 뒤 각 지점 사이의 거리의 최솟값 중에 가장 큰 값</returns>
        public static int Solution(int distance, int[] rocks, int n)
        {
            Array.Sort(rocks);
            int[] distances = new int[rocks.Length + 1];
            int point = 0;
            for(int i = 0 ; i < rocks.Length ; i++)
            {
                distances[i] = rocks[i] - point;
                point = rocks[i];
            }
            distances[rocks.Length] = distance - point;

            int lowDistance = 0;
            int highDistance = distance;
            int midDistance;
            int answer = 0;

            while(lowDistance <= highDistance)
            {
                midDistance = (lowDistance + highDistance) / 2;

                int removedRockCount = 0;
                int distanceSum = 0;

                for(int i = 0 ; i < distances.Length ; i++)
                {
                    distanceSum += distances[i];

                    if(distanceSum < midDistance)
                    {
                        removedRockCount++;
                    }
                    else
                        distanceSum = 0;
                }

                if(removedRockCount <= n)
                {
                    answer = Math.Max(answer, midDistance);
                    lowDistance = midDistance + 1;
                }
                else
                {
                    highDistance = midDistance - 1;
                }
            }

            return answer;
        }

        static int NeedStone(int[] distances, int distance)
        {
            int count = 0;
            int sum = 0;

            for(int i = 0 ; i < distances.Length ; i++)
            {
                sum += distances[i];

                if(sum < distance)
                {
                    count++;
                }
                else
                    sum = 0;
            }

            return count;
        }
    }
}
