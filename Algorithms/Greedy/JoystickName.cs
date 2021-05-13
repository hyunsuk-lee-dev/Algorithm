using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/skill_checks/280807?challenge_id=2578
    /// Algorithm.Algorithms
    /// </summary>
    public class JoystickName
    {
        public static int CountForAlphabet(char alphabet)
        {
            return alphabet <= 'N' ? alphabet - 'A' : 'Z' - alphabet + 1;
            //ABCEDFGHIJKLMN
            // ZYXWVUTSRQPON
        }
        /// <summary>
        /// 조이스틱으로 알파벳 이름을 완성하세요. 맨 처음엔 A로만 이루어져 있습니다.
        /// </summary>
        /// <param name="name">만들고자 하는 이름</param>
        /// <returns>이름에 대해 조이스틱 조작 횟수의 최솟값</returns>
        /// 제한 사항
        /// name은 알파벳 대문자로만 이루어져 있습니다.
        /// name의 길이는 1 이상 20 이하입니다.
        public static int Solution(string name)
        {
            int answer = 0;
            int maxAIndex = 0;
            int maxACount = 0;

            int aIndex = -1;
            int aCount = -1;

            bool isA = false;
            for(int i = 0; i < name.Length; i++)
            {
                if(name[i] == 'A')
                {
                    if(!isA)
                    {
                        isA = true;
                        aIndex = i;
                        aCount = 1;
                    }
                    else
                    {
                        aCount++;
                    }
                }
                else
                {
                    if(isA)
                    {
                        isA = false;

                        if(maxACount < aCount)
                        {
                            maxAIndex = aIndex;
                            maxACount = aCount;
                        }
                    }
                }
                answer += CountForAlphabet(name[i]);
            }

            if(isA)
            {
                if(maxACount < aCount)
                {
                    maxAIndex = aIndex;
                    maxACount = aCount;
                }
            }

            int straightDistance = name.Length - 1;
            int backDistance = int.MaxValue;
           
            if(maxAIndex != 0)
            {
                int minLength = Math.Min(maxAIndex - 1, name.Length - maxAIndex - maxACount);
                int maxLength = Math.Max(maxAIndex - 1, name.Length - maxAIndex - maxACount);

                backDistance = minLength * 2 + maxLength;
            }

            return answer+ Math.Min(backDistance, straightDistance);
        }
    }
}
