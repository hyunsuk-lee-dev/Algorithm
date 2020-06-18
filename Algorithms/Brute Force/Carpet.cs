using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms.Brute_Force
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42842
    /// Brute Force
    /// </summary>
    public class Carpet
    {
        /// <summary>
        /// Leo는 카펫을 사러 갔다가 아래 그림과 같이 중앙에는 노란색으로 칠해져 있고 테두리 1줄은 갈색으로 칠해져 있는 격자 모양 카펫을 봤습니다.
        /// 
        /// Leo는 집으로 돌아와서 아까 본 카펫의 노란색과 갈색으로 색칠된 격자의 개수는 기억했지만, 전체 카펫의 크기는 기억하지 못했습니다.
        /// 
        /// 제한사항
        /// 갈색 격자의 수 brown은 8 이상 5,000 이하인 자연수입니다.
        /// 노란색 격자의 수 yellow는 1 이상 2,000,000 이하인 자연수입니다.
        /// 카펫의 가로 길이는 세로 길이와 같거나, 세로 길이보다 깁니다.
        /// </summary>
        /// <param name="brown">갈색 격자의 수</param>
        /// <param name="yellow">노란색 격자의 수</param>
        /// <returns>가로, 세로 크기</returns>
        public static int[] solution(int brown, int yellow)
        {
            // [1]   x * y = Brown + Yellow
            // [2]   (x - 2) * (y - 2) = Yellow
            // [3]   y = (Brown + Yellow) / x    ----------------------------- [1]
            // [4]   (x - 2) * ((Brown + Yellow) / x - 2) = Yellow   --------- [2] + [3]
            // [5]   -2 * x^2 + (Brown + 4) * x - 2 * (Brown + Yellow) = 0 --- [4]

            int x = ((brown + 4) / 2 + (int)Math.Sqrt(Math.Pow((brown + 4) / 2, 2) - 4 * (brown + yellow))) / 2;
            int y = ((brown + 4) / 2 - (int)Math.Sqrt(Math.Pow((brown + 4) / 2, 2) - 4 * (brown + yellow))) / 2;

            return new int[] { x, y };
        }
    }
}
