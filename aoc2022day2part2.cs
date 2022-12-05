using System;
using System.IO;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input from input.txt
            string[] input = File.ReadAllLines("input.txt");

            // Keep track of total score
            int totalScore = 0;

            // Loop through each line in input
            foreach (string line in input)
            {
                // Split the line into opponent's choice and desired outcome
                string[] choices = line.Split(' ');
                string opponentChoice = choices[0];
                string desiredOutcome = choices[1];

                // Determine the player's choice based on desired outcome
                string playerChoice = "";
                if (desiredOutcome == "X")
                {
                    // Player loses, so choose shape that loses to opponent's choice
                    if (opponentChoice == "A") playerChoice = "C";
                    else if (opponentChoice == "B") playerChoice = "A";
                    else if (opponentChoice == "C") playerChoice = "B";
                }
                else if (desiredOutcome == "Y")
                {
                    // Player draws, so choose the same shape as opponent
                    playerChoice = opponentChoice;
                }
                else if (desiredOutcome == "Z")
                {
                    // Player wins, so choose shape that wins against opponent's choice
                    if (opponentChoice == "A") playerChoice = "B";
                    else if (opponentChoice == "B") playerChoice = "C";
                    else if (opponentChoice == "C") playerChoice = "A";
                }

                // Determine score for this round
                int score = 0;
                if (playerChoice == opponentChoice)
                {
                    // Draw
                    score = 3;
                }
                else
                {
                    // Determine if player won or lost
                    bool playerWins = false;
                    if (playerChoice == "A" && opponentChoice == "C") playerWins = true;
                    else if (playerChoice == "B" && opponentChoice == "A") playerWins = true;
                    else if (playerChoice == "C" && opponentChoice == "B") playerWins = true;

                    if (playerWins)
                    {
                        // Player wins
                        score = 6;
                    }
                    else
                    {
                        // Player loses
                        score = 0;
                    }
                }

                // Add score for this round to total score
                if (playerChoice == "A") totalScore += 1 + score;
                else if (playerChoice == "B") totalScore += 2 + score;
                else if (playerChoice == "C") totalScore += 3 + score;
            }

            // Output total score
            Console.WriteLine(totalScore);
        }
    }

}
