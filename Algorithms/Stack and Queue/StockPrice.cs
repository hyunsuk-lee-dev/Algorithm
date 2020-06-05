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
    public class StockPrice
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prices">초 단위로 기록된 주식가격이 담긴 배열</param>
        /// <returns>가격이 떨어지지 않은 기간은 몇 초인지</returns>
        public static int[] Solution(int[] prices)
        {
            int[] answers = new int[prices.Length];

            Stack<int> times = new Stack<int>();

            for(int i = 0 ; i < prices.Length ; i++)
            {
                while(times.Count > 0 && prices[i] < prices[times.Peek()])
                {
                    answers[times.Peek()] = i - times.Peek();
                    times.Pop();
                }

                times.Push(i);
            }

            for(int i = answers.Length - 1 ; i >= 0 ; i--)
            {
                if(answers[i] <= 0)
                    answers[i] = prices.Length - 1 - times.Pop();
            }

            return answers;
        }
    }
}
