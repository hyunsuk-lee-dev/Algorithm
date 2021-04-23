using System.Collections.Generic;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 
    /// Algorithm.Algorithms.MonthlyChallenge2
    /// </summary>
    public class SepereatedSignSum
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="absolutes"></param>
        /// <param name="signs"></param>
        /// <returns></returns>
        public static int Solution(int[] absolutes, bool[] signs)
        {
            int answer = 0;

            for(int i = 0; i < absolutes.Length; i++)
            {
                answer += signs[i] ? absolutes[i] : -absolutes[i];
            }

            return answer;
        }
    }
}
