using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class RemainderPoint
    {
        public static int[] Solution(int[,] v)
        {
            List<int> xCoordinates = new List<int>();
            List<int> yCoordinates = new List<int>();
            
            for(int i = 0 ; i < v.GetLength(0) ; i++)
            {
                if(xCoordinates.Contains(v[i, 0]))
                    xCoordinates.Remove(v[i, 0]);
                else
                    xCoordinates.Add(v[i, 0]);
                
                if(yCoordinates.Contains(v[i, 1]))
                    yCoordinates.Remove(v[i, 1]);
                else
                    yCoordinates.Add(v[i, 1]);

            }

            return new int[] { xCoordinates[0], yCoordinates[0] };
            
        }
    }
}
