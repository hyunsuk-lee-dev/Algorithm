using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Functions
{
    public static class Printer
    {
        public static void Line()
        {
            Console.WriteLine();
        }

        public static void Print(string tag, string value)
        {
            Console.WriteLine($"{tag} : {value}");
        }

        public static void Print(string tag, float value)
        {
            Console.WriteLine($"{tag} : {value}");
        }

        public static void Print(string tag, int value)
        {
            Console.WriteLine($"{tag} : {value}");
        }

        public static void Print(string tag, long value)
        {
            Console.WriteLine($"{tag} : {value}");
        }

        public static void Print(string tag, object value)
        {
            Console.WriteLine($"{tag} : {value}");
        }

        public static void Print(string tag, char value)
        {
            Console.WriteLine($"{tag} : {value}");
        }

        public static void Print(string tag, bool value)
        {
            Console.WriteLine($"{tag} : {value}");
        }

        public static void Print(string tag, double value)
        {
            Console.WriteLine($"{tag} : {value}");
        }
    }
}
