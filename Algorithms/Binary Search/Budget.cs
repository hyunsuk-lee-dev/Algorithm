using Algorithm.Functions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// https://programmers.co.kr/learn/courses/30/lessons/43237
    /// BS
    /// </summary>
    public class Budget
    {
        /// <summary>
        /// 국가의 역할 중 하나는 여러 지방의 예산요청을 심사하여 국가의 예산을 분배하는 것입니다. 
        /// 국가예산의 총액은 미리 정해져 있어서 모든 예산요청을 배정해 주기는 어려울 수도 있습니다. 
        /// 그래서 정해진 총액 이하에서 가능한 한 최대의 총 예산을 다음과 같은 방법으로 배정합니다.
        /// 
        /// 1. 모든 요청이 배정될 수 있는 경우에는 요청한 금액을 그대로 배정합니다.
        /// 2. 모든 요청이 배정될 수 없는 경우에는 특정한 정수 상한액을 계산하여 그 이상인 예산요청에는 모두 상한액을 배정합니다. 
        /// 상한액 이하의 예산요청에 대해서는 요청한 금액을 그대로 배정합니다. 
        /// 
        /// 제한 사항
        /// 지방의 수는 3 이상 100,000 이하인 자연수입니다.
        /// 각 지방에서 요청하는 예산은 1 이상 100,000 이하인 자연수입니다.
        /// 총 예산은 지방의 수 이상 1,000,000,000 이하인 자연수입니다.
        /// </summary>
        /// <param name="budgets">각 지방에서 요청하는 예산이 담긴 배열</param>
        /// <param name="M">총 예</param>
        /// <returns>조건을 모두 만족하는 상한액</returns>
        public static int Solution(int[] budgets, int M)
        {
            int maxBudget = 0;
            int budgetSum = 0;

            foreach(int budget in budgets)
            {
                budgetSum += budget;
                maxBudget = Math.Max(maxBudget, budget);
            }

            if(budgetSum <= M)
                return maxBudget;

            int lowBudgetCut = 0;
            int highBudgetCut = maxBudget;
            int midBudgetCut = 0;
            int budgetDifferent = 0;

            while(lowBudgetCut <= highBudgetCut)
            {
                midBudgetCut = (lowBudgetCut + highBudgetCut) / 2;

                budgetSum = 0;
                foreach(int budget in budgets)
                    budgetSum += budget <= midBudgetCut ? budget : midBudgetCut;

                budgetDifferent = budgetSum - M;

                if(budgetDifferent == 0)
                    return midBudgetCut;
                else if(budgetDifferent > 0)
                    highBudgetCut = midBudgetCut - 1;
                else
                    lowBudgetCut = midBudgetCut + 1;
            }

            return budgetDifferent > 0 ? midBudgetCut - 1 : midBudgetCut;
        }


    }
}
