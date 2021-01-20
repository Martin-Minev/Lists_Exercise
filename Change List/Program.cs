using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> listOfInt = Console.ReadLine()
                                         .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToList();

            string command = Console.ReadLine();

            while (command.ToUpper() != "END")
            {
                string[] cmdComponents = command.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
                                                 .ToArray();

                if (cmdComponents[0] == "Delete")
                {
                    listOfInt.RemoveAll(n => n == int.Parse(cmdComponents[1]));
                }

                else if (cmdComponents[0] == "Insert")
                {
                    listOfInt.Insert(int.Parse(cmdComponents[2]), int.Parse(cmdComponents[1]));
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", listOfInt));
        }
    }
}
