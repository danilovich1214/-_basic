using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayDifferents
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] firstArray = { "Alex", "Dima", "Kate", "Galina", "Ivan"};
            string[] secondArray = { "Dima", "Ivan", "Kate" };
            
            ExecuteFirstStrategy(firstArray, secondArray);
            ExecuteSecondStrategy(firstArray, secondArray);

            Console.ReadLine();
        }

        static void ExecuteFirstStrategy(string[] firstArray, string[] secondArray)
        {
            Console.WriteLine("Array different by first strategy");
            IEnumerable<string> resultArray = firstArray.Except(secondArray);            
            
            PrintStringArray(resultArray);
        }

        static void ExecuteSecondStrategy(string[] firstArray, string[] secondArray)
        {
            Console.WriteLine("Array different by second strategy");
            List<string> resultArray = new List<string>();

            foreach (string item in firstArray)
            {
                if (!secondArray.Contains(item))
                {
                    resultArray.Add(item);
                }
            }

            PrintStringArray(resultArray);            
        }

        static void PrintStringArray(List<string> array)
        {
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void PrintStringArray(IEnumerable<string> array)
        {
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
