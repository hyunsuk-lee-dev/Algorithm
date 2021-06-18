using Algorithm.Algorithms;
using Algorithm.Algorithms.Brute_Force;
using Algorithm.Algorithms.Heap;
using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    static class MainClass
    {
        static Stopwatch stopwatch = new Stopwatch();
        static long elapsedTime = 0;

        static void Main(string[] args)
        {
            stopwatch.Start();

            #region Older Code
            /*
            Console.WriteLine((Tower.Solution(new int[] { 6, 9, 5, 7, 4 })).ArrayToString());
            Console.WriteLine((Tower.Solution(new int[] { 3, 9, 9, 3, 5, 7, 2 })).ArrayToString());
            Console.WriteLine((Tower.Solution(new int[] { 1, 5, 3, 6, 7, 6, 5 })).ArrayToString());


            Console.WriteLine(BiggerNumberGame.Solution(new int[] { 5, 1, 3, 7 }, new int[] { 2, 1, 6, 8 }));
            Console.WriteLine(BiggerNumberGame.Solution(new int[] { 2, 2, 2, 2, 2, 2 }, new int[] { 1, 1, 1, 1, 1, 2 }));


            Console.WriteLine(Cookie.Solution(new int[] { 1, 1, 2, 3 }));
            Console.WriteLine(Cookie.Solution(new int[] { 1, 1, 2, 3, 1 }));
            Console.WriteLine(Cookie.Solution(new int[] { 1, 2, 4, 5 }));


            Console.WriteLine(Sticker.Solution(new int[] { 14, 6, 5, 11, 3, 9, 2, 10 }));
            Console.WriteLine(Sticker.Solution(new int[] { 1, 3, 2, 5, 4 }));


            DirectionSimulation directionSimulation = new DirectionSimulation("RDLLURRDLLUR");
            directionSimulation.Show();
            Console.WriteLine(Direction.Solution("RDLLURRDLLUR"));


            Console.WriteLine(DigitSum.Solution(946));


            Console.WriteLine(PermutationCheck.Solution(new int[] { 4, 1, 3, 2, 5 }));
            Console.WriteLine(PermutationCheck.Solution(new int[] { 4, 1, 3, 1 }));


            Console.WriteLine(RemainderPoint.Solution(new int[,] { { 1, 4 }, { 3, 4 }, { 3, 10 } }).ArrayToString());
            Console.WriteLine(RemainderPoint.Solution(new int[,] { { 1, 1 }, { 2, 2 }, { 1, 2 } }).ArrayToString());


            Console.WriteLine(WordPuzzle.Solution(new string[] { "app", "ap", "p", "l", "e", "ple", "pp" }, "apple"));
            Console.WriteLine(WordPuzzle.Solution(new string[] { "ba", "na", "n", "a" }, "banana"));
            Console.WriteLine(WordPuzzle.Solution(new string[] { "ba", "an", "nan", "ban", "n" }, "banana"));


            Console.WriteLine(Tournament.Solution(8, 4, 7));


            Console.WriteLine(EquationN.Solution(5, 24));
            Console.WriteLine(EquationN.Solution(2, 11));

            Console.WriteLine(Tiles.Solution(5));
            Console.WriteLine(Tiles.Solution(6));


            Console.WriteLine(TargetNumber.Solution(new int[] { 1, 1, 1, 1, 1 }, 3));


            Console.WriteLine(Network.solution(3, new int[,] { { 1, 1, 0, }, { 1, 1, 0 }, { 0, 0, 1 } }));
            Console.WriteLine(Network.solution(3, new int[,] { { 1, 1, 0, }, { 1, 1, 1 }, { 0, 1, 1 } }));


            Console.WriteLine(WordChanger.Solution("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }));
            Console.WriteLine(WordChanger.Solution("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log" }));


            Console.WriteLine(TravelRoute.Solution(
                new string[,] { { "ICN", "JFK" }, { "HND", "IAD" }, { "JFK", "HND" } }).ArrayToString());
            Console.WriteLine(TravelRoute.Solution(
                new string[,] { { "ICN", "SFO" }, { "ICN", "ATL" }, { "SFO", "ATL" }, { "ATL", "ICN" }, { "ATL", "SFO" } }).ArrayToString());


            Console.WriteLine(NumberBaseball.Solution(new int[,] { { 123, 1, 1 }, { 356, 1, 0 }, { 327, 2, 0 }, { 489, 0, 1 } }));


            Console.WriteLine(BestAlbum.Solution(
                new string[] { "classic", "pop", "classic", "classic", "pop", "rock" },
                new int[] { 500, 600, 150, 800, 2500, 50000 })
                .ArrayToString());


            Console.WriteLine(IntegerTriangle.Solution(new List<List<int>>{new List<int>{ 7 }, new List<int> { 3, 8 },
                new List<int> { 8, 1, 0 }, new List<int>{ 2, 7, 4, 4 }, new List<int>{ 4, 5, 2, 6, 5 } }));


            Show(TruckBridge.Solution(2, 10, new int[] { 7, 4, 5, 6 }));
            Show(TruckBridge.Solution(100, 100, new int[] { 10 }));
            Show(TruckBridge.Solution(100, 100, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }));
            Show(TruckBridge.Solution(9000, 101, new int[] { 101, 101, 101, 101, 101, 101, 101, 101 }));


            Show(Developement.Solution(new int[] { 93, 30, 55 }, new int[] { 1, 30, 5 }).ArrayToString());


            Show(PipeCutting.Solution("()(((()())(())()))(())"));


            Show(PrinterQueue.Solution(new int[] { 2, 1, 3, 2 }, 2));
            Show(PrinterQueue.Solution(new int[] { 1, 1, 9, 1, 1, 1 }, 0));

            Show(StockPrice.Solution(new int[] { 1, 2, 3, 2, 3 }).ArrayToString());
            Show(StockPrice.Solution(new int[] { 1, 4, 2, 5, 6, 7, 4, 5 }).ArrayToString());
            Show(StockPrice.Solution(new int[] { 1, 2, 3, 4, 5, 1, 1 }).ArrayToString());
            Show(StockPrice.Solution(new int[] { 1, 2, 3, 2, 3, 1 }).ArrayToString());


            Show(SpicyFood.Solution(new int[] { 1, 2, 3, 9, 10, 12 }, 7));


            Show(NoodleFactory.Solution(4, new int[] { 4, 10, 15 }, new int[] { 20, 5, 10 }, 30));
            Show(NoodleFactory.Solution(31, new int[] { 4, 10, 15 }, new int[] { 20, 5, 10 }, 30));


            Show(DiscController.Solution(new int[,] { { 0, 3 }, { 1, 9 }, { 2, 6 } }));


            Show(DoublePriorityQueue.Solution(new string[] { "I 16", "D 1" }).ArrayToString());
            Show(DoublePriorityQueue.Solution(new string[] { "I 7", "I 5", "I -5", "D -1" }).ArrayToString());

            Show(Carpet.solution(24, 24).ArrayToString());
            Show(Carpet.solution(10, 2).ArrayToString());





            Show(Carpet.Solution(24, 24).ArrayToString());
            Show(Carpet.Solution(10, 2).ArrayToString());


            Show(MockExam.Solution(new int[] { 1, 2, 3, 4, 5 }).ArrayToString());
            Show(MockExam.Solution(new int[] { 1, 3, 2, 4, 2 }).ArrayToString());


            Show(SchoolRoad.Solution(4, 3, new int[1][] { new int[2] { 2, 2 } }));
            Show(SchoolRoad.Solution(5, 5, new int[8][] { new int[2] { 2, 1 }, new int[2] { 2, 2 }, new int[2] { 2, 3 },
                new int[2] { 2, 4 }, new int[2] { 4, 2 }, new int[2] { 4, 3 }, new int[2] { 4, 4 }, new int[2] { 4, 5 } }));


            Show(CardGame.Solution(new int[] { 3, 2, 5, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, new int[] { 2, 4, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3 }));
            Show(CardGame.Solution(new int[] { 3, 2, 1 }, new int[] { 2, 4, 1 }));


            Show(Thievery.Solution(new int[] { 1, 2, 3, 1 }));


            Show(TravelFundRaising.Solution(100, new int[3, 4] { { 1, 1, 1, 1 }, { 99, 1000, 1, 1 }, { 1, 1, 1, 1 } }));
            Show(TravelFundRaising.Solution(1650, new int[3, 4] { { 500, 200, 200, 100 }, { 800, 370, 300, 120 }, { 700, 250, 300, 90 } }));
            Show(TravelFundRaising.Solution(3000, new int[4, 4] { { 1000, 2000, 300, 700 }, { 1100, 1900, 400, 900 },
                { 900, 1800, 400, 700 }, { 1200, 2300, 500, 1200 } }));


            Show(GymSuit.Solution(5, new int[] { 2, 4 }, new int[] { 1, 3, 5 }));
            Show(GymSuit.Solution(5, new int[] { 2, 4 }, new int[] { 3 }));
            Show(GymSuit.Solution(3, new int[] { 3 }, new int[] { 1 }));
            Show(GymSuit.Solution(8, new int[] { 3, 7 }, new int[] { 2, 4 }));

            Show(BigNumber.Solution("0000", 3));
            Show(BigNumber.Solution("1924", 2));
            Show(BigNumber.Solution("1231234", 3));
            Show(BigNumber.Solution("4177252841", 4));
            
            Show(LifeBoat.Solution(new int[] { 70, 50, 80, 50, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 100));
            Show(LifeBoat.Solution(new int[] { 70, 80, 50 }, 100));

            Show(PoliceCamera.Solution(new int[4, 2] { { -20, -20 }, { -14, -5 }, { -18, -13 }, { -5, -3 } }));

            Show(IslandConnection.Solution(4, new int[5, 3] { { 0, 1, 1 }, { 0, 2, 2 }, { 1, 2, 5 }, { 1, 3, 1 }, { 2, 3, 8 } }));

            Show(BalancingScale.Solution(new int[] { 3, 1, 6, 2, 7, 30, 1 }));

            
            Show(KthNumber.Solution("[1, 5, 2, 6, 3, 7, 4]".ToArrays<int>(), new int[3, 3] { { 2, 5, 3 }, { 4, 4, 1 }, { 1, 7, 3 } }).ToStrings());

            Show(BiggestNumber.Solution("[6,10,2]".ToArrays<int>()));
            Show(BiggestNumber.Solution("[101,100,10,11,10,10,10,101,100,102]".ToArrays<int>()));
            Show(BiggestNumber.Solution("[0,0,0,0,0]".ToArrays<int>()));

            Show(H_Index.Solution("[3, 0, 6, 1, 5]".ToArrays<int>()));
            Show(H_Index.Solution("[3,3,3,3]".ToArrays<int>()));

            Show(PhoneBook.Solution("[119, 97674223, 1195524421]".ToArrays<string>()));
            Show(PhoneBook.Solution("[123, 456, 789]".ToArrays<string>()));
            Show(PhoneBook.Solution("[1,98,99]".ToArrays<string>()));


            Show(FailureRunner.Solution(
                "[leo, kiki, eden]".ToArrays<string>(),
                "[eden, kiki]".ToArrays<string>()));
            Show(FailureRunner.Solution(
                "[marina, josipa, nikola, vinko, filipa]".ToArrays<string>(),
                "[josipa, filipa, marina, nikola]".ToArrays<string>()));
            Show(FailureRunner.Solution(
                "[mislav, stanko, mislav, ana]".ToArrays<string>(),
                "[stanko, ana, mislav]".ToArrays<string>()));
            
            Show(Budget.Solution("[120, 110, 140, 150]".ToArrays<int>(), 485));
            Show(Budget.Solution("[1,2,3,4,5,6,7]".ToArrays<int>(), 20));
            Show(Budget.Solution("[1,2,3,4]".ToArrays<int>(), 20));
           


            Show(Immigration.Solution(5, new int[] {1,1,10}));

           
            Show(SteppingStones.Solution(25, new int[] { 2, 3, 4 }, 2));

          
            Show(FarthestNode.Solution(6, "[[3, 6], [4, 3], [3, 2], [1, 3], [1, 2], [2, 4], [5, 2]]".ToMultiArrays<int>()));

            */


            //Show(Ranking.Solution(5, "[[4, 3], [4, 2], [3, 2], [1, 2], [2, 5]]".ToMultiArrays<int>()));

            //Show(TrieTest.Solution());


            // Show(Immigration.Solution(100000000, new int[] { 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2 }));

            //Show(SteppingStones.Solution(25, new int[] { 2, 14, 11, 21, 17 }, 2));
            //Show(Ranking.Solution(5, "[[4, 3], [4, 2], [3, 2], [1, 2], [2, 5]]".ToMultiArrays<int>()));

            #endregion

            //Show(Adding.Solution("[2,1,3,4,1]".ToArrays<int>()).ToStrings());
            //Show(Triangle.Solution(3).ToStrings());
            //Show(BinaryConverter.Solution("110010101001").ToStrings());

            //Show(TreeTest.Solution());

            Show(ZeroSumTree.Solution("[-5,0,2,1,2]".ToArrays<int>(), "[[0,1],[3,4],[2,3],[0,3]]".ToMultiArrays<int>()));
            Show(ZeroSumTree.Solution("[0,1,0]".ToArrays<int>(), "[[0,1],[1,2]]".ToMultiArrays<int>()));

            // Show(RORGame.Solution("[[1,0,1,1,1],[1,0,1,0,1],[1,0,1,1,1],[1,1,1,0,1],[0,0,0,0,1]]".ToMultiArrays<int>()));

           // Show(JadenCase.Solution("3people  unFollowed me"));
            //Show(JoystickName.Solution("JEROEN"));
            //Show(JoystickName.Solution("AABAAAAAAABBB"));

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
