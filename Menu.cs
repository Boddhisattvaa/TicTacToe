using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public static class Menu
    {
        public static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Добро пожаловать в игру Крестики нолики. Доступные команды: ");
            Console.WriteLine("'start’ (or ‘s’) - Начать игру");
            Console.WriteLine("'help’ (or ‘h’) - Помощь");
            Console.WriteLine("'quit’ (or ‘q’) - Выйти");
            while (true)
            {
                Console.Write(">");
                Console.CursorVisible = false;
                string menuInput = Console.ReadLine();
                menuInput = menuInput.Trim().ToLower();
                if (menuInput == "start" || menuInput == "s")
                {
                    TicTacToe ticTacToe = new TicTacToe();
                    ticTacToe.TicTacToeGameHelp();
                }
                else if (menuInput == "help" || menuInput == "h")
                {
                    Console.Clear();
                    Console.WriteLine("При старте игры отображается игровое поле размером 3х3. " +
                       "У ячейки есть 3 состояние - крестик (отображается, как “x”), нолик (отображается как “0”) и свободная (отображается как “*”). " +
                       "Вы всегда стартуете первым и всегда ходите “крестиками”. Вам нужно ввести индекс ячейки, в которую хотите поставить крестик.");
                    Console.WriteLine(new string('*', Console.WindowWidth));
                    Console.WriteLine("Введите следующую команду!!!");
                }
                else if (menuInput == "quit" || menuInput == "q")
                {
                    Console.Clear();
                    Console.WriteLine("Bye!!!");
                    Environment.Exit(0);
                }
            }
        }

    }
}











