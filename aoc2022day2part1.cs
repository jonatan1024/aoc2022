using System;
using System.IO;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the input file
            string[] lines = File.ReadAllLines("input.txt");

            // Initialize the total score
            int totalScore = 0;

            // Loop through each line of the input file
            foreach (string line in lines)
            {
                // Split the line into two parts: the opponent's choice and your choice
                string[] choices = line.Split(" ");
                string opponent = choices[0];
                string you = choices[1];

                // Initialize the round score to the value of your choice
                int roundScore = 0;
                if (you == "X") roundScore = 1;
                else if (you == "Y") roundScore = 2;
                else if (you == "Z") roundScore = 3;

                // Determine the outcome of the round
                if (opponent == "A" && you == "Y" ||
                    opponent == "B" && you == "Z" ||
                    opponent == "C" && you == "X")
                {
                    // You win
                    roundScore += 6;
                }
                else if (opponent == "A" && you == "Z" ||
                         opponent == "B" && you == "X" ||
                         opponent == "C" && you == "Y")
                {
                    // You lose
                    roundScore += 0;
                }
                else
                {
                    // It's a draw
                    roundScore += 3;
                }

                // Add the round score to the total score
                totalScore += roundScore;
            }

            // Print the total score
            Console.WriteLine(totalScore);
        }
    }

}
