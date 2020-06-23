using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42883
    /// Greedy
    /// </summary>
    public class BigNumber
    {
        /// <summary>
        /// 어떤 숫자에서 k개의 수를 제거했을 때 얻을 수 있는 가장 큰 숫자를 구하려 합니다.
        /// 예를 들어, 숫자 1924에서 수 두 개를 제거하면[19, 12, 14, 92, 94, 24] 를 만들 수 있습니다.이 중 가장 큰 숫자는 94 입니다.
        /// 
        /// 제한 조건
        /// number는 1자리 이상, 1,000,000자리 이하인 숫자입니다.
        /// k는 1 이상 number의 자릿수 미만인 자연수입니다.
        /// </summary>
        /// <param name="number">문자열 형식의 숫자</param>
        /// <param name="k">제거할 수의 개수</param>
        /// <returns>number에서 k 개의 수를 제거했을 때 만들 수 있는 수 중 가장 큰 숫자의 문자열</returns>
        public static string Solution(string number, int k)
        {
            StringBuilder numbers = new StringBuilder(number);
            int starting = 0;

            while(k > 0)
            {
                if(number.Length - starting == k)
                {
                    numbers.Remove(starting, k);
                    break;
                }

                char max = '/';
                int maxIndex = -1;

                for(int i = 0 ; i < k + 1 ; i++)
                {
                    char nowNumber = numbers[starting + i];
                    if(max < nowNumber)
                    {
                        max = nowNumber;
                        maxIndex = i;

                        if(nowNumber == '9')
                            break;
                    }
                }

                numbers.Remove(starting, maxIndex);

                k -= maxIndex;
                starting++;
            }

            return numbers.ToString();
        }
    }
}
