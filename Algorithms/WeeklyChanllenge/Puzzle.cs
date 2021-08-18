using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/84021
    /// Algorithm.Algorithms.WeeklyChanllenge
    /// </summary>
    public class Puzzle
    {
        public class Block : ICloneable
        {
            private int size;
            private int[,] shape;

            public int Size { get { return size; } }

            public Block(int[,] shape)
            {
                this.shape = shape ?? throw new ArgumentNullException(nameof(shape));

                int size = 0;
                for(int i = 0; i < shape.GetLength(0); i++)
                {
                    for(int j = 0; j < shape.GetLength(1); j++)
                    {
                        if(shape[i, j] == 1)
                        {
                            size++;
                        }
                    }
                }
                this.size = size;
            }

            public object Clone()
            {
                return new Block((int[,])shape.Clone());
            }

            public override bool Equals(object obj)
            {
                return obj is Block block &&
                       size == block.size &&
                       EqualityComparer<int[,]>.Default.Equals(shape, block.shape);
            }

            public override int GetHashCode()
            {
                int hashCode = 842937570;
                hashCode = hashCode * -1521134295 + size.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<int[,]>.Default.GetHashCode(shape);
                return hashCode;
            }

            public void Rotate()
            {
                int row = shape.GetLength(0);
                int col = shape.GetLength(1);

                int[,] rotatedShape = new int[col, row];

                for(int i = 0; i < row; i++)
                {
                    for(int j = 0; j < col; j++)
                    {
                        rotatedShape[j, row - 1 - i] = shape[i, j];
                    }
                }

                shape = rotatedShape;
            }

            public void ShowBlock()
            {
                Console.WriteLine($"Size : {size}");
                for(int i = 0; i < shape.GetLength(0); i++)
                {
                    for(int j = 0; j < shape.GetLength(1); j++)
                    {
                        Console.Write(shape[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

            public static bool operator ==(Block block1, Block block2)
            {
                if(block1.size != block2.size)
                {
                    return false;
                }

                int rotation = 3;
                while(rotation-- >= 0)
                {
                    if(block1.shape.GetLength(0) == block2.shape.GetLength(0) && block1.shape.GetLength(1) == block2.shape.GetLength(1))
                    {
                        bool same = true;
                        for(int i = 0; i < block1.shape.GetLength(0); i++)
                        {
                            for(int j = 0; j < block1.shape.GetLength(1); j++)
                            {
                                if(block1.shape[i, j] != block2.shape[i, j])
                                {
                                    same = false;
                                }
                            }
                        }

                        if(same)
                        {
                            return true;
                        }
                    }
                    block1.Rotate();
                }

                return false;
            }

            public static bool operator !=(Block block1, Block block2)
            {
                return !(block1 == block2);
            }
        }

        /// <summary>
        /// 테이블에 있는 퍼즐에서 조각 집어서 게임 보드에 채워넣기
        /// </summary>
        /// <param name="game_board">현재 게임 보드의 상태</param>
        /// <param name="table">테이블 위에 놓인 퍼즐 조각의 상태</param>
        /// <returns>규칙에 맞게 최대한 많은 퍼즐 조각을 채워 넣을 경우, 총 몇 칸을 채울 수 있는지</returns>
        /// <remarks>
        /// - 3 ≤ game_board의 행 길이 ≤ 50
        /// - game_board의 각 열 길이 = game_board의 행 길이
        /// - 0은 빈칸, 1은 이미 채워진 칸을 나타냅니다.
        /// - game_board에는 반드시 하나 이상의 빈칸이 있습니다.
        /// - table에는 반드시 하나 이상의 블록이 놓여 있습니다.
        /// </remarks>
        public int Solution(int[,] game_board, int[,] table)
        {
            int answer = 0;

            ReverseBoard(game_board);

            ShowBoard(game_board);
            List<Block> gameBlocks = ExportBlock(game_board);
            List<Block> tableBlocks = ExportBlock(table);

            gameBlocks.Sort((a, b) => -a.Size.CompareTo(b.Size));
            tableBlocks.Sort((a, b) => -a.Size.CompareTo(b.Size));

            foreach(Block tableBlock in tableBlocks)
            {
                for(int i = 0; i < gameBlocks.Count; i++)
                {
                    if(gameBlocks[i] == tableBlock)
                    {
                        answer += tableBlock.Size;
                        gameBlocks.RemoveAt(i);
                        break;
                    }
                }
            }

            return answer;
        }

        public void ReverseBoard(int[,] board)
        {
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 1 - board[i, j];
                }
            }
        }

        public void ShowBoard(int[,] board)
        {
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public List<Block> ExportBlock(int[,] board)
        {
            bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];

            for(int i = 0; i < visited.GetLength(0); i++)
            {
                for(int j = 0; j < visited.GetLength(1); j++)
                {
                    visited[i, j] = false;
                }
            }

            List<Block> blocks = new List<Block>();

            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    if(board[i, j] == 1 && !visited[i, j])
                    {
                        visited[i, j] = true;
                        Block findBlock = FindBlock(board, i, j, visited);
                        Console.WriteLine($"{i},{j}");
                        findBlock.ShowBlock();
                        blocks.Add(findBlock);
                    }
                }
            }

            return blocks;
        }

        public Block FindBlock(int[,] board, int i, int j, bool[,] visited)
        {
            int[,] shape = new int[1, 1];

            int shapeI = 0;
            int shapeJ = 0;

            shape[shapeI, shapeJ] = 1;

            while(true)
            {
                if(i + 1 < board.GetLength(0) && board[i + 1, j] == 1 && !visited[i + 1, j])
                {
                    i++;
                    visited[i, j] = true;

                    if(shapeI + 1 >= shape.GetLength(0))
                    {
                        int[,] newShape = new int[shape.GetLength(0) + 1, shape.GetLength(1)];
                        for(int row = 0; row < shape.GetLength(0); row++)
                        {
                            for(int col = 0; col < shape.GetLength(1); col++)
                            {
                                newShape[row, col] = shape[row, col];
                            }
                        }
                        shape = newShape;
                    }

                    shapeI++;
                    shape[shapeI, shapeJ] = 1;
                    continue;
                }
                else if(i - 1 >= 0 && board[i - 1, j] == 1 && !visited[i - 1, j])
                {
                    i--;
                    visited[i, j] = true;

                    if(shapeI - 1 < 0)
                    {
                        int[,] newShape = new int[shape.GetLength(0) + 1, shape.GetLength(1)];
                        for(int row = 0; row < shape.GetLength(0); row++)
                        {
                            for(int col = 0; col < shape.GetLength(1); col++)
                            {
                                newShape[row + 1, col] = shape[row, col];
                            }
                        }
                        shape = newShape;
                    }

                    shape[shapeI, shapeJ] = 1;
                    continue;
                }
                else if(j + 1 < board.GetLength(1) && board[i, j + 1] == 1 && !visited[i, j + 1])
                {
                    j++;
                    visited[i, j] = true;

                    if(shapeJ + 1 >= shape.GetLength(1))
                    {
                        int[,] newShape = new int[shape.GetLength(0), shape.GetLength(1) + 1];
                        for(int row = 0; row < shape.GetLength(0); row++)
                        {
                            for(int col = 0; col < shape.GetLength(1); col++)
                            {
                                newShape[row, col] = shape[row, col];
                            }
                        }
                        shape = newShape;
                    }

                    shapeJ++;
                    shape[shapeI, shapeJ] = 1;
                    continue;
                }
                else if(j - 1 >= 0 && board[i, j - 1] == 1 && !visited[i, j - 1])
                {
                    j--;
                    visited[i, j] = true;

                    if(shapeJ - 1 < 0)
                    {
                        int[,] newShape = new int[shape.GetLength(0), shape.GetLength(1) + 1];
                        for(int row = 0; row < shape.GetLength(0); row++)
                        {
                            for(int col = 0; col < shape.GetLength(1); col++)
                            {
                                newShape[row, col + 1] = shape[row, col];
                            }
                        }
                        shape = newShape;
                    }

                    shape[shapeI, shapeJ] = 1;

                    continue;
                }

                return new Block(shape);
            }
        }
    }
}
