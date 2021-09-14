using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 입실 퇴실
    /// https://programmers.co.kr/learn/courses/30/lessons/86048
    /// Algorithm.Algorithms.WeeklyChanllenge
    /// </summary>
    public class CheckInCheckOut
    {
        /// <summary>
        /// 사회적 거리두기를 위해 회의실에 출입할 때 명부에 이름을 적어야 합니다. 
        /// 입실과 퇴실이 동시에 이뤄지는 경우는 없으며, 입실 시각과 퇴실 시각은 따로 기록하지 않습니다.
        /// 
        /// 오늘 회의실에는 총 n명이 입실 후 퇴실했습니다. 
        /// 편의상 사람들은 1부터 n까지 번호가 하나씩 붙어있으며, 두 번 이상 회의실에 들어온 사람은 없습니다. 
        /// 이때, 각 사람별로 반드시 만난 사람은 몇 명인지 구하려 합니다.
        /// 
        /// </summary>
        /// <param name="enter">회의실에 입실한 순서가 담긴 정수 배열</param>
        /// <param name="leave">퇴실한 순서가 담긴 정수 배열</param>
        /// <returns> 각 사람별로 반드시 만난 사람은 몇 명인지 번호 순서대로 배열</returns>
        /// <limit>
        /// 1 ≤ enter의 길이 ≤ 1,000
        /// 1 ≤ enter의 원소 ≤ enter의 길이
        ///     모든 사람의 번호가 중복없이 하나씩 들어있습니다.
        /// leave의 길이 = enter의 길이
        /// 1 ≤ leave의 원소 ≤ leave의 길이
        ///     모든 사람의 번호가 중복없이 하나씩 들어있습니다.
        /// </limit>
        public static int[] Solution(int[] enter, int[] leave)
        {
            int number = enter.Length;
            int[,] meets = new int[number, number];
            for(int i = 0; i < number; i++)
            {
                for(int j = 0; j < number; j++)
                {
                    meets[i, j] = 0;
                }
            }

            List<int> room = new List<int>();

            int enterIndex = 0;
            int leaveIndex = 0;

            while(leaveIndex < number)
            {
                while(!room.Contains(leave[leaveIndex] - 1))
                {
                    int enterMan = enter[enterIndex] - 1;
                    room.Add(enterMan);

                    foreach(int man in room)
                    {
                        meets[man, enterMan] = 1;
                        meets[enterMan, man] = 1;
                    }

                    enterIndex++;
                }

                while(leaveIndex < number && room.Contains(leave[leaveIndex] - 1))
                {
                    room.Remove(leave[leaveIndex] - 1);
                    leaveIndex++;
                }
            }


            int[] answer = new int[number];
            for(int i = 0; i < number; i++)
            {
                int meet = 0;
                for(int j = 0; j < number; j++)
                {
                    if(i != j)
                    {
                        meet += meets[i, j];
                    }
                }
                answer[i] = meet;
            }

            return answer;
        }
    }
}
