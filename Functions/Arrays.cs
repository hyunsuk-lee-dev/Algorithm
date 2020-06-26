using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Functions
{
    public static class Arrays
    {
        public static List<T[]> Convert2DArrayToList<T>(this T[,] array)
        {
            List<T[]> result = new List<T[]>();

            for(int i = 0 ; i < array.GetLength(0) ; i++)
            {
                T[] element = new T[array.GetLength(1)];
                for(int j = 0 ; j < array.GetLength(1) ; j++)
                    element[j] = array[i, j];

                result.Add(element);
            }

            return result;
        }

        public static string[,] ConvertDimensionalArray(string[][] value)
        {
            string[,] result = new string[value.Length, value[0].Length];

            for(int i = 0 ; i < value.Length ; i++)
            {
                for(int j = 0 ; j < value[0].Length ; j++)
                    result[i, j] = value[i][j];

            }
            return result;
        }

        public static string ToStrings<T>(this IEnumerable<T> enumerable)
        {
            string mergedString = "[";

            for(int i = 0 ; i < enumerable.Count() ; i++)
            {
                if(i == enumerable.Count() - 1)
                    mergedString += $"{enumerable.ElementAt(i)}";
                else
                    mergedString += $"{enumerable.ElementAt(i)}, ";
            }

            mergedString += "]";

            return mergedString;
        }

        public static T[] ToArrays<T>(this string target)
        {
            target = target.Replace("[", "");
            target = target.Replace("]", "");
            string[] splitString = target.Split(',');

            T[] convertedArray = new T[splitString.Length];

            for(int i = 0 ; i < convertedArray.Length ; i++)
            {
                convertedArray[i] = (T)Convert.ChangeType(splitString[i].Trim(), typeof(T));
            }

            return convertedArray;
        }

        //public static T[,] ToMultiArrays<T>(this string target)
        //{
        //    target = target.Replace("[", "");
        //    target = target.Replace("]", "");
        //    string[] splitString = target.Split(',');

        //    T[,] convertedArray = new T[splitString.Length];

        //    for(int i = 0 ; i < convertedArray.Length ; i++)
        //    {
        //        convertedArray[i] = (T)Convert.ChangeType(splitString[i], typeof(T));
        //    }

        //    return convertedArray;
        //}

    }
}
