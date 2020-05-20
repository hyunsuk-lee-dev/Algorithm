using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43162\
    /// DFS/BFS
    /// </summary>
    public class Network
    {
        /// <summary>
        /// 네트워크란 컴퓨터 상호 간에 정보를 교환할 수 있도록 연결된 형태를 의미합니다. 
        /// 예를 들어, 컴퓨터 A와 컴퓨터 B가 직접적으로 연결되어있고, 
        /// 컴퓨터 B와 컴퓨터 C가 직접적으로 연결되어 있을 때 컴퓨터 A와 컴퓨터 C도 간접적으로 연결되어 정보를 교환할 수 있습니다. 
        /// 따라서 컴퓨터 A, B, C는 모두 같은 네트워크 상에 있다고 할 수 있습니다.
        /// </summary>
        /// <param name="n">컴퓨터의 개수</param>
        /// <param name="computers">연결에 대한 정보가 담긴 2차원 배열</param>
        /// <returns>네트워크의 개수</returns>
        public static int solution(int n, int[,] computers)
        {
            int answer = 0;
            bool[] networks = new bool[n];

            while(!networks.All(c => c))
            {
                int targetComputer = 0;
                for(int i = 0 ; i < n ; i++)
                {
                    if(!networks[i])
                    {
                        targetComputer = i;
                        break;
                    }
                }

                answer++;
                Stack<int> adjacents = new Stack<int>();
                adjacents.Push(targetComputer);

                while(adjacents.Count > 0)
                {
                    targetComputer = adjacents.Pop();
                    networks[targetComputer] = true;

                    for(int i = 0 ; i < n ; i++)
                    {
                        if(computers[targetComputer, i] == 1 && !networks[i])
                            adjacents.Push(i);
                    }
                }
            }

            return answer;
        }
    }
}
