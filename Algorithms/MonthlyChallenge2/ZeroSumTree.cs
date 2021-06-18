using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 
    /// Algorithm.Algorithms.MonthlyChallenge2
    /// </summary>
    public class ZeroSumTree
    {
        /// <summary>
        /// 각 점에 가중치가 부여된 트리가 주어집니다. 당신은 다음 연산을 통하여, 이 트리의 모든 점들의 가중치를 0으로 만들고자 합니다.
        /// 임의의 연결된 두 점을 골라서 한쪽은 1 증가시키고, 다른 한쪽은 1 감소시킵니다.
        /// 하지만, 모든 트리가 위의 행동을 통하여 모든 점들의 가중치를 0으로 만들 수 있는 것은 아닙니다.
        /// 당신은 주어진 트리에 대해서 해당 사항이 가능한지 판별하고, 만약 가능하다면 최소한의 행동을 통하여 모든 점들의 가중치를 0으로 만들고자 합니다.
        /// 
        /// a의 길이는 2 이상 300,000 이하입니다.
        /// a의 모든 수는 각각 -1,000,000 이상 1,000,000 이하입니다.
        /// a[i] 는 i번 정점의 가중치를 의미합니다.
        /// 
        /// edges의 행의 개수는 (a의 길이 - 1)입니다.
        /// edges의 각 행은[u, v] 2개의 정수로 이루어져 있으며, 이는 u번 정점과 v번 정점이 간선으로 연결되어 있음을 의미합니다.
        /// edges가 나타내는 그래프는 항상 트리로 주어집니다.
        /// </summary>
        /// <param name="a">트리의 각 점의 가중치</param>
        /// <param name="edges">트리의 간선 정보</param>
        /// <returns>주어진 행동을 통해 트리의 모든 점들의 가중치를 0으로 만드는 것이 불가능하다면 -1을, 가능하다면 최소 몇 번만에 가능한지</returns>
        public static long Solution(int[] a, int[,] edges)
        {
            long answer = 0;

            bool[,] adjacent = new bool[a.Length, a.Length];
            for(int i = 0; i < edges.GetLength(0); i++)
            {
                adjacent[edges[i, 0], edges[i, 1]] = true;
                adjacent[edges[i, 1], edges[i, 0]] = true;
            }

            long[] longA = new long[a.Length];
            for(int i = 0; i < longA.Length; i++)
            {
                longA[i] = a[i];
            }

            bool[] visited = new bool[a.Length];

            Stack<(int current, int parent)> stack = new Stack<(int current, int parent)>();
            stack.Push((0, 0));

            while(stack.Count > 0)
            {
                (int current, int parent) vertex = stack.Pop();

                if(visited[vertex.current])
                {
                    a[vertex.parent] += a[vertex.current];
                    answer += Math.Abs(a[vertex.current]);
                    continue;
                }

                visited[vertex.current] = true;
                stack.Push(vertex);

                for(int i = 0; i < a.Length; i++)
                {
                    if(adjacent[vertex.current, i] && !visited[i])
                    {
                        stack.Push((i, vertex.current));
                    }
                }
            }

            return a[0] == 0 ?answer : -1;
        }
    }
}
