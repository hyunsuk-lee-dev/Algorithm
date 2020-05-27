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

        public static string ArrayToString<T>(this T[] array)
        {
            string mergedString = "[";

            for(int i = 0 ; i < array.Length ; i++)
            {
                if(i == array.Length - 1)
                    mergedString += $"{array[i]}";
                else
                    mergedString += $"{array[i]}, ";
            }

            mergedString += "]";

            return mergedString;
        }

        public static T[] StringToArray<T>(this string target)
        {
            target = target.Replace("[", "");
            target = target.Replace("]", "");
            string[] splitString = target.Split(',');

            T[] convertedArray = new T[splitString.Length];

            for(int i = 0 ; i < convertedArray.Length ; i++)
            {
                convertedArray[i] = (T)Convert.ChangeType(splitString[i], typeof(T));
            }

            return convertedArray;
        }

    }
}
