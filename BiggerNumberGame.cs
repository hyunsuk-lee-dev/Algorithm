using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class BiggerNumberGame
    {
        public static int Solution(int[] A, int[] B)
        {
            int answer = 0;

            List<int> sortedA = A.ToList();
            sortedA.Sort();
            List<int> sortedB = B.ToList();
            sortedB.Sort();

            int winningGameIndex = sortedA.Count;
            for(int i = sortedB.Count -1 ; i >= 0 ; i--)
            {
                bool isWin = false;

                for(int j = winningGameIndex -1 ; j >= 0 ; j --)
                {
                    if(sortedB[i] > sortedA[j])
                    {
                        winningGameIndex = j;
                        answer++;
                        isWin = true;
                        break;
                    }
                }

                if(!isWin)
                    break;
            }

            return answer;
        }
    }
}
