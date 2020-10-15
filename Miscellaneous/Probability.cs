using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProbabiltyDistribution
{
    public int[] value;
    public float[] probability;

    public float TotalProbability { get => probability.Sum(); }

    public int GetValue(float probability)
    {
        float accumulatedProbability = 0f;

        for(int i = 0 ; i< this.probability.Length ; i++)
        {
            accumulatedProbability += this.probability[i];

            if(probability < accumulatedProbability)
                return value[i];
        }

        return value.Last();
    }
}

public static class Probability
{
    public static float GetRandom(int count, ProbabiltyDistribution probability, int randomSeed)
    {
        Random r = new Random(randomSeed);

        int acquiredValue = 0;


        for(int i = 0 ; i < count ; i++)
        {
            float randomValue = (float)r.NextDouble() * probability.TotalProbability;

            acquiredValue += probability.GetValue(randomValue);
        }


        Console.WriteLine("Real Acquired Value : " + acquiredValue );
        Console.WriteLine("Real Acquired Value Percentage  : " + acquiredValue / (float)count );

        float predictedValuePercentage = 0f;
        for(int i = 0 ; i < probability.value.Length ; i++)
        {
            predictedValuePercentage += probability.value[i] * probability.probability[i] / probability.TotalProbability;
        }

        float predictedValue = (predictedValuePercentage * count);


        Console.WriteLine("Predicted Value : " + predictedValue);
        Console.WriteLine("Predicted Value Percentage : " + predictedValuePercentage);

        return acquiredValue / (float)count;
    }

    public static void Main(int count, int random)
    {
        int[] counts = new int[random];
        Random r = new Random();

        for(int i = 0 ; i < count ; i++)
        {
            int randomValue = r.Next(0, random);

            counts[randomValue]++;
        }


        for(int i = 0 ; i < random ; i++)
        {
            Console.WriteLine(i + "이 등장한 횟수 : " + counts[i]);
        }

        Console.WriteLine();

        for(int i = 0 ; i < random ; i++)
        {
            Console.WriteLine(i + "이 표준횟수와의 오차 : " + Math.Abs(counts[i] - (count / random)));
        }

        Console.WriteLine();

        for(int i = 0 ; i < random ; i++)
        {
            Console.WriteLine(i + "이 등장한 횟수 : " + (float)counts[i] / count);
        }

        Console.WriteLine();

        for(int i = 0 ; i < random ; i++)
        {
            Console.WriteLine(i + "의 표준확률과의 오차 : " + Math.Abs(((float)counts[i] / count) - (1f / random)));
        }

        Console.WriteLine();
    }
}

