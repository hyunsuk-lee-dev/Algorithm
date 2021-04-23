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
        /// 
        /// </summary>
        /// <param name="absolutes"></param>
        /// <param name="signs"></param>
        /// <returns></returns>
        public static long Solution(int[] a, int[,] edges)
        {
            if(a.Sum() != 0)
            {
                return -1;
            }
            else if(a.Length == 2 && edges.Length > 0)
            {
                return Math.Abs(a[0]);
            }

            int[] edgeCount = new int[a.Length];
            for(int aIndex = 0; aIndex < a.Length; aIndex++)
            {
                edgeCount[aIndex] = 0;

                for(int edgeIndex = 0; edgeIndex < edges.GetLength(0); edgeIndex++)
                {
                    if(edges[edgeIndex, 0] == aIndex || edges[edgeIndex, 1] == aIndex)
                    {
                        edgeCount[aIndex]++;
                    }
                }
            }

            int targetAIndex = Array.IndexOf(edgeCount, 1);


            List<int> aList = a.ToList();
            List<int[]> edgeList = edges.Convert2DArrayToList();

            for(int edgeIndex = 0; edgeIndex < edges.GetLength(0); edgeIndex++)
            {
                int count = aList[targetAIndex];
                if(edgeList[edgeIndex][0] == targetAIndex)
                {
                    aList[edgeList[edgeIndex][1]] += aList[targetAIndex];
                    aList[targetAIndex] = 0;
                }
                else if(edges[edgeIndex, 1] == targetAIndex)
                {
                    aList[edgeList[edgeIndex][0]] += aList[targetAIndex];
                    aList[targetAIndex] = 0;
                }
                else
                {
                    continue;
                }

                aList.RemoveAt(targetAIndex);
                edgeList.RemoveAt(edgeIndex);

                for(int i = 0; i < edgeList.Count; i++)
                {
                    if(edgeList[i][0] > targetAIndex)
                    { 
                        edgeList[i][0]--;
                    }

                    if(edgeList[i][1] > targetAIndex)
                    {
                        edgeList[i][1]--;
                    }
                }

                return Solution(aList.ToArray(), edgeList.ConvertListTo2DArray()) + Math.Abs(count);
            }

            return -1;
        }
    }
}
