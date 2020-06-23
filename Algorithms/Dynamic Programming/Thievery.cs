using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42897#
    /// DP
    /// </summary>
    public class Thievery
    {
        /// <summary>
        /// 도둑이 어느 마을을 털 계획을 하고 있습니다. 이 마을의 모든 집들은 아래 그림과 같이 동그랗게 배치되어 있습니다.
        /// 각 집들은 서로 인접한 집들과 방범장치가 연결되어 있기 때문에 인접한 두 집을 털면 경보가 울립니다.
        /// 
        /// 제한사항
        /// 이 마을에 있는 집은 3개 이상 1,000,000개 이하입니다.
        /// money 배열의 각 원소는 0 이상 1,000 이하인 정수입니다.
        /// </summary>
        /// <param name="money">각 집에 있는 돈이 담긴 배열</param>
        /// <returns>도둑이 훔칠 수 있는 돈의 최댓값</returns>
        public static int Solution(int[] money)
        {
            int[] evenHouse = new int[money.Length];
            int[] oddHouse = new int[money.Length];

            evenHouse[0] = money[0];
            evenHouse[1] = money[0];

            oddHouse[0] = 0;
            oddHouse[1] = money[1];

            for(int i = 2 ; i < money.Length ; i++)
            {
                if(i != money.Length - 1)
                    evenHouse[i] = Math.Max(evenHouse[i - 2] + money[i], evenHouse[i - 1]);

                oddHouse[i] = Math.Max(oddHouse[i - 2] + money[i], oddHouse[i - 1]);
            }

            return Math.Max(evenHouse[money.Length - 2], oddHouse[money.Length - 1]);
        }
    }
}
