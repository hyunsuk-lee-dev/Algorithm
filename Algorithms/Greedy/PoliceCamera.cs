using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42884
    /// Greddy
    /// </summary>
    public class PoliceCamera
    {
        /// <summary>
        /// 고속도로를 이동하는 모든 차량이 고속도로를 이용하면서 단속용 카메라를 한 번은 만나도록 카메라를 설치하려고 합니다.
        /// 
        /// 제한사항   
        /// 차량의 대수는 1대 이상 10,000대 이하입니다.
        /// routes에는 차량의 이동 경로가 포함되어 있으며 
        /// routes[i][0] 에는 i번째 차량이 고속도로에 진입한 지점, routes[i][1] 에는 i번째 차량이 고속도로에서 나간 지점이 적혀 있습니다.
        /// 차량의 진입/진출 지점에 카메라가 설치되어 있어도 카메라를 만난것으로 간주합니다.
        /// 차량의 진입 지점, 진출 지점은 -30,000 이상 30,000 이하입니다.
        /// </summary>
        /// <param name="routes">고속도로를 이동하는 차량의 경로</param>
        /// <returns>최소 몇 대의 카메라를 설치해야 하는지</returns>
        public static int Solution(int[,] routes)
        {
            int answer = 0;

            List<int[]> routeList = routes.Convert2DArrayToList();
            routeList.Sort((x1, x2) => x1[0].CompareTo(x2[0]));

            int carIndex = 0;
            int minExit = 30001;

            while(carIndex < routeList.Count)
            {
                int entering = routeList[carIndex][0];

                if(minExit < entering)
                {
                    minExit = routeList[carIndex][1];
                    answer++;
                }
                else
                {
                    minExit = Math.Min(minExit, routeList[carIndex][1]);
                }

                carIndex++;
            }
            answer++;
            return answer;
        } 
        
        public static int Solution2(int[,] routes)
        {
            int answer = 0;

            List<int[]> routeList = routes.Convert2DArrayToList();
            routeList.Sort((x1, x2) => x1[0].CompareTo(x2[0]));

            while(routeList.Count > 0)
            {
                int[] car = new int[60001];

                foreach(int[] route in routeList)
                {
                    for(int i = route[0] ; i <= route[1] ; i++)
                        car[i + 30000]++;
                }

                int camera = Array.IndexOf(car, car.Max());

                routeList.RemoveAll(x => x[0] + 30000 <= camera && x[1] + 30000 >= camera);

                answer++;
            }


            return answer;
        }
    }
}
