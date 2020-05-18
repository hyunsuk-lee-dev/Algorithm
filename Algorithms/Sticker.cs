using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Sticker
    {
        public static int Solution(int[] sticker)
        {
            if(sticker.Length == 1)
                return sticker[0];

            int[] first = new int[sticker.Length];
            int[] second = new int[sticker.Length];

            first[0] = sticker[0];
            first[1] = sticker[0];

            second[0] = 0;
            second[1] = sticker[1];

            for(int i = 2 ; i < sticker.Length ; i++)
            {
                if(i < sticker.Length -1)
                    first[i] = Math.Max(first[i - 1], first[i - 2] + sticker[i]);

                second[i] = Math.Max(second[i - 1], second[i - 2] + sticker[i]);
            }


            return Math.Max(first[sticker.Length-2] , second[sticker.Length-1]);
        }

    }
}
