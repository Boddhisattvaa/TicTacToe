using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class TicTacToe
    {
        char[,] array = new char[3, 3]
        {
            { '*','*','*'},
            { '*','*','*'},
            { '*','*','*'}
        };
        private void TicTacToePrint()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        private void TicTacToeTurn(int a, int b)
        {
            if (array[a, b] != 'x' && array[a, b] != '0')
            {
                array[a, b] = 'x';
            }
            else
            {
                Console.WriteLine("Эта ячейка занята");
                Task.Delay(1000).Wait();
                TicTacToeGameHelp();
            }
        }
        public void TicTacToeGameHelp()
        {
            Console.Clear();
            Console.WriteLine("Удачи в игре !!!");
            while (true)
            {
                try
                {
                    Console.WriteLine("Текущее состояние поля: ");
                    TicTacToePrint();
                    Console.WriteLine("Пожалуйста, введите индекс ячейки, в которую вы хотите поставить крестик: ");
                    Console.Write('>');
                    string input = Console.ReadLine();
                    input = input.ToLower().Trim();
                    int numOne = 0;
                    int numTwo = 0;
                    string[] inputSymbols = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < inputSymbols.Length; j++)
                    {
                        bool check = int.TryParse(inputSymbols[j], out int number);
                        if (check == true)
                        {
                            if (j == 0)
                            {
                                numOne = number - 1;
                            }
                            else if (j == 1)
                            {
                                numTwo = number - 1;
                            }
                        }
                    }
                    Console.Clear();
                    if (input == "help" || input == "h")
                    {
                        Console.Clear();
                        Console.WriteLine("При старте игры отображается игровое поле размером 3х3. " +
                           "У ячейки есть 3 состояние - крестик (отображается, как “x”), нолик (отображается как “0”) и свободная (отображается как “*”). " +
                           "Вы всегда стартуете первым и всегда ходите “крестиками”. Вам нужно ввести индекс ячейки, в которую хотите поставить крестик.");
                        Console.WriteLine(new string('*', Console.WindowWidth));
                        Console.WriteLine("Нажмите на любую клавишу!!!");
                        Console.ReadKey();
                    }
                    else if (input == "quit" || input == "q")
                    {
                        Console.Clear();
                        Console.WriteLine("Bye!!!");
                        Environment.Exit(0);
                    }
                    TicTacToeTurn(numOne, numTwo);
                    CheckWinner();
                    ChooseCellAI();
                    CheckWinner();
                }
                catch (Exception exception)
                {
                    Console.Clear();
                    Console.WriteLine("Попробуй снова");
                }
            }
        }
        private void ChooseCellAI()
        {
            Random random = new Random();
            Console.WriteLine("Искуственный интеллект думает...");
            Task.Delay(random.Next(500, 2001)).Wait();
            Console.Clear();
            while (true)
            {
                int numberOne = random.Next(0, 3);
                int numberTwo = random.Next(0, 3);
                if (array[numberOne, numberTwo] != 'x' && array[numberOne, numberTwo] != '0')
                {
                    Console.WriteLine($"Искуственный интеллект выбирает индекс ячейки {numberOne + 1} {numberTwo + 1}"); ;
                    array[numberOne, numberTwo] = '0';
                    break;
                }
            }
        }
        private void EndGameBehavior()
        {
            TicTacToePrint();
            Console.WriteLine("Нажмите на любую клавишу чтобы вернуться в главное меню");
            Console.ReadKey();
            Console.Clear();
            Menu.PrintMenu();
        }
        private void CheckWinner()
        {
            if ((array[0, 0] == 'x' && array[0, 1] == 'x' && array[0, 2] == 'x')
                || (array[1, 0] == 'x' && array[1, 1] == 'x' && array[1, 2] == 'x')
                || (array[2, 0] == 'x' && array[2, 1] == 'x' && array[2, 2] == 'x')
                || (array[0, 0] == 'x' && array[1, 0] == 'x' && array[2, 0] == 'x')
                || (array[0, 1] == 'x' && array[1, 1] == 'x' && array[2, 1] == 'x')
                || (array[0, 2] == 'x' && array[1, 2] == 'x' && array[2, 2] == 'x')
                || (array[0, 0] == 'x' && array[1, 1] == 'x' && array[2, 2] == 'x')
                || (array[0, 2] == 'x' && array[1, 1] == 'x' && array[2, 0] == 'x'))
            {
                Console.WriteLine("Вы победили !!!");
                EndGameBehavior();
            }

            else if (array[0, 0] == '0' && array[0, 1] == '0' && array[0, 2] == '0' ||
                (array[1, 0] == '0' && array[1, 1] == '0' && array[1, 2] == '0')
                || (array[2, 0] == '0' && array[2, 1] == '0' && array[2, 2] == '0')
                || (array[0, 0] == '0' && array[1, 0] == '0' && array[2, 0] == '0')
                || (array[0, 1] == '0' && array[1, 1] == '0' && array[2, 1] == '0')
                || (array[0, 2] == '0' && array[1, 2] == '0' && array[2, 2] == '0')
                || (array[0, 0] == '0' && array[1, 1] == '0' && array[2, 2] == '0')
                || (array[0, 2] == '0' && array[1, 1] == '0' && array[2, 0] == '0'))
            {
                Console.WriteLine("Вы проиграли !!!");
                EndGameBehavior();
            }
            else
            {
                if (array[0, 0] != '*' && array[0, 1] != '*' && array[0, 2] != '*' && array[1, 0] != '*' && array[1, 1] != '*' && array[1, 2] != '*' && array[2, 0] != '*' && array[2, 1] != '*' && array[2, 2] != '*')
                {
                    Console.WriteLine("Ничья !!!");
                    EndGameBehavior();
                }
            }
        }
    }
}
