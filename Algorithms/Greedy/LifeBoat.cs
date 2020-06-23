using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42885?language=java
    /// Greedy
    /// </summary>
    public class LifeBoat
    {
        /// <summary>
        /// 무인도에 갇힌 사람들을 구명보트를 이용하여 구출하려고 합니다. 구명보트는 작아서 한 번에 최대 2명씩 밖에 탈 수 없고, 무게 제한도 있습니다.
        /// 예를 들어, 사람들의 몸무게가[70kg, 50kg, 80kg, 50kg] 이고 구명보트의 무게 제한이 100kg이라면 
        /// 2번째 사람과 4번째 사람은 같이 탈 수 있지만 1번째 사람과 3번째 사람의 무게의 합은 150kg이므로 구명보트의 무게 제한을 초과하여 같이 탈 수 없습니다.
        /// 구명보트를 최대한 적게 사용하여 모든 사람을 구출하려고 합니다.
        /// 
        /// 제한사항
        /// 무인도에 갇힌 사람은 1명 이상 50,000명 이하입니다.
        /// 각 사람의 몸무게는 40kg 이상 240kg 이하입니다.
        /// 구명보트의 무게 제한은 40kg 이상 240kg 이하입니다.
        /// 구명보트의 무게 제한은 항상 사람들의 몸무게 중 최댓값보다 크게 주어지므로 사람들을 구출할 수 없는 경우는 없습니다.
        /// </summary>
        /// <param name="people">사람들의 몸무게를 담은 배열</param>
        /// <param name="limit">구명보트의 무게 제한</param>
        /// <returns>모든 사람을 구출하기 위해 필요한 구명보트 개수의 최솟값</returns>
        public static int Solution(int[] people, int limit)
        {
            int answer = 0;

            List<int> peopleList = new List<int>(people);

            while(peopleList.Count > 0)
            {
                int weightSum = peopleList.Min();

                peopleList.Remove(peopleList.Min());

                IEnumerable<int> availablePeople = peopleList.Where(x => x + weightSum <= limit);

                if(availablePeople.Count() > 0)
                    peopleList.Remove(availablePeople.Max());

                answer++;
            }

            return answer;
        }
    }
}
