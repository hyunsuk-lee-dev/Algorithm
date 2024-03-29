﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43163
    /// DFS/BFS
    /// </summary>
    public class WordChanger
    {
        /// <summary>
        /// 두 개의 단어 begin, target과 단어의 집합 words가 있습니다. 
        /// 아래와 같은 규칙을 이용하여 begin에서 target으로 변환하는 가장 짧은 변환 과정을 찾으려고 합니다.
        /// 
        /// 1. 한 번에 한 개의 알파벳만 바꿀 수 있습니다.
        /// 2. words에 있는 단어로만 변환할 수 있습니다.
        /// 
        /// 예를 들어 begin이 hit, target가 cog 
        /// words가[hot, dot, dog, lot, log, cog] 라면 
        /// hit -> hot -> dot -> dog -> cog와 같이 4단계를 거쳐 변환할 수 있습니다.
        /// </summary>
        /// <returns>최소 몇 단계의 과정을 거쳐 begin을 target으로 변환할 수 있는지</returns>
        /// 각 단어는 알파벳 소문자로만 이루어져 있습니다.
        /// 각 단어의 길이는 3 이상 10 이하이며 모든 단어의 길이는 같습니다.
        /// words에는 3개 이상 50개 이하의 단어가 있으며 중복되는 단어는 없습니다.
        /// begin과 target은 같지 않습니다.
        /// 변환할 수 없는 경우에는 0를 return 합니다.
        public static int Solution(string begin, string target, string[] words)
        {
            int targetIndex = words.ToList().IndexOf(target);

            bool[] referencedWord = new bool[words.Length];
            int[] distanceWord = new int[words.Length];

            string baseWord = begin;
            int baseDistance = 0;
            bool isBaseChanged = true;
            
            while(isBaseChanged)
            {
                isBaseChanged = false;

                for(int i = 0 ; i < words.Length ; i++)
                {
                    if(Adjacent(baseWord, words[i]) && !referencedWord[i])
                    {
                        if(i == targetIndex)
                            return baseDistance + 1;

                        distanceWord[i] = baseDistance + 1;
                    }
                }

                for(int i = 0 ; i < words.Length ; i++)
                {
                    if(distanceWord[i] > 0 && !referencedWord[i])
                    {
                        baseWord = words[i];
                        baseDistance = distanceWord[i];
                        referencedWord[i] = true;
                        isBaseChanged = true;
                    }
                }
            }


            return 0;
        }

        static bool Adjacent(string a, string b)
        {
            int result = 0;

            for(int i = 0 ; i < a.Length ; i++)
            {
                if(a[i] != b[i])
                    result++;
            }

            return result == 1;
        }
    }
}
