using Algorithm.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42839
    /// Brute Force
    /// </summary>
    public class FindingPrimeNumber
    {
        /// <summary>
        /// 한자리 숫자가 적힌 종이 조각이 흩어져있습니다. 흩어진 종이 조각을 붙여 소수를 몇 개 만들 수 있는지 알아내려 합니다.
        ///   
        /// 제한사항
        /// numbers는 길이 1 이상 7 이하인 문자열입니다.
        /// numbers는 0~9까지 숫자만으로 이루어져 있습니다.
        /// 013은 0, 1, 3 숫자가 적힌 종이 조각이 흩어져있다는 의미입니다.
        /// </summary>
        /// <param name="numbers">각 종이 조각에 적힌 숫자가 적힌 문자열</param>
        /// <returns>종이 조각으로 만들 수 있는 소수가 몇 개인지</returns>
        public static int Solution(string numbers)
        {
            List<int> numberList = new List<int>();

            foreach(char number in numbers)
            {
                numberList.Add(int.Parse(number.ToString()));
            }

            List<int> combinations = Combination(numberList);

            combinations.Remove(0);
            combinations.Remove(1);

            combinations.Sort((x1, x2) => -x1.CompareTo(x2));
            
            for(int i = 2 ; i <= combinations[0] ;i++)
            {
                for(int j = i * 2 ; j <= combinations[0] ; j += i)
                {
                    if(combinations.Contains(j))
                        combinations.Remove(j);
                }
            }

            Console.WriteLine(combinations.ToStrings());

            return combinations.Count;
        }

        static List<int> Combination(List<int> array)
        {
            List<int> combinations = new List<int>();

            for(int i = 0 ; i < array.Count ; i++)
            {
                List<int> tempArray = new List<int>(array);

                int now = tempArray[i];
                tempArray.RemoveAt(i);

                if(!combinations.Contains(now))
                    combinations.Add(now);

                if(array.Count == 0)
                    continue;

                foreach(int item in Combination(tempArray))
                {
                    if(!combinations.Contains(item * 10 + now))
                        combinations.Add(item * 10 + now);
                }
            }

            return combinations;
        }
    }
}
