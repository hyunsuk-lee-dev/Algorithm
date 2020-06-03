using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42584
    /// Stack and Queue
    /// </summary>
    public static class StockPrice
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prices">초 단위로 기록된 주식가격이 담긴 배열</param>
        /// <returns>가격이 떨어지지 않은 기간은 몇 초인지</returns>
        public static int[] Solution(int[] prices)
        {
            int[] answer = new int[prices.Length];

            for(int i = 0 ; i < prices.Length ; i++)
            {
                for(int j = 0 ; j < i ; j++)
                {
                    answer[j]++;
                }
                    
            }

            return answer;
        }
    }
}
