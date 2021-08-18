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

            Show(LongestPalindrome.Solution("abcdcba"));
            Show(LongestPalindrome.Solution("abaaba"));
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