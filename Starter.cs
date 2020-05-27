using Algorithm.Algorithms;
using Algorithm.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    static class Starter
    {
        static void Main(string[] args)
        {

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


            Console.WriteLine(BestAlbum.Solution(
                new string[] { "classic", "pop", "classic", "classic", "pop" , "rock"},
                new int[] { 500, 600, 150, 800, 2500 , 50000 })
                .ArrayToString());
        }
    }
}
