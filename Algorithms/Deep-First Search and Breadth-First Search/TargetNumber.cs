using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43165
    /// DFS/BFS
    /// </summary>
    public class TargetNumber
    {
        /// <summary>
        /// n개의 음이 아닌 정수가 있습니다. 이 수를 적절히 더하거나 빼서 타겟 넘버를 만들려고 합니다. 
        /// 예를 들어 [1, 1, 1, 1, 1]로 숫자 3을 만들려면 다음 다섯 방법을 쓸 수 있습니다.
        /// 
        /// -1+1+1+1+1 = 3
        /// +1-1+1+1+1 = 3
        /// +1+1-1+1+1 = 3
        /// +1+1+1-1+1 = 3
        /// +1+1+1+1-1 = 3
        /// 
        /// </summary>
        /// <param name="numbers"> 사용할 수 있는 숫자가 담긴 배열, 개수는 2개 이상 20개 이하, 각 숫자는 1 이상 50 이하인 자연수 </param>
        /// <param name="target"> 타겟 넘버, 1 이상 1000 이하인 자연수 </param>
        /// <returns> 숫자를 적절히 더하고 빼서 타겟 넘버를 만드는 방법의 수 </returns>
        public static int Solution(int[] numbers, int target)
        {
            int answer = 0;

            if(numbers.Length == 1)
            {
                if(numbers[0] == target || numbers[0] == -target)
                    return 1;
                else
                    return 0;
            }

            int[] restNumbers = numbers.Skip(1).ToArray();

            answer += Solution(restNumbers, target - numbers[0]);
            answer += Solution(restNumbers, target + numbers[0]);

            return answer;
        }
    }
}
