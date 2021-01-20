using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int sumRemoved = 0;
            int currentElement = 0;
            int elementToInsert = 0;

            while (distances.Count > 0)
            {
                int currentIndex = int.Parse(Console.ReadLine());
                if (currentIndex < 0)
                {
                    currentElement = distances[0];
                    sumRemoved += currentElement;
                    distances.RemoveAt(0);
                    for (int i = 0; i < distances.Count; i++)
                    {
                        if (distances[i] <= currentElement)
                        {
                            distances[i] += currentElement;
                        }
                        else
                        {
                            distances[i] -= currentElement;
                        }
                    }
                    elementToInsert = distances[distances.Count - 1];
                    distances.Insert(0, elementToInsert);
                    continue;
                }
                else if (currentIndex >= distances.Count)
                {
                    currentElement = distances[distances.Count - 1];
                    sumRemoved += currentElement;
                    distances.RemoveAt(distances.Count - 1);
                    for (int i = 0; i < distances.Count; i++)
                    {
                        if (distances[i] <= currentElement)
                        {
                            distances[i] += currentElement;
                        }
                        else
                        {
                            distances[i] -= currentElement;
                        }
                    }
                    elementToInsert = distances[0];
                    distances.Add(elementToInsert);
                    continue;
                }
                currentElement = distances[currentIndex];
                sumRemoved += currentElement;
                distances.RemoveAt(currentIndex);
                for (int i = 0; i < distances.Count; i++)
                {
                    if (distances[i] <= currentElement)
                    {
                        distances[i] += currentElement;
                    }
                    else
                    {
                        distances[i] -= currentElement;
                    }
                }
                currentElement = 0;
            }
            Console.WriteLine(sumRemoved);
        }
    }
}
