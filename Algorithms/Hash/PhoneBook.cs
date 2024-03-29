﻿using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/42577?language=python3
    /// Hash
    /// </summary>
    public class PhoneBook
    {
        /// <summary>
        /// 전화번호부에 적힌 전화번호 중, 한 번호가 다른 번호의 접두어인 경우가 있는지 확인하려 합니다.
        /// 전화번호가 다음과 같을 경우, 구조대 전화번호는 영석이의 전화번호의 접두사입니다.
        /// 
        /// 구조대 : 119
        /// 박준영 : 97 674 223
        /// 지영석 : 11 9552 4421
        ///  phone_book 이 solution 함수의 매개변수로 주어질 때, 를 return 하도록 solution 함수를 작성해주세요.      
        ///  
        /// 제한 사항        
        /// phone_book의 길이는 1 이상 1,000,000 이하입니다.  
        /// 각 전화번호의 길이는 1 이상 20 이하입니다.
        /// </summary>
        /// <param name="phoneBook">전화번호부에 적힌 전화번호를 담은 배열</param>
        /// <returns>어떤 번호가 다른 번호의 접두어인 경우가 없는지</returns>
        public static bool Solution(string[] phoneBook)
        {
            List<string> phoneBookList = new List<string>(phoneBook);

            string minElement = phoneBookList.Min();
            int minLength = minElement.Length;

            return phoneBookList.Select(x => x.Substring(0, minLength)).Count(x => x== minElement) == 1;
        }
    }
}
