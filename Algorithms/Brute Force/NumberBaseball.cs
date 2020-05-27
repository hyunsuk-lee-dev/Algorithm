using Algorithm.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42841
    /// BF
    /// </summary>
    public static class NumberBaseball
    {
        /// <summary>
        /// 숫자 야구 게임이란 2명이 서로가 생각한 숫자를 맞추는 게임입니다.
        /// 각자 서로 다른 1~9까지 3자리 임의의 숫자를 정한 뒤 서로에게 3자리의 숫자를 불러서 결과를 확인합니다.
        /// 그리고 그 결과를 토대로 상대가 정한 숫자를 예상한 뒤 맞힙니다.
        /// 
        /// * 숫자는 맞지만, 위치가 틀렸을 때는 볼
        /// * 숫자와 위치가 모두 맞을 때는 스트라이크
        /// * 숫자와 위치가 모두 틀렸을 때는 아웃
        /// 예를 들어, 아래의 경우가 있으면
        /// 
        /// A : 123
        /// B : 1스트라이크 1볼.
        /// A : 356
        /// B : 1스트라이크 0볼.
        /// A : 327
        /// B : 2스트라이크 0볼.
        /// A : 489
        /// B : 0스트라이크 1볼.
        /// 
        /// 이때 가능한 답은 324와 328 두 가지입니다.
        /// </summary>
        /// <param name="baseball">질문한 세 자리의 수, 스트라이크의 수, 볼의 수를 담은 2차원 배열</param>
        /// <returns>가능한 답의 개수</returns>
        public static int Solution(int[,] baseball)
        {
            List<int[]> hintList = baseball.Convert2DArrayToList();

            int answer = 0;

            for(int i = 1 ; i <= 9 ; i++)
            {
                for(int j = 1 ; j <= 9 ; j++)
                {
                    if(j == i)
                        continue;

                    for(int k = 1 ; k <= 9 ; k++)
                    {
                        if(k == i || k == j)
                            continue;

                        bool satisfyHint = true;

                        foreach(int[] hint in hintList)
                        {
                            int strike = 0;
                            int ball = 0;

                            int iTarget = hint[0] / 100;
                            int jTarget = (hint[0] % 100) / 10;
                            int kTarget = hint[0] % 10;

                            if(iTarget == i)
                                strike++;
                            else if(iTarget == j || iTarget == k)
                                ball++;

                            if(jTarget == j)
                                strike++;
                            else if(jTarget == i || jTarget == k)
                                ball++;

                            if(kTarget == k)
                                strike++;
                            else if(kTarget == i || kTarget == j)
                                ball++;

                            if(strike != hint[1] || ball != hint[2])
                                satisfyHint = false;
                        }

                        if(satisfyHint)
                            answer++;
                    }
                }
            }

            return answer;
        }
    }
}
