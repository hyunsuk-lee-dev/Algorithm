using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// JadenCase 문자열 만들기
    /// https://programmers.co.kr/learn/courses/30/lessons/12951
    /// https://programmers.co.kr/skill_checks/280807
    /// Algorithm.Algorithms.String
    /// </summary>
    public class JadenCase
    {
        /// <summary>
        /// JadenCase란 모든 단어의 첫 문자가 대문자이고, 그 외의 알파벳은 소문자인 문자열입니다.
        /// </summary>
        /// <param name="s">문자열</param>
        /// <returns><paramref name="s"/>를 JadenCase로 바꾼 문자열</returns>
        /// 제한 조건
        /// s는 길이 1 이상인 문자열입니다.
        /// s는 알파벳과 공백문자(" ")로 이루어져 있습니다.
        /// 첫 문자가 영문이 아닐때에는 이어지는 영문은 소문자로 씁니다. (첫번째 입출력 예 참고)
        public static string Solution(string s)
        {
            char[] answer = s.ToCharArray();
            bool shouldUpper = true;
            for(int i = 0; i < s.Length; i++)
            {
                if(shouldUpper && !char.IsWhiteSpace(s[i]))
                {
                    shouldUpper = false;
                    answer[i] = char.ToUpper(s[i]);
                }
                else if(char.IsWhiteSpace(s[i]))
                {
                    shouldUpper = true;
                }
                else
                {
                    answer[i] = char.ToLower(s[i]);
                }
            }
            return new string(answer);
        }
    }
}
