using System;
using System.Collections.Generic;
using System.IO;

namespace ElfCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the input from the file
            string[] input = File.ReadAllLines("input.txt");

            // Initialize a dictionary to keep track of the Elves and their total calories
            Dictionary<int, int> elfCalories = new Dictionary<int, int>();
            int currentElf = 0;
            int currentCalories = 0;

            // Loop through the input line by line
            foreach (string line in input)
            {
                // If the line is empty, it marks the end of an Elf's inventory
                if (line == "")
                {
                    // Add the current Elf and their total calories to the dictionary
                    elfCalories.Add(currentElf, currentCalories);

                    // Reset the current calories and increment the current Elf number
                    currentCalories = 0;
                    currentElf++;
                }
                else
                {
                    // Otherwise, add the number of calories on the line to the current total
                    currentCalories += int.Parse(line);
                }
            }

            // Add the last Elf and their total calories to the dictionary
            elfCalories.Add(currentElf, currentCalories);

            // Sort the dictionary by the Elves' total calories in descending order
            var sortedElfCalories = from entry in elfCalories
                                    orderby entry.Value descending
                                    select entry;

            // Initialize a variable to keep track of the total calories for the top three Elves
            int totalCalories = 0;

            // Loop through the top three Elves
            foreach (KeyValuePair<int, int> elf in sortedElfCalories.Take(3))
            {
                // Add the Elf's total calories to the total
                totalCalories += elf.Value;

                // Output the Elf's number and total calories
                Console.WriteLine($"Elf {elf.Key + 1} has {elf.Value} calories.");
            }

            // Output the total calories for the top three Elves
            Console.WriteLine($"The top three Elves have a total of {totalCalories} calories.");
        }
    }
}
