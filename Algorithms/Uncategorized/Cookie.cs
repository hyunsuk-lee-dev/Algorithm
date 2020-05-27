using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    public class Cookie
    {
        public static int Solution(int[] cookie)
        {
            int answer = 0;

            int sumLefthand = 0;
            int sumRighthand = 0;

            for(int m = 0 ; m < cookie.Length - 1 ; m++)
            {
                int l = m;
                int r = m + 1;

                sumLefthand = cookie[l];
                sumRighthand = cookie[r];


                while( l >= 0 && r <= cookie.Length-1)
                {
                    if(sumLefthand < sumRighthand)
                    {
                        sumLefthand += --l >= 0 ? cookie[l] : 0;
                    }
                    else if(sumLefthand > sumRighthand)
                    {
                        sumRighthand += ++r <= cookie.Length -1  ? cookie[r] : 0;
                    }
                    else
                    {
                        answer = Math.Max(answer, sumLefthand);

                        sumLefthand += --l >= 0 ? cookie[l] : 0;
                        sumRighthand += ++r <= cookie.Length - 1 ? cookie[r] : 0;
                    }
                }
            }

            return answer;
        }
    }
}
