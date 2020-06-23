using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42896
    /// DP
    /// </summary>
    public class CardGame
    {
        /// <summary>
        /// 카드게임이 있다. 게임에 사용하는 각 카드에는 양의 정수 하나가 적혀있고 같은 숫자가 적힌 카드는 여러 장 있을 수 있다. 
        /// 게임방법은 우선 짝수개의 카드를 무작위로 섞은 뒤 같은 개수의 두 더미로 나누어 하나는 왼쪽에 다른 하나는 오른쪽에 둔다.
        /// 
        /// 각 더미의 제일 위에 있는 카드끼리 서로 비교하며 게임을 한다.게임 규칙은 다음과 같다.
        /// 지금부터 왼쪽 더미의 제일 위 카드를 왼쪽 카드로, 오른쪽 더미의 제일 위 카드를 오른쪽 카드로 부르겠다.
        /// 
        /// 1. 언제든지 왼쪽 카드만 통에 버릴 수도 있고 왼쪽 카드와 오른쪽 카드를 둘 다 통에 버릴 수도 있다.이때 얻는 점수는 없다.
        /// 2. 오른쪽 카드에 적힌 수가 왼쪽 카드에 적힌 수보다 작은 경우에는 오른쪽 카드만 통에 버릴 수도 있다. 
        /// 오른쪽 카드만 버리는 경우에는 오른쪽 카드에 적힌 수만큼 점수를 얻는다.
        /// 3. (1)과(2)의 규칙에 따라 게임을 진행하다가 어느 쪽 더미든 남은 카드가 없다면 게임이 끝나며 그때까지 얻은 점수의 합이 최종 점수가 된다.
        /// 
        /// 제한 사항
        /// 한 더미에는 1장 이상 2,000장 이하의 카드가 있다.
        /// 각 카드에 적힌 정수는 1 이상 2,000 이하이다.
        /// </summary>
        /// <param name="left">왼쪽 더미의 카드에 적힌 정수가 담긴 배열</param>
        /// <param name="right">오른쪽 더미의 카드에 적힌 정수가 담긴 배열</param>
        /// <returns>얻을 수 있는 최종 점수의 최대값</returns>
        public static int Solution(int[] left, int[] right)
        {
            Array.Reverse(left);
            Array.Reverse(right);

            int[,] answers = new int[left.Length, right.Length];

            for(int i = 0 ; i < left.Length ; i++)
            {
                for(int j = 0 ; j < right.Length ; j++)
                {
                    answers[i, j] = 0;
                }
            }

            for(int i = 0 ; i < left.Length ; i++)
            {
                for(int j = 0 ; j < right.Length ; j++)
                {
                    if(left[i] > right[j])
                        answers[i, j] = (j - 1 >= 0 ? answers[i, j - 1] : 0) + right[j];
                    else
                        answers[i, j] = Math.Max(i - 1 >= 0 ? answers[i - 1, j] : 0, i - 1 >= 0 && j - 1 >= 0 ? answers[i - 1, j - 1] : 0);
                }
            }

            return answers[left.Length - 1, right.Length - 1];
        }
    }
}
