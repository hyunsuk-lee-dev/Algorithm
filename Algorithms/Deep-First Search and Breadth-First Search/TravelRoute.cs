using Algorithm.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43164
    /// DFS/BFS
    /// </summary>
    public class TravelRoute
    {
        /// <summary>
        /// 주어진 항공권을 모두 이용하여 여행경로를 짜려고 합니다. 항상 ICN 공항에서 출발합니다.
        /// </summary>
        /// <param name="tickets">항공권 정보가 담긴 2차원 배열</param>
        /// <returns>방문하는 공항 경로의 배열</returns>
        /// 모든 공항은 알파벳 대문자 3글자로 이루어집니다.
        /// 주어진 공항 수는 3개 이상 10,000개 이하입니다.
        /// tickets의 각 행[a, b] 는 a 공항에서 b 공항으로 가는 항공권이 있다는 의미입니다.
        /// 주어진 항공권은 모두 사용해야 합니다.
        /// 만일 가능한 경로가 2개 이상일 경우 알파벳 순서가 앞서는 경로를 return 합니다.
        /// 모든 도시를 방문할 수 없는 경우는 주어지지 않습니다.
        public static string[] Solution(string[,] tickets)
        {
            List<string[]> ticketList = tickets.Convert2DArrayToList();

            StringArrayComparer stringArrayComparer = new StringArrayComparer(1);
            ticketList.Sort(stringArrayComparer);


            Tuple<bool, List<string>> result = TryTravelRoute(ticketList, "ICN");

            return result.Item2.ToArray();
        }

        static Tuple<bool, List<string>> TryTravelRoute(List<string[]> ticketList, string department)
        {
            List<string> cities = new List<string>();

            if(ticketList.Count == 1)
            {
                if(ticketList[0][0] == department)
                {
                    cities.Add(department);
                    cities.Add(ticketList[0][1]);
                    return new Tuple<bool, List<string>>(true, cities);
                }
                else
                    return new Tuple<bool, List<string>>(false, null);
            }


            for(int i = 0 ; i < ticketList.Count ;i++)
            {
                string[] ticket = ticketList[i];

                if(ticket[0] == department)
                {
                    List<string[]> ticketListTemp = new List<string[]>(ticketList);
                    ticketListTemp.RemoveAt(i);
                    Tuple<bool, List<string>> result = TryTravelRoute(ticketListTemp, ticket[1]);
                    if(result.Item1)
                    {
                        cities.Add(department);
                        cities.AddRange(result.Item2);
                        return new Tuple<bool, List<string>>(true, cities);
                    }
                        
                }
            }

            return new Tuple<bool, List<string>>(false, null);
        }
    }

    
}
