using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class DigitSum
    {
        public static int Solution(int n)
        {
            if(n < 10)
                return n;

            return n % 10 + Solution(n / 10);
        }
    }
}
