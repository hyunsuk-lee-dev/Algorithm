using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/49189
    /// Graph
    /// </summary>
    public class FarthestNode
    {
        /// <summary>
        /// n개의 노드가 있는 그래프가 있습니다. 각 노드는 1부터 n까지 번호가 적혀있습니다. 
        /// 1번 노드에서 가장 멀리 떨어진 노드의 갯수를 구하려고 합니다. 
        /// 가장 멀리 떨어진 노드란 최단경로로 이동했을 때 간선의 개수가 가장 많은 노드들을 의미합니다.
        /// 
        /// 제한사항
        /// 노드의 개수 n은 2 이상 20,000 이하입니다.
        /// 간선은 양방향이며 총 1개 이상 50,000개 이하의 간선이 있습니다.
        /// vertex 배열 각 행 [a, b] 는 a번 노드와 b번 노드 사이에 간선이 있다는 의미입니다.
        /// </summary>
        /// <param name="n">노드의 개수</param>
        /// <param name="edge">간선에 대한 정보가 담긴 2차원 배열</param>
        /// <returns>1번 노드로부터 가장 멀리 떨어진 노드의 수</returns>
        public static int Solution(int n, int[,] edge)
        {
            Queue<int> vertices = new Queue<int>();

            int[] distances = new int[n];

            for(int i = 0 ; i < n ; i++)
                distances[i] = n + 1;

            distances[0] = 0;
            vertices.Enqueue(0);

            while(vertices.Count > 0)
            {
                int vertex = vertices.Dequeue();

                for(int i = 0 ; i < edge.GetLength(0) ; i++)
                {
                    if(edge[i, 0] - 1 == vertex && distances[vertex] + 1 < distances[edge[i, 1] - 1])
                    {
                        distances[edge[i, 1] - 1] = distances[vertex] + 1;
                        vertices.Enqueue(edge[i, 1] - 1);
                    }
                    else if(edge[i, 1] - 1 == vertex && distances[vertex] + 1 < distances[edge[i, 0] - 1])
                    {
                        distances[edge[i, 0] - 1] = distances[vertex] + 1;
                        vertices.Enqueue(edge[i, 0] - 1);
                    }
                }
            }

            return Array.FindAll(distances, x => x == distances.Max()).Length;
        }
    }
}
