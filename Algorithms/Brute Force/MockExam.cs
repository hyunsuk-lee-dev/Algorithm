using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42840
    /// Brute Force
    /// </summary>
    public class MockExam
    {
        /// <summary>
        /// 수포자는 수학을 포기한 사람의 준말입니다. 수포자 삼인방은 모의고사에 수학 문제를 전부 찍으려 합니다. 수포자는 1번 문제부터 마지막 문제까지 다음과 같이 찍습니다.
        ///                      0] 1] 2] 3] 4] 5] 6] 7] 8] 9]   
        /// 1번 수포자가 찍는 방식: 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, ...
        /// 2번 수포자가 찍는 방식: 2, 1, 2, 3, 2, 4, 2, 5, 2, 1, 2, 3, 2, 4, 2, 5, ...
        /// 3번 수포자가 찍는 방식: 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, 3, 3, 1, 1, 2, 2, 4, 4, 5, 5, ...
        /// 
        /// 제한 조건
        /// 시험은 최대 10,000 문제로 구성되어있습니다.
        /// 문제의 정답은 1, 2, 3, 4, 5중 하나입니다.
        /// 가장 높은 점수를 받은 사람이 여럿일 경우, return하는 값을 오름차순 정렬해주세요.
        /// </summary>
        /// <param name="answers">1번 문제부터 마지막 문제까지의 정답이 순서대로 들은 배열</param>
        /// <returns>가장 많은 문제를 맞힌 사람이 누구인지 배열</returns>
        public static int[] Solution(int[] answers)
        {
            List<int> answer = new List<int>();

            int[] scores = new int[3] { 0, 0, 0 };

            int[][] marks = new int[3][] { new int[5] { 1, 2, 3, 4, 5 }, new int[8] { 2, 1, 2, 3, 2, 4, 2, 5 }, new int[10] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 } };

            for(int i = 0 ; i < answers.Length ; i++)
            {
                for(int j = 0 ; j < marks.GetLength(0) ; j++)
                {
                    if(answers[i] == marks[j][i % marks[j].Length])
                        scores[j]++;
                }
            }

            for(int i = 0 ; i < scores.Length ; i++)
                if(scores[i] == scores.Max())
                    answer.Add(i + 1);

            return answer.ToArray();
        }
    }
}
