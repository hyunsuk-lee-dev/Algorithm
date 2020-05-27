using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/12985
    /// </summary>
    public class Tournament
    {
        /// <summary>
        /// △△ 게임대회가 개최되었습니다. 이 대회는 N명이 참가하고, 토너먼트 형식으로 진행됩니다. 
        /// N명의 참가자는 각각 1부터 N번을 차례대로 배정받습니다. 그리고, 1번↔2번, 3번↔4번, ... , N-1번↔N번의 참가자끼리 게임을 진행합니다. 
        /// 각 게임에서 이긴 사람은 다음 라운드에 진출할 수 있습니다. 이때, 다음 라운드에 진출할 참가자의 번호는 다시 1번부터 N/2번을 차례대로 배정받습니다. 
        /// 만약 1번↔2번 끼리 겨루는 게임에서 2번이 승리했다면 다음 라운드에서 1번을 부여받고, 
        /// 3번↔4번에서 겨루는 게임에서 3번이 승리했다면 다음 라운드에서 2번을 부여받게 됩니다. 
        /// 게임은 최종 한 명이 남을 때까지 진행됩니다.
        /// 
        /// 이때, 처음 라운드에서 A번을 가진 참가자는 경쟁자로 생각하는 B번 참가자와 몇 번째 라운드에서 만나는지 궁금해졌습니다.
        /// </summary>
        /// <param name="n"> 게임 참가자 수, 2^1 이상 2^20 이하인 자연수 (2의 지수 승으로 주어지므로 부전승은 발생하지 않습니다.) </param>
        /// <param name="a"> 참가자 번호, N 이하인 자연수 </param>
        /// <param name="b"> 경쟁자 번호, N 이하인 자연수 </param>
        /// <returns> 처음 라운드에서 A번을 가진 참가자는 경쟁자로 생각하는 B번 참가자와 몇 번째 라운드에서 만나는지 </returns>
        /// 단, A번 참가자와 B번 참가자는 서로 붙게 되기 전까지 항상 이긴다고 가정합니다.
        public static int Solution(int n, int a, int b)
        {
            int answer = 0;

            a--;
            b--;

            while(a != b)
            {
                a /= 2;
                b /= 2;
                answer++;
            }

            return answer;
        }
    }
}
