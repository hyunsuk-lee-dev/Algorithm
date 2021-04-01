using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/68645
    /// Algorithm.Algorithms.MonthlyChallenge1
    /// </summary>
    public class Triangle
    {
        private enum Direction
        {
            LeftDown,
            Right,
            LeftUp
        }

        private static Direction NextDirection(Direction direction)
        {
            /* Illegible Code
            return direction == Direction.LeftDown ? Direction.Right : 
                direction == Direction.Right ? Direction.LeftUp : 
                Direction.LeftDown;
            */

            if(direction == Direction.LeftDown)
            {
                return Direction.Right;
            }
            else if(direction == Direction.Right)
            {
                return Direction.LeftUp;
            }
            else
            {
                return Direction.LeftDown;
            }
        }



        /// <summary>
        /// 정수 n이 매개변수로 주어집니다. 밑변의 길이와 높이가 n인 삼각형에서 맨 위 꼭짓점부터 반시계 방향으로 달팽이 채우기를 진행한 후, 
        /// 첫 행부터 마지막 행까지 모두 순서대로 합친 새로운 배열을 return 하도록 solution 함수를 완성해주세요.
        /// 
        /// n은 1 이상 1,000 이하입니다.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] Solution(int n)
        {
            // Short Length Answer;
            if(n == 1)
            {
                return new int[1] { 1 };
            }
            else if(n == 2)
            {
                return new int[3] { 1, 2, 3 };
            }
            else if(n == 3)
            {
                return new int[6] { 1, 2, 6, 3, 4, 5 };
            }

            // Bigger Length;

            int[,] snailTable = new int[n, n];

            // Maximum Number is "1+2+3+...+(n-1)+n";
            int maxSize = n * (n + 1) / 2;

            Direction direction = Direction.LeftDown;

            int row = 0;
            int col = 0;
            int value = 1;

            while(value <= maxSize)
            {
                switch(direction)
                {
                    case Direction.LeftDown:
                        {
                            while(row < n && snailTable[row, col] == 0)
                            {
                                snailTable[row, col] = value;
                                value++;
                                row++;
                            }
                            row--;
                            col++;
                            break;
                        }
                    case Direction.Right:
                        {
                            while(col < n && snailTable[row, col] == 0)
                            {
                                snailTable[row, col] = value;
                                value++;
                                col++;
                            }
                            col--;
                            col--;
                            row--;
                            break;
                        }
                    case Direction.LeftUp:
                        {
                            while(snailTable[row, col] == 0)
                            {
                                snailTable[row, col] = value;
                                value++;
                                col--;
                                row--;
                            }
                            col++;
                            row++;
                            row++;
                            break;
                        }
                }
                direction = NextDirection(direction);
            }


            int[] answer = new int[maxSize];
            int answerIndex = 0;

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(snailTable[i, j] != 0)
                    {
                        answer[answerIndex++] = snailTable[i, j];

                        if(answerIndex == maxSize)
                        {
                            break;
                        }
                    }
                }
            }

            return answer;
        }
    }
}
