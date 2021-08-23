using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 직업군 추천하기
    /// https://programmers.co.kr/learn/courses/30/lessons/84325
    /// Algorithm.Algorithms.String
    /// </summary>
    public class CareerRecommend
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">직업군 언어 점수를 정리한 문자열 배열</param>
        /// <param name="languages">언어를 담은 문자열 배열</param>
        /// <param name="preference">언어 선호도를 담은 정수 배열</param>
        /// <returns>언어 선호도 x 직업군 언어 점수의 총합이 가장 높은 직업군. 
        /// 총합이 같은 직업군이 여러 개일 경우, 이름이 사전 순으로 가장 빠른 직업군</returns>
        /// table의 길이 = 5
        /// table의 원소는 "직업군 5점언어 4점언어 3점언어 2점언어 1점언어"형식의 문자열입니다.
        /// 직업군, 5점언어, 4언어, 3점언어, 2점언어, 1점언어는 하나의 공백으로 구분되어 있습니다.
        /// table은 모든 테스트케이스에서 동일합니다.
        /// 
        /// 1 ≤ languages의 길이 ≤ 9
        /// languages의 원소는 "JAVA", "JAVASCRIPT", "C", "C++" ,"C#" , "SQL", "PYTHON", "KOTLIN", "PHP" 중 한 개 이상으로 이루어져 있습니다.
        /// languages의 원소는 중복되지 않습니다.
        /// 
        /// preference의 길이 = languages의 길이
        /// 1 ≤ preference의 원소 ≤ 10
        /// preference의 i번째 원소는 languages의 i번째 원소의 언어 선호도입니다.
        /// return 할 문자열은 "SI", "CONTENTS", "HARDWARE", "PORTAL", "GAME" 중 하나입니다.
        public static string Solution(string[] table, string[] languages, int[] preference)
        {
            string[] careers = new string[5] { "SI", "CONTENTS", "HARDWARE", "PORTAL", "GAME" };

            // 1. Load Table.
            string[][] scores = new string[5][];
            for(int i = 0; i < 5; i++)
            {
                scores[i] = new string[5];
                string[] tableScore = table[i].Split(' ');

                for(int j = 1; j < 6; j++)
                {
                    scores[i][j - 1] = tableScore[j];
                }
            }

            // 2. Get Career Preferred Score.
            int[] careerScores = new int[careers.Length];
            for(int i = 0; i < careers.Length; i++)
            {
                for(int j = 0; j < languages.Length; j++)
                {
                    int languageScore = Array.IndexOf(scores[i], languages[j]);
                    if(languageScore != -1)
                    {
                        careerScores[i] += (5 - languageScore) * preference[j];
                    }
                }
            }

            // 3. Find Max Score Career.
            int maxScore = -1;
            string maxCareer = "";

            for(int i = 0; i < careers.Length; i++)
            {
                if(careerScores[i] > maxScore)
                {
                    maxScore = careerScores[i];
                    maxCareer = careers[i];
                }
                else if(careerScores[i] == maxScore && maxCareer[0] > careers[i][0])
                {
                    maxScore = careerScores[i];
                    maxCareer = careers[i];
                }
            }

            return maxCareer;
        }
    }
}
