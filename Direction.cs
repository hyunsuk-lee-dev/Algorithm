using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingTest
{
    public class Direction
    {
        class ArrayValueComparer<T> : IEqualityComparer<T[]>
        {
            public bool Equals(T[] x, T[] y)
            {
                if(x.Length != y.Length)
                    return false;

                for(int i = 0 ; i < x.Length ; i++)
                {
                    if(!x[i].Equals(y[i]))
                        return false;
                }

                return true;
            }

            public int GetHashCode(T[] obj)
            {
                return obj.GetHashCode();
            }
        }
        public static int Solution(string dirs)
        {
            ArrayValueComparer<Vector2> arrayValueComparer = new ArrayValueComparer<Vector2>();

            Vector2 position = new Vector2(0, 0);
            List<Vector2[]> steppedRoadList = new List<Vector2[]>();

            foreach(char direction in dirs)
            {
                Vector2 previousPosition = position;

                switch(direction)
                {
                    case 'U':
                        position.Y++;
                        break;
                    case 'D':
                        position.Y--;
                        break;
                    case 'R':
                        position.X++;
                        break;
                    case 'L':
                        position.X--;
                        break;
                    default:
                        break;
                }

                position.X = Math.Min(Math.Max(position.X, -5), 5);
                position.Y = Math.Min(Math.Max(position.Y, -5), 5);

                if(!steppedRoadList.Contains(new Vector2[2] { previousPosition, position }, arrayValueComparer) &&
                    !steppedRoadList.Contains(new Vector2[2] { position, previousPosition }, arrayValueComparer) &&
                    position != previousPosition)
                    steppedRoadList.Add(new Vector2[] { previousPosition, position });
            }

            return steppedRoadList.Count;
        }
    }
}
