using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/18/lessons/1881?language=csharp
    /// DP
    /// </summary>
    public class Sticker
    {
        /// <summary>
        /// N개의 스티커가 원형으로 연결되어 있습니다.
        /// 원형으로 연결된 스티커에서 몇 장의 스티커를 뜯어내어 뜯어낸 스티커에 적힌 숫자의 합이 최대가 되도록 하고 싶습니다.
        /// 단 스티커 한 장을 뜯어내면 양쪽으로 인접해있는 스티커는 찢어져서 사용할 수 없게 됩니다.
        /// 
        /// 제한 사항
        /// sticker는 원형으로 연결된 스티커의 각 칸에 적힌 숫자가 순서대로 들어있는 배열로, 길이(N) 는 1 이상 100,000 이하입니다.
        /// sticker의 각 원소는 스티커의 각 칸에 적힌 숫자이며, 각 칸에 적힌 숫자는 1 이상 100 이하의 자연수입니다.
        /// 원형의 스티커 모양을 위해 sticker 배열의 첫 번째 원소와 마지막 원소가 서로 연결되어있다고 간주합니다.
        /// </summary>
        /// <param name="sticker">스티커에 적힌 숫자 배열 </param>
        /// <returns>스티커를 뜯어내어 얻을 수 있는 숫자의 합의 최댓값</returns>
        public static int Solution(int[] sticker)
        {
            if(sticker.Length == 1)
                return sticker[0];

            int[] first = new int[sticker.Length];
            int[] second = new int[sticker.Length];

            first[0] = sticker[0];
            first[1] = sticker[0];

            second[0] = 0;
            second[1] = sticker[1];

            for(int i = 2 ; i < sticker.Length ; i++)
            {
                if(i < sticker.Length -1)
                    first[i] = Math.Max(first[i - 1], first[i - 2] + sticker[i]);

                second[i] = Math.Max(second[i - 1], second[i - 2] + sticker[i]);
            }


            return Math.Max(first[sticker.Length-2] , second[sticker.Length-1]);
        }

    }
}
