using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using System.Security.AccessControl;

namespace HangMan
{
    internal class Program
    {
        private static void printHangMan(int wrong)
        {
            if(wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O    |");
                Console.WriteLine("|    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("  O  |");
                Console.WriteLine(" /|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\    |");
                Console.WriteLine("/    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }

        private static int printWord(List<char>lettersGuessed, string randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.WriteLine("\r\n");
            foreach(char c in randomWord)
            {
                if(lettersGuessed.Contains(c))
                {
                    Console.WriteLine(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.WriteLine(" ");
                }
                counter++;
            }
            return rightLetters;
        }

        private static void printLines(string randomWord)
        {
            Console.WriteLine("\r");
            foreach(char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to a game of HangMan");
            Console.WriteLine("-------------------------------");

            Random random = new Random();
            List<string> words = new List<string> { "bugatti", "cash", "colleague", "market", "investigation", "treaty", "hello", "football" };
            int index = random.Next(words.Count);
            string randomWord = words[index];

            foreach(char c in randomWord)
            {
                Console.WriteLine("_ ");
            }

            int wordLength = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char> currentLettersGuess = new List<char>();
            int rightLetters = 0;

            while(amountOfTimesWrong != 6 && rightLetters != wordLength)
            {
                Console.WriteLine("\nLetters you have guessed so far: ");
                foreach(char letter in currentLettersGuess)
                {
                    Console.Write(letter + " ");
                }

                Console.WriteLine("\nGuess a letter: ");
                char lettersGussed = Console.ReadLine()[0];

                if(currentLettersGuess.Contains(lettersGussed))
                {
                    Console.Write("\r\nThis letter has already been guessed!");
                    printHangMan(amountOfTimesWrong);
                    rightLetters = printWord(currentLettersGuess, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for(int i = 0; i < randomWord.Length; i++) { if(lettersGussed == randomWord[i]) { right = true; } }

                    if(right)
                    {
                        printHangMan(amountOfTimesWrong);
                        currentLettersGuess.Add(lettersGussed);
                        rightLetters = printWord(currentLettersGuess, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amountOfTimesWrong++;
                        currentLettersGuess.Add(lettersGussed);
                        printHangMan(amountOfTimesWrong);
                        rightLetters = printWord(currentLettersGuess, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame is now over, Thanks for playing!");
        }
    }
}