using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42860
    /// Greedy
    /// </summary>
    public class JoyStick
    {
        /// <summary>
        /// 조이스틱으로 알파벳 이름을 완성하세요. 맨 처음엔 A로만 이루어져 있습니다.
        /// ex) 완성해야 하는 이름이 세 글자면 AAA, 네 글자면 AAAA
        /// 
        /// 조이스틱을 각 방향으로 움직이면 아래와 같습니다.
        /// 
        /// ▲ - 다음 알파벳
        /// ▼ - 이전 알파벳 (A에서 아래쪽으로 이동하면 Z로)
        /// ◀ - 커서를 왼쪽으로 이동(첫 번째 위치에서 왼쪽으로 이동하면 마지막 문자에 커서)
        /// ▶ - 커서를 오른쪽으로 이동
        /// 
        /// 제한 사항
        /// name은 알파벳 대문자로만 이루어져 있습니다.
        /// name의 길이는 1 이상 20 이하입니다.
        /// </summary>
        /// <param name="name">만들고자 하는 이름</param>
        /// <returns>이름에 대해 조이스틱 조작 횟수의 최솟값</returns>
        public static int Solution(string name)
        {
            bool[] targets = new bool[name.Length];

            int answer = 0;

            for(int i = 0 ; i < name.Length ; i++)
            {
                answer += 13 - Math.Abs(name[i] - 78);
                if(name[i] != 'A')
                    targets[i] = true;
            }

            int leftMaxDistance = 0;
            int rightMaxDistance = 0;

            int leftStraightDistance = 0;
            int rightStraightDistance = 0;

            for(int i = 1 ; i < name.Length ; i++)
            {
                if(targets[i])
                {
                    if(i <= name.Length / 2)
                        leftMaxDistance = Math.Max(leftMaxDistance, i);
                    else
                        rightMaxDistance = Math.Max(rightMaxDistance, name.Length - i);

                    leftStraightDistance = Math.Max(leftStraightDistance, i);
                    rightStraightDistance = Math.Max(rightStraightDistance, name.Length - i);
                }
            }

            int backUpDistance = leftMaxDistance > rightMaxDistance ? rightMaxDistance * 2 + leftMaxDistance : leftMaxDistance * 2 + rightMaxDistance;
            int straightDistance = Math.Min(leftStraightDistance, rightStraightDistance);
            return answer + Math.Min(backUpDistance, straightDistance);
        }
    }
}
