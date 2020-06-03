using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42586
    /// Stack and Queue
    /// </summary>
    public static class Developement
    {
        /// <summary>
        /// 프로그래머스 팀에서는 기능 개선 작업을 수행 중입니다. 각 기능은 진도가 100%일 때 서비스에 반영할 수 있습니다.
        /// 
        /// 또, 각 기능의 개발속도는 모두 다르기 때문에 뒤에 있는 기능이 앞에 있는 기능보다 먼저 개발될 수 있고, 
        /// 이때 뒤에 있는 기능은 앞에 있는 기능이 배포될 때 함께 배포됩니다.
        /// </summary>
        /// <param name="progresses">먼저 배포되어야 하는 순서대로 작업의 진도가 적힌 정수 배열</param>
        /// <param name="speeds">각 작업의 개발 속도가 적힌 정수 배열</param>
        /// <returns>각 배포마다 몇 개의 기능이 배포되는지</returns>
        /// 작업 진도는 100 미만의 자연수입니다.
        /// 작업 속도는 100 이하의 자연수입니다.
        public static int[] Solution(int[] progresses, int[] speeds)
        {
            List<int> answer = new List<int>();

            int totalRelease = 0;
            int functions = progresses.Length;
            int releaseIndex = 0;
            
            while(totalRelease < functions)
            {
                int release = 0;

                for(int i = 0 ; i < functions ; i++)
                {
                    progresses[i] += speeds[i];
                    if(progresses[i] >= 100 && releaseIndex == i)
                    {
                        release++;
                        releaseIndex++;
                    }    
                }

                if(release > 0)
                {
                    answer.Add(release);
                    totalRelease += release;
                }
                    
            }

            return answer.ToArray();
        }
    }
}
