using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/skill_checks/280781?challenge_id=301
    /// Algorithm.Algorithms.Graph
    /// </summary>
    public class RORGame
    {
        public class Coordinate
        {
            public int x;
            public int y;
            public int cost;

            public Coordinate(Coordinate currentCoordinate) : this(currentCoordinate.x, currentCoordinate.y, currentCoordinate.cost)
            {

            }
           
            public Coordinate(int x, int y)
            {
                this.x = x;
                this.y = y;
                cost = 0;
            }

            public Coordinate(int x, int y, int cost) : this(x, y)
            {
                this.cost = cost;
            }
        }

        public static bool IsInside(Coordinate coordinate , int[,] maps)
        {
            return coordinate.x >= 0 && coordinate.y >= 0 && 
                coordinate.x < maps.GetLength(0) && coordinate.y < maps.GetLength(1) && 
                maps[coordinate.x, coordinate.y] == 1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maps">게임 맵의 상태</param>
        /// <returns>캐릭터가 상대 팀 진영에 도착하기 위해서 지나가야 하는 칸의 개수의 최솟값</returns>
        /// 제한사항
        /// maps는 n x m 크기의 게임 맵의 상태가 들어있는 2차원 배열로, n과 m은 각각 1 이상 100 이하의 자연수입니다.
        /// n과 m은 서로 같을 수도, 다를 수도 있지만, n과 m이 모두 1인 경우는 입력으로 주어지지 않습니다.
        /// maps는 0과 1로만 이루어져 있으며, 0은 벽이 있는 자리, 1은 벽이 없는 자리를 나타냅니다.
        /// 처음에 캐릭터는 게임 맵의 좌측 상단인 (1, 1) 위치에 있으며, 상대방 진영은 게임 맵의 우측 하단인(n, m) 위치에 있습니다.
        public static int Solution(int[,] maps)
        {
            Queue<Coordinate> coordinateQueue = new Queue<Coordinate>();
            bool[,] isVisited = new bool[maps.GetLength(0), maps.GetLength(1)];

            isVisited[0, 0] = true;
            coordinateQueue.Enqueue(new Coordinate(0, 0));
            
            while(coordinateQueue.Count > 0)
            {
                Coordinate currentCoordinate = coordinateQueue.Dequeue();

                if(currentCoordinate.x == maps.GetLength(0) - 1 && currentCoordinate.y == maps.GetLength(1) - 1)
                {
                    return currentCoordinate.cost;
                }

                Coordinate leftCoordinate = new Coordinate(currentCoordinate);
                leftCoordinate.x--;
                leftCoordinate.cost++;
                if(IsInside(leftCoordinate, maps) && !isVisited[leftCoordinate.x , leftCoordinate.y])
                {
                    coordinateQueue.Enqueue(leftCoordinate);
                }

                Coordinate rightCoordinate = new Coordinate(currentCoordinate);
                rightCoordinate.x++;
                rightCoordinate.cost++;
                if(IsInside(rightCoordinate, maps) && !isVisited[rightCoordinate.x, rightCoordinate.y])
                {
                    coordinateQueue.Enqueue(rightCoordinate);
                }

                Coordinate upCoordinate = new Coordinate(currentCoordinate);
                upCoordinate.y--;
                upCoordinate.cost++;
                if(IsInside(upCoordinate, maps) && !isVisited[upCoordinate.x, upCoordinate.y])
                {
                    coordinateQueue.Enqueue(upCoordinate);
                }

                Coordinate downCoordinate = new Coordinate(currentCoordinate);
                downCoordinate.y++;
                downCoordinate.cost++;
                if(IsInside(downCoordinate, maps) && !isVisited[downCoordinate.x, downCoordinate.y])
                {
                    coordinateQueue.Enqueue(downCoordinate);
                }
            }
            return 0;
        }
    }
}
