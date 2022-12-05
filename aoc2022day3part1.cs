using System;
using System.IO;
using System.Linq;

namespace Rucksack
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            // Read input.txt
            var input = File.ReadAllLines("input.txt");

            // Loop through each line in the input
            foreach (var line in input)
            {
                // Get the length of the line
                int length = line.Length;

                // Split the line into two compartments
                var compartment1 = line.Substring(0, length / 2);
                var compartment2 = line.Substring(length / 2);

                // Loop through each character in compartment1
                foreach (var character in compartment1)
                {
                    // Check if the character exists in compartment2
                    if (compartment2.Contains(character))
                    {
                        // If it does, add the priority to the sum
                        sum += GetPriority(character);
                        break;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        static int GetPriority(char character)
        {
            // Check if the character is uppercase
            if (Char.IsUpper(character))
            {
                // If it is, return its priority (1-26 + 26)
                return character - 'A' + 1 + 26;
            }
            else
            {
                // If it is not, return its priority (1-26)
                return character - 'a' + 1;
            }
        }
    }

}
