using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43104
    /// DP
    /// </summary>
    public class Tiles
    {
        /// <summary>
        /// 대구 달성공원에 놀러 온 지수는 최근에 새로 만든 타일 장식물을 보게 되었다. 
        /// 타일 장식물은 정사각형 타일을 붙여 만든 형태였는데, 한 변이 1인 정사각형 타일부터 시작하여 마치 앵무조개의 나선 모양처럼 점점 큰 타일을 붙인 형태였다. 
        /// 타일 장식물의 일부를 그리면 다음과 같다.
        /// 그림에서 타일에 적힌 수는 각 타일의 한 변의 길이를 나타낸다. 타일 장식물을 구성하는 정사각형 타일 한 변의 길이를 안쪽 타일부터 시작하여 차례로 적으면 다음과 같다.
        /// [1, 1, 2, 3, 5, 8]
        /// 지수는 문득 이러한 타일들로 구성되는 큰 직사각형의 둘레가 궁금해졌다.
        /// </summary>
        /// <param name="N">타일의 개수 N, 1 이상 80 이하인 자연수</param>
        /// <returns>N개의 타일로 구성된 직사각형의 둘레</returns>
        public static long Solution(int N)
        {
            long[] fibonacci = new long[N + 2];

            for(int i = 0 ; i < N + 2 ; i++)
            {
                fibonacci[i] = i < 2 ? 1 : fibonacci[i - 1] + fibonacci[i - 2];
            }

            return fibonacci[N + 1] * 2;
        }
    }
}
