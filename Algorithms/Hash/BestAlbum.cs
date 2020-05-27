using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42579
    /// Hash
    /// </summary>
    class BestAlbum
    {
        /// <summary>
        /// 스트리밍 사이트에서 장르 별로 가장 많이 재생된 노래를 두 개씩 모아 베스트 앨범을 출시하려 합니다. 
        /// 노래는 고유 번호로 구분하며, 노래를 수록하는 기준은 다음과 같습니다.
        /// 
        /// 속한 노래가 많이 재생된 장르를 먼저 수록합니다.
        /// 장르 내에서 많이 재생된 노래를 먼저 수록합니다.
        /// 장르 내에서 재생 횟수가 같은 노래 중에서는 고유 번호가 낮은 노래를 먼저 수록합니다.
        /// 
        /// 제한사항
        /// genres[i] 는 고유번호가 i인 노래의 장르입니다.
        /// plays[i] 는 고유번호가 i인 노래가 재생된 횟수입니다.
        /// genres와 plays의 길이는 같으며, 이는 1 이상 10,000 이하입니다.
        /// 장르 종류는 100개 미만입니다.
        /// 장르에 속한 곡이 하나라면, 하나의 곡만 선택합니다.
        /// 모든 장르는 재생된 횟수가 다릅니다.
        /// 
        /// </summary>
        /// <param name="genres">노래의 장르를 나타내는 문자열 배열</param>
        /// <param name="plays">노래별 재생 횟수를 나타내는 정수 배열</param>
        /// <returns>베스트 앨범에 들어갈 노래의 고유 번호의 순서</returns>
        public static int[] Solution(string[] genres, int[] plays)
        {
            Dictionary<string, Tuple<int, List<int>>> genrePlaysIndices = new Dictionary<string, Tuple<int, List<int>>>();

            for(int i = 0 ; i < genres.Length ; i++)
            {
                if(genrePlaysIndices.ContainsKey(genres[i]))
                {
                    Tuple<int, List<int>> item = genrePlaysIndices[genres[i]];
                    int totalPlays = item.Item1 + plays[i];
                    List<int> indices = item.Item2;

                    bool inserted = false;
                    for(int index = 0 ; index < indices.Count ; index++)
                    {
                        if(plays[indices[index]] < plays[i])
                        {
                            indices.Insert(index, i);
                            inserted = true;
                            break;
                        }
                    }

                    if(!inserted)
                        indices.Add(i);

                    genrePlaysIndices[genres[i]] = new Tuple<int, List<int>>(totalPlays, indices);
                }
                else
                {
                    genrePlaysIndices.Add(genres[i], new Tuple<int, List<int>>(plays[i], new List<int>() { i }));
                }
            }

            Dictionary<string, Tuple<int, List<int>>> sortedGenrePlays = genrePlaysIndices.OrderByDescending(p => p.Value.Item1).ToDictionary(p => p.Key, p => p.Value);

            List<int> answer = new List<int>();

            foreach(Tuple<int, List<int>> genre in sortedGenrePlays.Values)
            {
                answer.AddRange(genre.Item2.GetRange(0, Math.Min(2, genre.Item2.Count)));
            }

            return answer.ToArray();
        }
    }
}
