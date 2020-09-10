using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms.Test
{
    public class Test
    {

        //public static int[] Solution(int[] numbers)
        //{
        //    List<int> answer = new List<int>();

        //    for(int i = 0 ; i < numbers.Length - 1 ; i++)
        //        for(int j = i + 1 ; j < numbers.Length ; j++)
        //        {
        //            int sum = numbers[i] + numbers[j];
        //            if(!answer.Contains(sum))
        //                answer.Add(sum);
        //        }

        //    answer.Sort();

        //    return answer.ToArray();
        //}

        //    public static int[] Solution(int n)
        //    {
        //        int[][] answer = new int[n][];

        //        for(int i = 0 ; i < n ; i++)
        //        {
        //            answer[i] = new int[i + 1];
        //            for(int j = 0 ; j < i + 1 ; j++)
        //                answer[i][j] = -1;
        //        }

        //        int xIndex = 0;
        //        int yIndex = 0;

        //        int direction = 0;

        //        answer[0][0] = 1;
        //        bool right = false;
        //        for(int i = 1 ; i < n * (n + 1) / 2 ; i++)
        //        {
        //            right = false;
        //            while(!right)
        //            {
        //                switch(direction)
        //                {
        //                    case 0:
        //                        if(xIndex + 1 < n && answer[xIndex + 1][yIndex] == -1)
        //                        {
        //                            xIndex++;
        //                            right = true;
        //                        }
        //                        else
        //                            direction = 1;
        //                        break;
        //                    case 1:
        //                        if(yIndex + 1 < n && answer[xIndex][yIndex+1] == -1)
        //                        {
        //                            yIndex++;
        //                            right = true;
        //                        }
        //                        else
        //                            direction = 2;
        //                        break;
        //                    case 2:
        //                        if(answer[xIndex - 1][yIndex - 1] == -1)
        //                        {
        //                            xIndex--;
        //                            yIndex--;
        //                            right = true;
        //                        }
        //                        else
        //                            direction = 0;
        //                        break;
        //                }
        //            }


        //            //direction = (direction + 1) % 3;

        //            answer[xIndex][yIndex] = i + 1;
        //        }


        //        List<int> answerList = new List<int>();
        //        for(int i = 0 ; i < n ; i++)
        //            answerList = answerList.Concat(answer[i]).ToList();

        //        return answerList.ToArray();

        //    }
        //}

        public static int IndexOfMin(IList<int> self)
        {
            if(self == null)
            {
                throw new ArgumentNullException("self");
            }

            if(self.Count == 0)
            {
                throw new ArgumentException("List is empty.", "self");
            }

            int min = self[0];
            int minIndex = 0;

            for(int i = 1 ; i < self.Count ; ++i)
            {
                if(self[i] < min)
                {
                    min = self[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public static int MinCount(List<int> min)
        {
            int ans = 0;

            for(int i = 0 ; i < min.Count ; i++)
            {
                i = IndexOfMin(min);

                ans++;
            }

            return ans;
        }

        public static int Solution(int[] a)
        {
            long elapsedTime = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<int> aList = a.ToList();

            Console.WriteLine($"Duration : {sw.ElapsedMilliseconds - elapsedTime}ms");
            elapsedTime = sw.ElapsedMilliseconds;

            int maxIndex = IndexOfMin(aList);

            Console.WriteLine($"Duration : {sw.ElapsedMilliseconds - elapsedTime}ms");
            elapsedTime = sw.ElapsedMilliseconds;

            List<int> leftA = aList.GetRange(0, maxIndex);
            Console.WriteLine($"Duration : {sw.ElapsedMilliseconds - elapsedTime}ms");
            elapsedTime = sw.ElapsedMilliseconds;

            leftA.Reverse();
            Console.WriteLine($"Duration : {sw.ElapsedMilliseconds - elapsedTime}ms");
            elapsedTime = sw.ElapsedMilliseconds;

            List<int> rightA = aList.GetRange(maxIndex + 1, aList.Count - maxIndex - 1);
            Console.WriteLine($"Duration : {sw.ElapsedMilliseconds - elapsedTime}ms");
            elapsedTime = sw.ElapsedMilliseconds;

            int leftCount = MinCount(leftA);

            Console.WriteLine($"Duration : {sw.ElapsedMilliseconds - elapsedTime}ms");
            elapsedTime = sw.ElapsedMilliseconds;


            int rightCount = MinCount(rightA);

            Console.WriteLine($"Duration : {sw.ElapsedMilliseconds - elapsedTime}ms");
            elapsedTime = sw.ElapsedMilliseconds;

            return leftCount + rightCount + 1;
        }
    }
}
