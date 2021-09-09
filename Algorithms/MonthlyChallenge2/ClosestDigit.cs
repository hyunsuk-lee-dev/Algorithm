using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Functions
{
    public class ClosestDigit
    {
        public static long[] Solution(long[] numbers)
        {
            long[] answer = new long[numbers.Length];

            for(int i = 0; i < numbers.Length; i++)
            {
                answer[i] = FindClosestDigitNumber(numbers[i]);
            }

            return answer;
        }

        public static long FindClosestDigitNumber(long number)
        {
            char[] binaryCharArray = Convert.ToString(number, 2).ToArray();
            char[] reversedBinaryCharArray = binaryCharArray.Reverse().ToArray();

            for(int i = 0; i < reversedBinaryCharArray.Length; i++)
            {
                if(reversedBinaryCharArray[i] == '0')
                {
                    reversedBinaryCharArray[i] = '1';
                    if(i > 0)
                    {
                        reversedBinaryCharArray[i - 1] = '0';
                    }
                    return Convert.ToInt32(new string(reversedBinaryCharArray.Reverse().ToArray()), 2);
                }
            }

            return (number + 1) + (number + 1) / 2 - 1;



            /*long answer = number + 1;

            while(CompareString(Convert.ToString(number, 2), Convert.ToString(answer, 2)) > 2)
            {
                answer++;
            }

            return answer;*/
        }

        public static int CompareString(string a, string b)
        {
            char[] aArray= a.Reverse().ToArray();
            char[] bArray = b.Reverse().ToArray();

            int answer = 0;
            if(aArray.Length != bArray.Length)
            {
                answer++;
            }
            for(int i = 0; i < Math.Min(aArray.Length, bArray.Length); i++)
            {
                if(aArray[i] != bArray[i])
                {
                    answer++;
                }
            }

            return answer;
        }
    }
}
