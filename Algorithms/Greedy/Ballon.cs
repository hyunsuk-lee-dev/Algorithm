using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// Algorithm.Algorithms.Greedy
    /// </summary>
    public class Ballon
    {
        /// <summary>
        /// 일렬로 나열된 n개의 풍선이 있습니다. 모든 풍선에는 서로 다른 숫자가 써져 있습니다. 당신은 다음 과정을 반복하면서 풍선들을 단 1개만 남을 때까지 계속 터트리려고 합니다.
        /// 
        ///     1. 임의의 인접한 두 풍선을 고른 뒤, 두 풍선 중 하나를 터트립니다.
        ///     2. 터진 풍선으로 인해 풍선들 사이에 빈 공간이 생겼다면, 빈 공간이 없도록 풍선들을 중앙으로 밀착시킵니다.
        ///     
        /// 여기서 조건이 있습니다.인접한 두 풍선 중에서 번호가 더 작은 풍선을 터트리는 행위는 최대 1번만 할 수 있습니다. 
        /// 즉, 어떤 시점에서 인접한 두 풍선 중 번호가 더 작은 풍선을 터트렸다면, 그 이후에는 인접한 두 풍선을 고른 뒤 번호가 더 큰 풍선만을 터트릴 수 있습니다.
        /// 당신은 어떤 풍선이 최후까지 남을 수 있는지 알아보고 싶습니다.
        /// 위에 서술된 조건대로 풍선을 터트리다 보면, 어떤 풍선은 최후까지 남을 수도 있지만, 어떤 풍선은 무슨 수를 쓰더라도 마지막까지 남기는 것이 불가능할 수도 있습니다.
        /// </summary>
        /// <param name="a">/// 일렬로 나열된 n개의 풍선이 있습니다. 모든 풍선에는 서로 다른 숫자가 써져 있습니다. 당신은 다음 과정을 반복하면서 풍선들을 단 1개만 남을 때까지 계속 터트리려고 합니다.
        /// 임의의 인접한 두 풍선을 고른 뒤, 두 풍선 중 하나를 터트립니다.
        /// 터진 풍선으로 인해 풍선들 사이에 빈 공간이 생겼다면, 빈 공간이 없도록 풍선들을 중앙으로 밀착시킵니다.
        /// 여기서 조건이 있습니다.인접한 두 풍선 중에서 번호가 더 작은 풍선을 터트리는 행위는 최대 1번만 할 수 있습니다. 
        /// 즉, 어떤 시점에서 인접한 두 풍선 중 번호가 더 작은 풍선을 터트렸다면, 그 이후에는 인접한 두 풍선을 고른 뒤 번호가 더 큰 풍선만을 터트릴 수 있습니다.
        /// 당신은 어떤 풍선이 최후까지 남을 수 있는지 알아보고 싶습니다.
        /// 위에 서술된 조건대로 풍선을 터트리다 보면, 어떤 풍선은 최후까지 남을 수도 있지만, 어떤 풍선은 무슨 수를 쓰더라도 마지막까지 남기는 것이 불가능할 수도 있습니다.</param>
        /// </summary>
        /// <param name="a">일렬로 나열된 풍선들의 번호가 담긴 배열</param>
        /// <returns>최후까지 남기는 것이 가능한 풍선들의 개수</returns>
        /// 
        /// a의 길이는 1 이상 1,000,000 이하입니다.
        /// a[i] 는 i+1 번째 풍선에 써진 숫자를 의미합니다.
        /// a의 모든 수는 -1,000,000,000 이상 1,000,000,000 이하인 정수입니다.
        /// a의 모든 수는 서로 다릅니다.
        /// 
        public static int Solution(int[] a)
        {
            bool[] min = new bool[a.Length];
            int minValue = int.MaxValue;

            for(int i = 0; i < a.Length; i++)
            {
                if(minValue > a[i])
                {
                    minValue = a[i];
                    min[i] = true;
                }
            }

            minValue = int.MaxValue;
            for(int i = a.Length-1; i >= 0; i--)
            {
                if(minValue > a[i])
                {
                    minValue = a[i];
                    min[i] = true;
                }
            }

            return Array.FindAll(min, o => o).Length;
        }
    }
}
