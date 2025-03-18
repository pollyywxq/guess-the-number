using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);
            int numberOfAttempts = 0;
            int userGuess = 0;

            Console.WriteLine("Вгадайте число від 1 до 100.");

            while (userGuess != numberToGuess)
            {
                Console.Write("Ваша спроба: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out userGuess))
                {
                    Console.WriteLine("Будь ласка, введіть ціле число.");
                    continue;
                }

                numberOfAttempts++;

                if (userGuess < numberToGuess)
                {
                    Console.WriteLine("Більше!");
                }
                else if (userGuess > numberToGuess)
                {
                    Console.WriteLine("Менше!");
                }
            }

            Console.WriteLine($"Вітаємо!! Ви вгадали число за {numberOfAttempts} спроб.");
        }
    }
}