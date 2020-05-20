using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class PermutationCheck
    {
        public static bool Solution(int[] arr)
        {
            bool[] answer = new bool[arr.Length];
            
            foreach(int item in arr)
            {
                if(item > arr.Length)
                    return false;
                else if(answer[item-1])
                    return false;

                answer[item-1] = true;
            }

            return true;
        }
    }
}
