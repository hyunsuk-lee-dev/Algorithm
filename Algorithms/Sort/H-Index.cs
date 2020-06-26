using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42747
    /// Sort
    /// </summary>
    public class H_Index
    {
        /// <summary>
        /// H-Index는 과학자의 생산성과 영향력을 나타내는 지표입니다. 어느 과학자의 H-Index를 나타내는 값인 h를 구하려고 합니다. 
        /// 위키백과1에 따르면, H-Index는 다음과 같이 구합니다.
        /// 어떤 과학자가 발표한 논문 n편 중, h번 이상 인용된 논문이 h편 이상이고 나머지 논문이 h번 이하 인용되었다면 
        /// h의 최댓값이 이 과학자의 H-Index입니다.
        /// 
        /// 제한사항
        /// 과학자가 발표한 논문의 수는 1편 이상 1,000편 이하입니다.
        /// 논문별 인용 횟수는 0회 이상 10,000회 이하입니다.
        /// </summary>
        /// <param name="citations">어떤 과학자가 발표한 논문의 인용 횟수를 담은 배열</param>
        /// <returns>이 과학자의 H-Index</returns>
        public static int Solution(int[] citations)
        {
            Array.Sort(citations);
            Array.Reverse(citations);

            for(int i = 0 ; i < citations.Length ;i++)
            {
                if(citations[i] < i + 1)
                    return i;
            }

            return citations.Length;
        }
    }
}
