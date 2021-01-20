using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                                        .Split('|')
                                        .ToList();
            items.Reverse();
            List<string> result = new List<string>(items.Count);
            foreach (string currentItem in items)
            {
                string[] numbers = currentItem
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();
                foreach (string numbersToAdd in numbers)
                {
                    result.Add(numbersToAdd);
                }
            }
            Console.Write(string.Join(" ", result));
        }
    }
}
