using System;
using System.Linq;
using System.Collections.Generic;

namespace Anonymous_Threat
{
    class Program
    {                    // ONLY 20/100
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> tokens = input.Split().ToList();
            List<string> results = new List<string>();
            int oldStartIndex = 0;
            int oldEndIndex = 0;
            bool isOver = false;

            while (input != "3:1")
            {
                string[] cmdArgs = input.Split();
                string command = cmdArgs[0];
                switch (command)
                {
                    case "merge":
                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);

                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        if (endIndex >= tokens.Count)
                        {
                            endIndex = tokens.Count - 1;
                        }
                        if (startIndex != 0)
                        {
                            for (int i = 0; i <= startIndex; i++)
                            {
                                results.Add(tokens[i]);
                            }
                            for (int i = startIndex; i < endIndex; i++)
                            {
                                results[startIndex] += tokens[i + 1];
                            }
                        }
                        else
                        {
                            results.Add(tokens[startIndex]);
                            for (int i = startIndex; i < endIndex; i++)
                            {
                                results[startIndex] += tokens[i + 1];
                            }
                            oldStartIndex = startIndex;
                            oldEndIndex = endIndex;

                            while ((input = Console.ReadLine()) != "3:1")
                            {
                                string[] someArgs = input.Split();
                                string comm = someArgs[0];
                                if (comm == "merge")
                                {
                                    startIndex = int.Parse(someArgs[1]);
                                    endIndex = int.Parse(someArgs[2]);
                                    if (startIndex >= oldStartIndex && startIndex <= oldEndIndex && endIndex > oldEndIndex)
                                    {
                                        for (int i = startIndex; i < endIndex; i++)
                                        {
                                            results[oldStartIndex] += tokens[endIndex];
                                        }
                                    }
                                }
                            }
                            if (input == "3:1")
                            {
                                isOver = true;
                            }
                        }
                        break;

                    case "divide":
                        int index = int.Parse(cmdArgs[1]);
                        int partitions = int.Parse(cmdArgs[2]);
                        string newResult = string.Empty;

                        int length = results[index].Length / partitions;
                        int rest = results[index].Length % partitions;

                        for (int i = 0; i < results[index].Length; i++)
                        {
                            newResult += results[index][i];
                            if (newResult.Length == length)
                            {
                                results.Add(newResult);
                                newResult = null;
                            }
                        }
                        results.RemoveAt(index);
                        break;
                    default:
                        break;
                }
                if (isOver)
                {
                    break;
                }
                else
                {
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine(string.Join(" ", results));
        }
    }
}
