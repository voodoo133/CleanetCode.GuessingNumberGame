using System;

namespace CleanetCode.GuessingNumberGame.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру 'Угадай число'");
            Console.WriteLine("Как вас зовут?");
            string userName = Console.ReadLine();

            while (String.IsNullOrEmpty(userName))
            {
                Console.WriteLine("\nПожалуйста, укажите своё имя");
                userName = Console.ReadLine();
            }

            Console.WriteLine($"\nПривет, {userName}\nЯ загадал тебе число от 0 до 99\nПопробуй отгадать\n");

            Random rnd = new Random();
            int minValue = 0;
            int maxValue = 100;
            int secretNumber = rnd.Next(minValue, maxValue);
            bool isWin = false;
            int attemptsAmount = 1;

            while (!isWin)
            {
                int userNumber = -1;
                bool isCorrectNumber = false;

                do
                {
                    Console.WriteLine($"Попытка №{attemptsAmount}");
                    Console.WriteLine($"Введи число от {minValue} до {maxValue - 1}");
                    string userInput = Console.ReadLine();
                    bool isIntNumber = int.TryParse(userInput, out userNumber);

                    isCorrectNumber = isIntNumber && userNumber > minValue && userNumber < maxValue;

                    if (!isCorrectNumber)
                        Console.WriteLine($"\nВы ввели {userInput}. Нужно ввести число от {minValue} до {maxValue - 1}\n");

                } while (!isCorrectNumber);

                if (userNumber > secretNumber)
                {
                    Console.WriteLine($"\nВаше число {userNumber} больше, чем загаданное\n");
                    attemptsAmount++;
                }
                else if (userNumber < secretNumber)
                {
                    Console.WriteLine($"\nВаше число {userNumber} меньше, чем загаданное\n");
                    attemptsAmount++;
                }
                else
                {
                    isWin = true;
                    Console.WriteLine($"\n{userName}, вы наконец-то угадали всего лишь с {attemptsAmount} " + 
                        GetDeclension(attemptsAmount, "попытки", "попыток", "попыток"));
                }
            }
        }

        public static string GetDeclension(int number, string nominativ, string genetiv, string plural)
        {
            number = number % 100;
            if (number >= 11 && number <= 19)
            {
                return plural;
            }

            var i = number % 10;
            switch (i)
            {
                case 1:
                    return nominativ;
                case 2:
                case 3:
                case 4:
                    return genetiv;
                default:
                    return plural;
            }
        }
    }
}
