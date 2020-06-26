using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42576
    /// Hasg
    /// </summary>
    public class FailureRunner
    {
        /// <summary>
        /// 수많은 마라톤 선수들이 마라톤에 참여하였습니다. 단 한 명의 선수를 제외하고는 모든 선수가 마라톤을 완주하였습니다.
        /// 
        /// 제한사항
        /// 마라톤 경기에 참여한 선수의 수는 1명 이상 100,000명 이하입니다.
        /// completion의 길이는 participant의 길이보다 1 작습니다.
        /// 참가자의 이름은 1개 이상 20개 이하의 알파벳 소문자로 이루어져 있습니다.
        /// 참가자 중에는 동명이인이 있을 수 있습니다.
        /// </summary>
        /// <param name="participant">마라톤에 참여한 선수들의 이름이 담긴 배열</param>
        /// <param name="completion">완주한 선수들의 이름이 담긴 배열</param>
        /// <returns>완주하지 못한 선수의 이름</returns>
        public static string Solution(string[] participants, string[] completions)
        {
            Dictionary<string, int> runner = new Dictionary<string, int>();

            foreach(string participant in participants)
            {
                if(runner.ContainsKey(participant))
                    runner[participant]++;
                else
                    runner.Add(participant, 1);
            }

            foreach(string participant in participants)
            {
                runner[participant]--;
            }

            return runner.OrderByDescending(x => x.Value).First().Key;
        }
    }
}
