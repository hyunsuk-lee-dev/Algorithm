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

            Show(GameMapShortestPath.Solution("[[1,0,1,1,1],[1,0,1,0,1],[1,0,1,1,1],[1,1,1,0,1],[0,0,0,0,1]]".ToMultiArrays<int>())); // 11
            Show(GameMapShortestPath.Solution("[[1,0,1,1,1],[1,0,1,0,1],[1,0,1,1,1],[1,1,1,0,0],[0,0,0,0,1]]".ToMultiArrays<int>())); // -1
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