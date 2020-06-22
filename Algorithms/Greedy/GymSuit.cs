using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42862?language=csharp
    /// Greedy
    /// </summary>
    public class GymSuit
    {
        /// <summary>
        /// 점심시간에 도둑이 들어, 일부 학생이 체육복을 도난당했습니다. 다행히 여벌 체육복이 있는 학생이 이들에게 체육복을 빌려주려 합니다. 
        /// 학생들의 번호는 체격 순으로 매겨져 있어, 바로 앞번호의 학생이나 바로 뒷번호의 학생에게만 체육복을 빌려줄 수 있습니다. 
        /// 예를 들어, 4번 학생은 3번 학생이나 5번 학생에게만 체육복을 빌려줄 수 있습니다. 
        /// 체육복이 없으면 수업을 들을 수 없기 때문에 체육복을 적절히 빌려 최대한 많은 학생이 체육수업을 들어야 합니다.
        /// 
        /// 제한사항
        /// 전체 학생의 수는 2명 이상 30명 이하입니다.
        /// 체육복을 도난당한 학생의 수는 1명 이상 n명 이하이고 중복되는 번호는 없습니다.
        /// 여벌의 체육복을 가져온 학생의 수는 1명 이상 n명 이하이고 중복되는 번호는 없습니다.
        /// 여벌 체육복이 있는 학생만 다른 학생에게 체육복을 빌려줄 수 있습니다.
        /// 여벌 체육복을 가져온 학생이 체육복을 도난당했을 수 있습니다. 
        /// 이때 이 학생은 체육복을 하나만 도난당했다고 가정하며, 남은 체육복이 하나이기에 다른 학생에게는 체육복을 빌려줄 수 없습니다.
        /// </summary>
        /// <param name="n">전체 학생의 수</param>
        /// <param name="lost">체육복을 도난당한 학생들의 번호가 담긴 배열</param>
        /// <param name="reserve">여벌의 체육복을 가져온 학생들의 번호가 담긴 배열</param>
        /// <returns>체육수업을 들을 수 있는 학생의 최댓값</returns>
        public static int Solution(int n, int[] lost, int[] reserve)
        {
            List<int> lostList = new List<int>(lost);
            lostList.Sort();
            List<int> reserveList = new List<int>(reserve);
            reserveList.Sort();

            for(int i = 0 ; i < lostList.Count ; i++)
            {
                for(int j = 0 ; j < reserveList.Count ; j++)
                {
                    if(lostList[i] == reserveList[j])
                    {
                        lostList.RemoveAt(i--);
                        reserveList.RemoveAt(j);
                        break;
                    }
                }
            }

            for(int i = 0 ; i < lostList.Count ; i++)
            {
                for(int j = 0 ; j < reserveList.Count ; j++)
                {
                    if(Math.Abs(lostList[i] - reserveList[j]) <= 1)
                    {
                        lostList.RemoveAt(i--);
                        reserveList.RemoveAt(j);
                        break;
                    }
                }
            }

            return n - lostList.Count;
        }
    }
}
