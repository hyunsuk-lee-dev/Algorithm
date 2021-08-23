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

            Show(CareerRecommend.Solution(
                new string[] { "SI JAVA JAVASCRIPT SQL PYTHON C#", "CONTENTS JAVASCRIPT JAVA PYTHON SQL C++", "HARDWARE C C++ PYTHON JAVA JAVASCRIPT",
                    "PORTAL JAVA JAVASCRIPT PYTHON KOTLIN PHP", "GAME C++ C# JAVASCRIPT C JAVA" },
                new string[] { "PYTHON", "C++", "SQL" },
                new int[] { 7, 5, 5 })); // HARDWARE

            Show(CareerRecommend.Solution(
                new string[] { "SI JAVA JAVASCRIPT SQL PYTHON C#", "CONTENTS JAVASCRIPT JAVA PYTHON SQL C++", "HARDWARE C C++ PYTHON JAVA JAVASCRIPT",
                    "PORTAL JAVA JAVASCRIPT PYTHON KOTLIN PHP", "GAME C++ C# JAVASCRIPT C JAVA" },
                new string[] { "JAVA", "JAVASCRIPT" },
                new int[] { 7, 5 })); // PORTAL
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