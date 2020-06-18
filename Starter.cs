using Algorithm.Algorithms;
using Algorithm.Algorithms.Brute_Force;
using Algorithm.Algorithms.Heap;
using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    static class Starter
    {

        static Stopwatch stopwatch = new Stopwatch();
        static long elapsedTime = 0;
        static void Main(string[] args)
        {
            stopwatch.Start();

            #region Older Code
            //Console.WriteLine((Tower.Solution(new int[] { 6, 9, 5, 7, 4 })).ArrayToString());
            //Console.WriteLine((Tower.Solution(new int[] { 3, 9, 9, 3, 5, 7, 2 })).ArrayToString());
            //Console.WriteLine((Tower.Solution(new int[] { 1, 5, 3, 6, 7, 6, 5 })).ArrayToString());


            //Console.WriteLine(BiggerNumberGame.Solution(new int[] { 5, 1, 3, 7 }, new int[] { 2, 1, 6, 8 }));
            //Console.WriteLine(BiggerNumberGame.Solution(new int[] { 2, 2, 2, 2, 2, 2 }, new int[] { 1, 1, 1, 1, 1, 2 }));


            //Console.WriteLine(Cookie.Solution(new int[] { 1, 1, 2, 3 }));
            //Console.WriteLine(Cookie.Solution(new int[] { 1, 1, 2, 3, 1 }));
            //Console.WriteLine(Cookie.Solution(new int[] { 1, 2, 4, 5 }));


            //Console.WriteLine(Sticker.Solution(new int[] { 14, 6, 5, 11, 3, 9, 2, 10 }));
            //Console.WriteLine(Sticker.Solution(new int[] { 1, 3, 2, 5, 4 }));


            //DirectionSimulation directionSimulation = new DirectionSimulation("RDLLURRDLLUR");
            //directionSimulation.Show();
            //Console.WriteLine(Direction.Solution("RDLLURRDLLUR"));


            //Console.WriteLine(DigitSum.Solution(946));


            //Console.WriteLine(PermutationCheck.Solution(new int[] { 4, 1, 3, 2 ,5 }));
            //Console.WriteLine(PermutationCheck.Solution(new int[] { 4, 1, 3, 1 }));


            //Console.WriteLine(RemainderPoint.Solution(new int[,] { { 1, 4 }, { 3, 4 }, { 3, 10 } }).ArrayToString());
            //Console.WriteLine(RemainderPoint.Solution(new int[,] { { 1, 1 }, { 2, 2 }, { 1, 2 } }).ArrayToString());


            //Console.WriteLine(WordPuzzle.Solution(new string[] { "app", "ap", "p", "l", "e", "ple", "pp" }, "apple"));
            //Console.WriteLine(WordPuzzle.Solution(new string[] { "ba", "na", "n", "a" }, "banana"));
            //Console.WriteLine(WordPuzzle.Solution(new string[] { "ba", "an", "nan", "ban", "n" }, "banana"));


            //Console.WriteLine(Tournament.Solution(8,4,7));


            //Console.WriteLine(EquationN.Solution(5,24));
            //Console.WriteLine(EquationN.Solution(2,11));

            //Console.WriteLine(Tiles.Solution(5));
            //Console.WriteLine(Tiles.Solution(6));


            //Console.WriteLine(TargetNumber.Solution(new int[] { 1, 1, 1, 1, 1 } , 3));


            //Console.WriteLine(Network.solution(3 , new int[,] { { 1, 1, 0, }, { 1, 1, 0 }, { 0, 0, 1 } }));
            //Console.WriteLine(Network.solution(3 , new int[,] { { 1, 1, 0, }, { 1, 1, 1 }, { 0, 1, 1 } }));


            //Console.WriteLine(WordChanger.Solution("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }));
            //Console.WriteLine(WordChanger.Solution("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log" }));


            //Console.WriteLine(TravelRoute.Solution(
            //    new string[,] { { "ICN", "JFK" }, { "HND", "IAD" }, { "JFK", "HND" } }).ArrayToString());
            //Console.WriteLine(TravelRoute.Solution(
            //    new string[,] { { "ICN", "SFO" }, { "ICN", "ATL" }, { "SFO", "ATL" }, { "ATL", "ICN" }, { "ATL", "SFO" } }).ArrayToString());


            // Console.WriteLine(NumberBaseball.Solution(new int[,] { { 123, 1, 1 }, { 356, 1, 0 }, { 327, 2, 0 }, { 489, 0, 1 } }));


            //Console.WriteLine(BestAlbum.Solution(
            //    new string[] { "classic", "pop", "classic", "classic", "pop" , "rock"},
            //    new int[] { 500, 600, 150, 800, 2500 , 50000 })
            //    .ArrayToString());


            //Console.WriteLine(IntegerTriangle.Solution(new List<List<int>>{new List<int>{ 7 }, new List<int> { 3, 8 },
            //    new List<int> { 8, 1, 0 }, new List<int>{ 2, 7, 4, 4 }, new List<int>{ 4, 5, 2, 6, 5 } }));


            //Show(TruckBridge.Solution(2, 10, new int[] { 7, 4, 5, 6 }));
            //Show(TruckBridge.Solution(100, 100, new int[] { 10 }));
            //Show(TruckBridge.Solution(100, 100, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }));
            //Show(TruckBridge.Solution(9000, 101, new int[] { 101, 101, 101, 101, 101, 101, 101, 101 }));


            //Show(Developement.Solution(new int[] { 93, 30, 55 }, new int[] { 1, 30, 5 }).ArrayToString());


            //Show(PipeCutting.Solution("()(((()())(())()))(())"));


            //Show(PrinterQueue.Solution(new int[] { 2, 1, 3, 2 }, 2));
            //Show(PrinterQueue.Solution(new int[] { 1, 1, 9, 1, 1, 1 }, 0));
            #endregion

            //Show(StockPrice.Solution(new int[] { 1, 2, 3, 2, 3 }).ArrayToString());            
            //Show(StockPrice.Solution(new int[] { 1, 4, 2, 5, 6, 7, 4, 5 }).ArrayToString());
            //Show(StockPrice.Solution(new int[] { 1, 2, 3, 4, 5, 1, 1 }).ArrayToString());
            //Show(StockPrice.Solution(new int[] { 1, 2, 3, 2, 3, 1 }).ArrayToString());


            //Show(SpicyFood.Solution(new int[] { 1, 2, 3, 9, 10, 12 }, 7));


            //Show(NoodleFactory.Solution(4, new int[] { 4, 10, 15 }, new int[] { 20, 5, 10 }, 30));
            //Show(NoodleFactory.Solution(31, new int[] { 4, 10, 15 }, new int[] { 20, 5, 10 }, 30));


            //Show(DiscController.Solution(new int[,] { { 0, 3 }, { 1, 9 }, { 2, 6 } }));


            //Show(DoublePriorityQueue.Solution(new string[] { "I 16", "D 1" }).ArrayToString());
            ////[0,0]
            //Show(DoublePriorityQueue.Solution(new string[] { "I 7", "I 5", "I -5", "D -1" }).ArrayToString());
            ////[7,5]

            //Show(Carpet.solution(24, 24).ArrayToString());
            //Show(Carpet.solution(10, 2).ArrayToString());
           
        }

        static void Show(object solution)
        {
            Console.WriteLine(solution);
            Console.WriteLine($"Duration : {stopwatch.ElapsedMilliseconds - elapsedTime}ms");
            elapsedTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine();
        }
    }
}
