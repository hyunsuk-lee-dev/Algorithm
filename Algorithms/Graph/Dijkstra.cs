using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 다익스트라 알고리즘
    /// Algorithm.Algorithms.Graph
    /// </summary>
    public class Dijkstra
    {
        private static int maxCost = 100;

        public static int[] Solution(int[,] graph, int start)
        {
            Debug.Assert(graph.GetLength(0) == graph.GetLength(1), "Graph must have same row and column");

            int size = graph.GetLength(0);
            int[] distances = new int[size];
            bool[] visited = new bool[size];
            for(int i = 0; i < size; i++)
            {
                distances[i] = graph[start, i];
                visited[i] = false;
            }

            visited[start] = true;

            for(int i = 0; i < size -2; i++)
            {
                int current = GetMinDistanceIndex(distances, visited);

                for(int j = 0; j < size; j++)
                {
                    distances[j] = Math.Min(distances[j], distances[current] + graph[current, j]);
                }

                visited[current] = true;
            }

            //for(int i = 0; i < size; i++)
            //{
            //    distances[i] = distances[i] == maxCost ? int.MaxValue : distances[i];
            //}

            return distances;
        }

        private static int GetMinDistanceIndex(int[] distances, bool[] visited)
        {
            int min = maxCost;
            int minIndex = -1;

            for(int i = 0; i< distances.Length; i++)
            {
                if(!visited[i] && distances[i] < min)
                {
                    min = distances[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
