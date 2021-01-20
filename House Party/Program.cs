using System;
using System.Collections.Generic;
using System.Linq;

namespace House_Party
{
    class Program
    {
        public static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] nameAndGoing = Console.ReadLine()
                                           .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
                                           .ToArray();
                string guestName = nameAndGoing[0];
                if (nameAndGoing.Length > 3)
                {
                    if (names.Contains(guestName))
                    {
                        names.Remove(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is not in the list!");
                    }
                }
                else
                {
                    if (!names.Contains(guestName))
                    {
                        names.Add(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is already in the list!");
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
