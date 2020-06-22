using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Functions
{
    public class PrimeNumber
    {
        public static int[] PrimeNumbers(int max)
        {
            List<int> answers = new List<int>();

            for(int i = 0 ; i < max ; i++)
                answers.Add(i + 1);

            answers.Remove(1);

            for(int i = 2 ; i < Math.Sqrt(max) ; i++)
            {

            }

            return answers.ToArray();
        }
    }
}
