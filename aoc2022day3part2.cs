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

            // Loop through each line in the input in sets of three
            for (int i = 0; i < input.Length; i += 3)
            {
                // Get the rucksacks for the current group
                var rucksack1 = input[i];
                var rucksack2 = input[i + 1];
                var rucksack3 = input[i + 2];

                // Loop through each character in rucksack1
                foreach (var character in rucksack1)
                {
                    // Check if the character exists in rucksack2 and rucksack3
                    if (rucksack2.Contains(character) && rucksack3.Contains(character))
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
