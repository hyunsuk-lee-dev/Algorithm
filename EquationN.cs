using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// 아래와 같이 5와 사칙연산만으로 12를 표현할 수 있습니다.
    /// 
    /// 12 = 5 + 5 + (5 / 5) + (5 / 5)
    /// 12 = 55 / 5 + 5 / 5
    /// 12 = (55 + 5) / 5
    /// 
    /// 5를 사용한 횟수는 각각 6,5,4 입니다. 그리고 이중 가장 작은 경우는 4입니다.
    /// </summary>
    public class EquationN
    {
        /// <summary>
        /// </summary>
        /// <param name="N"> N은 1 이상 9 이하입니다. </param>
        /// <param name="number"> number는 1 이상 32,000 이하입니다. </param>
        /// <returns> N과 사칙연산만 사용해서 표현 할 수 있는 방법 중 N 사용횟수의 최솟값 </returns>
        /// 수식에는 괄호와 사칙연산만 가능하며 나누기 연산에서 나머지는 무시합니다.
        /// 최솟값이 8보다 크면 -1을 return 합니다.
        public static int Solution(int N, int number)
        {
            List<int>[] numbers = new List<int>[8];

            int normalNumber = N;

            for(int i = 0 ; i < 8 ; i++)
            {
                numbers[i] = new List<int>();

                if(i > 0)
                {
                    foreach(int num in numbers[i - 1])
                    {
                        if(!numbers[i].Contains(num + N) && num + N > 0)
                            numbers[i].Add(num + N);
                        if(!numbers[i].Contains(num - N) && num - N > 0)
                            numbers[i].Add(num - N);
                        if(!numbers[i].Contains(num * N) && num * N > 0)
                            numbers[i].Add(num * N);
                        if(!numbers[i].Contains(num / N) && num / N > 0)
                            numbers[i].Add(num / N);
                    }
                }
                

                if(!numbers[i].Contains(normalNumber))
                    numbers[i].Add(normalNumber);

                if(numbers[i].Contains(number))
                    return i + 1;

                normalNumber *= 10;
                normalNumber += N;
            }

            return -1;
        }
    }
}
