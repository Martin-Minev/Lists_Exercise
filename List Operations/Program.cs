using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Operations
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> listOfInt = Console.ReadLine()
                                          .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToList();
            string input = Console.ReadLine();
            while (input.ToUpper() != "END")
            {
                string[] cmd = input.Split(' ');
                string command = cmd[0];
                if (command == "Add")
                {
                    int element = int.Parse(cmd[1]);
                    listOfInt.Add(element);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(cmd[1]);
                    int index = int.Parse(cmd[2]);

                    if (IsValidIndex(index, listOfInt.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        listOfInt.Insert(index, number);
                    }
                }
                else if (command == "Remove")
                {
                    int index = int.Parse(cmd[1]);
                    if (IsValidIndex(index, listOfInt.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        listOfInt.RemoveAt(index);
                    }
                }
                else if (command == "Shift")
                {
                    int rotation = int.Parse(cmd[2]);
                    if (cmd[1] == "left")
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            int firstElement = listOfInt[0];
                            for (int j = 0; j < listOfInt.Count - 1; j++)
                            {
                                listOfInt[j] = listOfInt[j + 1];
                            }
                            listOfInt[listOfInt.Count - 1] = firstElement;
                        }
                    }
                    else if (cmd[1] == "right")
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            int lastElement = listOfInt[listOfInt.Count - 1];
                            for (int k = listOfInt.Count - 1; k > 0; k--)
                            {
                                listOfInt[k] = listOfInt[k - 1];
                            }
                            listOfInt[0] = lastElement;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", listOfInt));
        }
        static bool IsValidIndex(int index, int count)
        {
            return index > count || index < 0;
        }
    }
}
