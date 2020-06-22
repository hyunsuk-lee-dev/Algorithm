using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42898?language=java
    /// DP
    /// </summary>
    public class SchoolRoad
    {
        /// <summary>
        /// 계속되는 폭우로 일부 지역이 물에 잠겼습니다. 물에 잠기지 않은 지역을 통해 학교를 가려고 합니다. 
        /// 집에서 학교까지 가는 길은 m x n 크기의 격자모양으로 나타낼 수 있습니다.
        /// 가장 왼쪽 위, 즉 집이 있는 곳의 좌표는 (1, 1)로 나타내고 가장 오른쪽 아래, 즉 학교가 있는 곳의 좌표는(m, n)으로 나타냅니다.
        /// 
        /// 제한사항
        /// 격자의 크기 m, n은 1 이상 100 이하인 자연수입니다.
        /// m과 n이 모두 1인 경우는 입력으로 주어지지 않습니다.
        /// 물에 잠긴 지역은 0개 이상 10개 이하입니다.
        /// 집과 학교가 물에 잠긴 경우는 입력으로 주어지지 않습니다.
        /// </summary>
        /// <param name="m">격자의 크기</param>
        /// <param name="n">격자의 크기</param>
        /// <param name="puddles">물이 잠긴 지역의 좌표를 담은 2차원 배열</param>
        /// <returns>집에서 학교까지 갈 수 있는 최단경로의 개수를 1,000,000,007로 나눈 나머지</returns>
        public static int Solution(int m, int n, int[][] puddles)
        {
            int[,] answers = new int[m, n];
            for(int i = 0 ; i < m ; i++)
            {
                for(int j = 0 ; j < n ; j++)
                {
                    answers[i, j] = -1;
                }
            }

            for(int i = 0 ; i < puddles.GetLength(0) ; i++)
            {
                answers[puddles[i][0] - 1, puddles[i][1] - 1] = 0;
            }

            int defaultValue = 1;
            for(int i = 1 ; i < m ; i++)
            {
                if(answers[i, 0] == 0)
                    defaultValue = 0;

                answers[i, 0] = defaultValue;
            }

            defaultValue = 1;
            for(int i = 1 ; i < n ; i++)
            {
                if(answers[0, i] == 0)
                    defaultValue = 0;

                answers[0, i] = defaultValue;
            }

            for(int i = 1 ; i < m ; i++)
            {
                for(int j = 1 ; j < n ; j++)
                {
                    if(answers[i, j] != 0)
                        answers[i, j] = (answers[i - 1, j] + answers[i, j - 1]) % 1000000007;
                }
            }

            return answers[m - 1, n - 1];
        }
    }
}
