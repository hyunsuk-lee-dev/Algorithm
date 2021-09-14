using Algorithm.Algorithms;
using Algorithm.Functions;

using System;
using System.Diagnostics;

namespace Algorithm
{
    public static class MainClass
    {
        private static Stopwatch stopwatch = new Stopwatch();
        private static long elapsedTime = 0;

        public static void Main(string[] args)
        {
            stopwatch.Start();

            Show(CheckInCheckOut.Solution(new int[4] { 1, 4, 2, 3 }, new int[4] { 2, 1, 3, 4 }).ToStrings()); // 2,2,1,3

            Show(CheckInCheckOut.Solution(new int[3] { 1, 3, 2 }, new int[3] { 1, 2, 3 }).ToStrings()); // 0,1,1
            Show(CheckInCheckOut.Solution(new int[3] { 3, 2, 1 }, new int[3] { 2, 1, 3 }).ToStrings()); // 1,1,2
            Show(CheckInCheckOut.Solution(new int[3] { 3, 2, 1 }, new int[3] { 1, 3, 2 }).ToStrings()); // 2,2,2
            Show(CheckInCheckOut.Solution(new int[4] { 1, 4, 2, 3 }, new int[4] { 2, 1, 4, 3 }).ToStrings()); // 2,2,0,2
        }

        public static void Show(object solution)
        {
            Console.WriteLine($"Answer: {solution}");
            Console.WriteLine($"Duration: {stopwatch.ElapsedMilliseconds - elapsedTime}ms");
            elapsedTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine();
        }
    }
}