using System;
using System.IO;

namespace ElfCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the input from the file
            string[] input = File.ReadAllLines("input.txt");

            // Initialize variables to keep track of the Elf with the most calories
            // and the total number of calories for that Elf
            int elfWithMostCalories = 0;
            int maxCalories = 0;
            int currentElf = 0;
            int currentCalories = 0;

            // Loop through the input line by line
            foreach (string line in input)
            {
                // If the line is empty, it marks the end of an Elf's inventory
                if (line == "")
                {
                    // If the current Elf has more calories than the previous Elf with the most calories,
                    // update the Elf with the most calories and the total number of calories
                    if (currentCalories > maxCalories)
                    {
                        elfWithMostCalories = currentElf;
                        maxCalories = currentCalories;
                    }

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

            // Check if the last Elf has more calories than the previous Elf with the most calories
            if (currentCalories > maxCalories)
            {
                elfWithMostCalories = currentElf;
                maxCalories = currentCalories;
            }

            // Output the result
            Console.WriteLine($"Elf {elfWithMostCalories + 1} has the most calories with a total of {maxCalories} calories.");
        }
    }
}
