using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/70129
    /// Algorithm.Algorithms.MonthlyChallenge1
    /// </summary>
    public class BinaryConverter
    {
        /// <summary>
        /// 0과 1로 이루어진 어떤 문자열 x에 대한 이진 변환을 다음과 같이 정의합니다.
        /// - x의 모든 0을 제거합니다.
        /// - x의 길이를 c라고 하면, x를 "c를 2진법으로 표현한 문자열"로 바꿉니다.
        /// 예를 들어, x = "0111010"이라면, x에 이진 변환을 가하면 x = "0111010"-> "1111" -> "100" 이 됩니다.
        /// 
        /// </summary>
        /// <param name="s">0과 1로 이루어진 문자열</param>
        /// <returns>s가 "1"이 될 때까지 계속해서 s에 이진 변환을 가했을 때, 
        /// 이진 변환의 횟수와 변환 과정에서 제거된 모든 0의 개수</returns>
        public static int[] Solution(string s)
        {
            int convertCount = 0;
            int removeCount = 0;

            string targetString = s;

            while(targetString != "1")
            {
                removeCount += targetString.Count(o => o.Equals('0'));
                targetString = targetString.Replace("0", "");
                targetString = Convert.ToString(targetString.Length, 2);
                convertCount++;
            }

            return new int[2] { convertCount , removeCount };
        }
    }
}
