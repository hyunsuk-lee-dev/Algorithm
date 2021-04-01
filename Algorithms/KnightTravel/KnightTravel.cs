using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 
    /// Algorithm.Algorithms.Uncategorized
    /// </summary>
    public class KnightTravel
    {
        public class KnightPosition
        {
            private int x;
            private int y;

            public int X { get => x; }
            public int Y { get => y; }


            public static KnightPosition One { get => new KnightPosition(1, 1); }
            public static KnightPosition Zero { get => new KnightPosition(0, 0); }

            public KnightPosition(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"({X},{Y})";
            }
            public static KnightPosition operator +(KnightPosition left, KnightPosition right)
            {
                return new KnightPosition(left.X + right.X, left.Y + right.Y);
            }
        }

        public class ChessBoard
        {
            private char[,] board;

            public char[,] Board { get => board; }
            public int Size { get; private set; }

            public ChessBoard(int rowSize, int columnSize)
            {
                board = new char[rowSize, columnSize];

                for(int i = 0 ; i < rowSize ; i++)
                {
                    for(int j = 0 ; j < columnSize ; j++)
                    {
                        board[i, j] = emptyPositionMark;
                    }
                }

                Size = rowSize * columnSize;
            }

            public bool IsInBoard(KnightPosition position)
            {
                return position.X >= 0 && position.X < board.GetLength(0) && position.Y >= 0 && position.Y < board.GetLength(1);
            }

            public bool IsChecked(KnightPosition position)
            {
                return board[position.X, position.Y] == checkedPositionMark;
            }

            public void Marking(KnightPosition position, char mark)
            {
                board[position.X, position.Y] = mark;
            }

            public void ShowBoard()
            {
                Console.Write("\\ | ");
                for(int i = 0 ; i < board.GetLength(0) ; i++)
                {
                    Console.Write(i);
                    Console.Write(" ");
                }
                Console.WriteLine();

                Console.Write("==|=");
                for(int i = 0 ; i < board.GetLength(1) ; i++)
                {
                    Console.Write("==");
                }
                Console.WriteLine();

                for(int i = 0 ; i < board.GetLength(0) ; i++)
                {
                    Console.Write(i);
                    Console.Write(" | ");

                    for(int j = 0 ; j < board.GetLength(1) ; j++)
                    {
                        Console.Write(board[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }

        static readonly private char emptyPositionMark = '□';
        static readonly private char checkedPositionMark = '■';

        public static bool Solution(int rowSize, int columnSize, KnightPosition initialPosition)
        {
            Stack<KnightPosition> positions = new Stack<KnightPosition>();
            ChessBoard board = new ChessBoard(rowSize, columnSize);
            Stack<KnightPosition> positionHistory = new Stack<KnightPosition>();

            MoveKnight(board, positionHistory, initialPosition);

            bool isSuccess = FindPath(board, positionHistory);
            Console.Write(isSuccess ? "Success" : "Fail");
            Console.WriteLine();
            Console.WriteLine();

            if(isSuccess)
            {

                Console.WriteLine("Do you want check history? [y: Yes, n: No]");
                if(Console.ReadLine() == "y")
                {
                    Console.WriteLine();
                    ShowResult(rowSize, columnSize, positionHistory, true);
                }
            }

            return isSuccess;
        }

        private static void ShowResult(int rowSize, int columnSize, Stack<KnightPosition> positionHistory, bool isStepShow = false)
        {
            ChessBoard resultBoard = new ChessBoard(rowSize, columnSize);
            Stack<KnightPosition> positionLog = new Stack<KnightPosition>(positionHistory);
            KnightPosition previousPosition = KnightPosition.Zero;

            foreach(KnightPosition position in positionLog)
            {
                Console.WriteLine($"{previousPosition} -> {position}");
                previousPosition = position;
                MoveKnight(resultBoard, null, position);
                resultBoard.ShowBoard();
                if(isStepShow)
                {
                    Console.ReadLine();
                }
            }
        }

        private static bool FindPath(ChessBoard board, Stack<KnightPosition> positionHistory)
        {
            ChessBoard currentBoard = board;
            if(IsFinished(currentBoard, positionHistory))
            {
                return true;
            }

            KnightPosition currentPosition = positionHistory.Peek();
            List<KnightPosition> possibleMoves = FindPossibleMoves(currentBoard, currentPosition);

            foreach(KnightPosition move in possibleMoves)
            {
                KnightPosition movedPosition = currentPosition + move;
                MoveKnight(currentBoard, positionHistory, movedPosition);

                //ShowBoard();

                if(FindPath(currentBoard, positionHistory))
                {
                    return true;
                }

                RevertKnight(currentBoard, positionHistory, movedPosition);
            }

            return false;
        }

        private static bool IsFinished(ChessBoard board, Stack<KnightPosition> positionHistory)
        {
            return board.Size == positionHistory.Count;
        }

        private static int FindPossibleMovesCount(ChessBoard board, KnightPosition position)
        {
            int count = 0;

            List<KnightPosition> moveDirections = new List<KnightPosition>
            {
                new KnightPosition(2, 1),
                new KnightPosition(2, -1),
                new KnightPosition(-2, 1),
                new KnightPosition(-2, -1),
                new KnightPosition(1, 2),
                new KnightPosition(1, -2),
                new KnightPosition(-1, 2),
                new KnightPosition(-1, -2)
            };

            List<KnightPosition> possibleMoves = new List<KnightPosition>();

            foreach(KnightPosition direction in moveDirections)
            {
                KnightPosition targetPosition = position + direction;

                if(board.IsInBoard(targetPosition) && !board.IsChecked(targetPosition))
                {
                    count++;
                }
            }

            return count;
        }

        private static List<KnightPosition> FindPossibleMoves(ChessBoard board, KnightPosition position)
        {
            List<KnightPosition> moveDirections = new List<KnightPosition>
            {
                new KnightPosition(2, 1),
                new KnightPosition(2, -1),
                new KnightPosition(-2, 1),
                new KnightPosition(-2, -1),
                new KnightPosition(1, 2),
                new KnightPosition(1, -2),
                new KnightPosition(-1, 2),
                new KnightPosition(-1, -2)
            };

            List<KnightPosition> possibleMoves = new List<KnightPosition>();

            foreach(KnightPosition direction in moveDirections)
            {
                KnightPosition targetPosition = position + direction;

                if(board.IsInBoard(targetPosition) && !board.IsChecked(targetPosition))
                {
                    possibleMoves.Add(direction);
                }
            }

            possibleMoves = possibleMoves.OrderBy(x => FindPossibleMovesCount(board, position + x)).ToList();

            return possibleMoves;
        }

        private static void MoveKnight(ChessBoard board, Stack<KnightPosition> positionHistory, KnightPosition movePosition)
        {
            board.Marking(movePosition, checkedPositionMark);
            if(positionHistory != null)
            {
                positionHistory.Push(movePosition);
            }
        }

        private static void RevertKnight(ChessBoard board, Stack<KnightPosition> positionHistory, KnightPosition currentPosition)
        {
            board.Marking(currentPosition, emptyPositionMark);
            positionHistory.Pop();
        }


    }


}
