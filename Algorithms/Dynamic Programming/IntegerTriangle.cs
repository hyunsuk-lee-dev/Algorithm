using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43105
    /// DP
    /// </summary>
    public static class IntegerTriangle
    {
        /// <summary>
        /// 
        ///         7
        ///       3   8
        ///     8   1   0
        ///   2   7   4   4
        /// 4   5   2   6   5
        /// 
        /// 위와 같은 삼각형의 꼭대기에서 바닥까지 이어지는 경로 중, 거쳐간 숫자의 합이 가장 큰 경우를 찾아보려고 합니다. 
        /// 아래 칸으로 이동할 때는 대각선 방향으로 한 칸 오른쪽 또는 왼쪽으로만 이동 가능합니다. 
        /// 예를 들어 3에서는 그 아래칸의 8 또는 1로만 이동이 가능합니다.
        /// 
        /// </summary>
        /// <param name="triangle">삼각형의 정보가 담긴 배열</param>
        /// <returns>거쳐간 숫자의 최댓값</returns>
        public static int Solution(List<List<int>> triangle)
        {
            triangle.Reverse();

            List<List<int>> answer = new List<List<int>>();

            for(int h = 0 ; h < triangle.Count ; h++)
            {
                List<int> maxList = new List<int>();

                if(h == 0)
                    maxList = triangle[h];
                else if(h == triangle.Count - 1)
                {
                    return triangle[h][0] + Math.Max(answer[h - 1][0], answer[h - 1][1]);
                }
                else
                {
                    for(int i = 0 ; i < triangle[h].Count ; i++)
                    {
                        maxList.Add(triangle[h][i] + Math.Max(answer[h - 1][i], answer[h - 1][i + 1]));
                    }
                }

                answer.Add(maxList);
            }

            return 0;
        }

    }
}
