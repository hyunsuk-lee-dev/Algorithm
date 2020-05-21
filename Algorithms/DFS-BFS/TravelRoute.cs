using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms.DFS_BFS
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43164
    /// DFS/BFS
    /// </summary>
    public class TravelRoute
    {
        class StringArrayComparer : IComparer<string[]>
        {
            public int index;

            public StringArrayComparer(int index)
            {
                this.index = index;
            }

            public int Compare(string[] x, string[] y)
            {
                if(x.Length > index && y.Length > index)
                    return x[index].CompareTo(y[index]);
                else
                    return 0;
            }
        }

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
        public static string[] Solution(string[,] tickets, string department)
        {
            List<string> cities = new List<string>();
            List<string[]> ticketList = new List<string[]>();

            Console.WriteLine(department + "======");

            for(int i = 0 ; i < tickets.GetLength(0) ; i++)
            {
                string[] ticket = new string[tickets.GetLength(1)];
                for(int j = 0 ; j < tickets.GetLength(1) ; j++)
                    ticket[j] = tickets[i, j];

                ticketList.Add(ticket);
            }
            StringArrayComparer stringArrayComparer = new StringArrayComparer(1);
            ticketList.Sort(stringArrayComparer);

            List<string[]> availableTickets = new List<string[]>();

            cities.Add(department);

            for(int i = 0 ; i < ticketList.Count ; i++)
            {
                if(ticketList[i][0] == department)
                {
                    availableTickets.Add(ticketList[i]);
                }
            }

           
            return cities.ToArray();
        }

        static string[,] ConvertArray(string[][] value)
        {
            string[,] result = new string[value.Length, value[0].Length];

            for(int i = 0 ; i < value.Length ; i++)
            {
                for(int j = 0 ; j < value[0].Length ; j++)
                    result[i, j] = value[i][j];

            }
            return result;
        }
    }

    
}
