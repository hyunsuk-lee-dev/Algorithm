using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Linq;
using Algorithm.Algorithms.Tree;

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

            if(a.Length == 1)
            {
                return 0;
            }

            Tree<int> tree = new Tree<int>();
            tree.rootNode = new TreeNode<int>(a[0]);

            List<int[]> edgeList = edges.Convert2DArrayToList();





            List<int> aList = a.ToList();


            List<int> edgeCounts = new List<int>(aList);
            for(int i = 0; i < edgeCounts.Count; i++)
            {
                edgeCounts[i] = 0;
            }

            for(int i = 0; i < edgeList.Count; i++)
            {
                edgeCounts[edgeList[i][0]]++;
                edgeCounts[edgeList[i][1]]++;
            }

            int move = 0;


            for(int i = 0; i < edgeCounts.Count; i++)
            {
                if(edgeCounts[i] == 1)
                {
                    aList.RemoveAt(i);
                    edgeCounts.RemoveAt(i);

                    edgeList = edgeList.FindAll(o => o[0] != i && o[1] != i);

                    for(int j = 0; j < edgeList.Count; j++)
                    {
                        if(edgeList[j][0] > i)
                        {
                            edgeList[j][0]--;
                        }
                        else if(edgeList[j][1] > i)
                        {
                            edgeList[j][1]--;
                        }
                    }

                    break;
                }
            }

            return 0;
        }
    }
}
