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
            List<int> numbers = new List<int>();

            for(int i = 2 ; i <= max ; i++)
                numbers.Add(i);

            int numberIndex = 0;

            while(numbers[numberIndex] <= Math.Sqrt(max))
            {
                int number = numbers[numberIndex++];
                numbers.RemoveAll(x => x > number && x % number == 0);
            }

            return numbers.ToArray();
        }
    }
}
