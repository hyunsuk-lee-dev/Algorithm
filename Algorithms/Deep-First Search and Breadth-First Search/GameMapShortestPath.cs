using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 게임 맵 최단거리
    /// https://programmers.co.kr/learn/courses/30/lessons/1844
    /// Algorithm.Algorithms.Deep_First_Search_and_Breadth_First_Search
    /// </summary>
    public class GameMapShortestPath
    {
        private class Point
        {
            public int x;
            public int y;
            public int cost;

            public Point(int x, int y, int cost)
            {
                this.x = x;
                this.y = y;
                this.cost = cost;
            }

            public bool IsWalkable(int row, int col, int[,] maps)
            {
                return x >= 0 && x < row && y >= 0 && y < col && maps[x, y] == 1;
            }

            public bool IsEnd(int row, int col)
            {
                return x == row - 1 && y == col - 1;
            }

            public Point Left()
            {
                return new Point(x, y + 1, cost + 1);
            }


            public Point Right()
            {
                return new Point(x, y - 1, cost + 1);
            }


            public Point Up()
            {
                return new Point(x - 1, y, cost + 1);
            }


            public Point Down()
            {
                return new Point(x + 1, y, cost + 1);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maps">게임 맵의 상태</param>
        /// <returns>
        /// 캐릭터가 상대 팀 진영에 도착하기 위해서 지나가야 하는 칸의 개수의 최솟값
        /// 단, 상대 팀 진영에 도착할 수 없을 때는 -1
        /// </returns>
        /// 제한사항
        /// maps는 n x m 크기의 게임 맵의 상태가 들어있는 2차원 배열로, n과 m은 각각 1 이상 100 이하의 자연수입니다.
        /// n과 m은 서로 같을 수도, 다를 수도 있지만, n과 m이 모두 1인 경우는 입력으로 주어지지 않습니다.
        /// maps는 0과 1로만 이루어져 있으며, 0은 벽이 있는 자리, 1은 벽이 없는 자리를 나타냅니다.
        /// 처음에 캐릭터는 게임 맵의 좌측 상단인 (1, 1) 위치에 있으며, 상대방 진영은 게임 맵의 우측 하단인(n, m) 위치에 있습니다.
        public static int Solution(int[,] maps)
        {
            int row = maps.GetLength(0);
            int col = maps.GetLength(1);

            Queue<Point> pathQueue = new Queue<Point>();
            pathQueue.Enqueue(new Point(0, 0, 1));
            maps[0, 0] = 0;

            while(pathQueue.Count > 0)
            {
                Point current = pathQueue.Dequeue();

                if(current.IsEnd(row, col))
                {
                    return current.cost;
                }

                if(current.Left().IsWalkable(row, col, maps))
                {
                    pathQueue.Enqueue(current.Left());
                    maps[current.Left().x, current.Left().y] = 0;
                }

                if(current.Right().IsWalkable(row, col, maps))
                {
                    pathQueue.Enqueue(current.Right());
                    maps[current.Right().x, current.Right().y] = 0;
                }

                if(current.Up().IsWalkable(row, col, maps))
                {
                    pathQueue.Enqueue(current.Up());
                    maps[current.Up().x, current.Up().y] = 0;
                }

                if(current.Down().IsWalkable(row, col, maps))
                {
                    pathQueue.Enqueue(current.Down());
                    maps[current.Down().x, current.Down().y] = 0;
                }

            }

            return -1;
        }
    }
}
