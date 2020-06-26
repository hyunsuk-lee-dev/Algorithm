using Algorithm.Functions;

using System;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42746
    /// Sort
    /// </summary>
    public class BiggestNumber
    {
        /// <summary>
        /// 0 또는 양의 정수가 주어졌을 때, 정수를 이어 붙여 만들 수 있는 가장 큰 수를 알아내 주세요.
        /// 예를 들어, 주어진 정수가[6, 10, 2] 라면[6102, 6210, 1062, 1026, 2610, 2106]를 만들 수 있고, 이중 가장 큰 수는 6210입니다.
        /// 
        /// 제한 사항
        /// numbers의 길이는 1 이상 100,000 이하입니다.
        /// numbers의 원소는 0 이상 1,000 이하입니다.
        /// 정답이 너무 클 수 있으니 문자열로 바꾸어 return 합니다.
        /// </summary>
        /// <param name="numbers"0 또는 양의 정수가 담긴 배열 ></param>
        /// <returns>순서를 재배치하여 만들 수 있는 가장 큰 수의 문자열</returns>
        public static string Solution(int[] numbers)
        {
            Comparison<int> comparison = (x1, x2) =>
            {
                return (x2.ToString() + x1.ToString()).CompareTo(x1.ToString() + x2.ToString());
            };

            Array.Sort(numbers, comparison);

            string answer = string.Concat(numbers);

            while(answer.Length > 1 && answer[0] == '0')
                answer = answer.Substring(0, 1);

            return answer;
        }
    }
}