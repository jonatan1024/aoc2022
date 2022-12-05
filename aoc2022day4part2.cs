using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int count = 0;
            foreach (string line in input)
            {
                string[] ranges = line.Split(',');
                int[] firstRange = ranges[0].Split('-').Select(int.Parse).ToArray();
                int[] secondRange = ranges[1].Split('-').Select(int.Parse).ToArray();
                if ((firstRange[0] <= secondRange[0] && firstRange[1] >= secondRange[0]) || (firstRange[0] <= secondRange[1] && firstRange[1] >= secondRange[1]))
                {
                    count++;
                }
                else if ((secondRange[0] <= firstRange[0] && secondRange[1] >= firstRange[0]) || (secondRange[0] <= firstRange[1] && secondRange[1] >= firstRange[1]))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
