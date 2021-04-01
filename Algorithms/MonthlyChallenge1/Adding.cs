using System.Collections.Generic;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/68644?language=csharp
    /// Algorithm.Algorithms.MonthlyChallenge1
    /// </summary>
    public class Adding
    {
        /// <summary>
        /// 정수 배열 에서 서로 다른 인덱스에 있는 두 개의 수를 뽑아 더해서 만들 수 있는 
        /// 모든 수를 배열에 오름차순으로 담는 함수를 완성해주세요.
        /// 
        /// 제한사항
        /// numbers의 길이는 2 이상 100 이하입니다.
        /// numbers의 모든 수는 0 이상 100 이하입니다.
        /// </summary>
        /// <param name="numbers">정수 배열</param>
        /// <returns>두 개의 수를 뽑아 더해서 만들 수 있는 모든 수의 배열</returns>
        public static int[] Solution(int[] numbers)
        {
            List<int> answer = new List<int>();

            for(int i = 0; i < numbers.Length - 1; i++)
            {
                for(int j = i + 1; j < numbers.Length; j++)
                {
                    int sum = numbers[i] + numbers[j];
                    if(!answer.Contains(sum))
                    {
                        answer.Add(sum);
                    }
                }
            }

            answer.Sort();

            return answer.ToArray();
        }
    }
}
