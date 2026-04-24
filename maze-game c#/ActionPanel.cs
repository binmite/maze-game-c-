using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game_c_
{
    internal class ActionPanel
    {
        public static void Greetings()
        {
            Console.Clear();

            Console.WriteLine("Maze-Game by @binmite");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void SelectDifficulty()
        {
            Console.WriteLine("Select difficulty:");

            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
        }

        public static void VictoryScreen()
        {
            Console.Clear();
            Console.WriteLine("Congratulations!!!");
            Console.WriteLine("Press any key to return to title screen...");
            Console.ReadKey(true);
        }

        public static void MoveCycle(int difficulty)
        {
            char[,] grid = Map.LoadMap(difficulty);

            (int startX, int startY) = Player.FindStartPosition(grid);

            Player player = new Player(startX, startY);

            int deltaX = 0;
            int deltaY = 0;

            while (player.IsAlive && !player.HasWon)
            {
                Console.SetCursorPosition(0, 0);
                Map.MapRendering(Map.Grid);

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    deltaX = 0;
                    deltaY = -1;
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    deltaX = 0;
                    deltaY = 1;
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    deltaX = 1;
                    deltaY = 0;
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    deltaX = -1;
                    deltaY = 0;
                }

                player.Move(deltaX, deltaY);

                if (player.HasWon == true)
                {
                    VictoryScreen();
                    break;
                }
            }
        }

        public static void GameCycle()
        {
            Greetings();

            while (true)
            {
                Console.Clear();
                SelectDifficulty();

                switch (Choice(1, 3))
                {
                    case 1:
                        Console.Clear();
                        MoveCycle(1);
                        break;
                    case 2:
                        Console.Clear();
                        Map.MapRendering(Map.LoadMap(2));
                        MoveCycle(2);
                        break;
                    case 3:
                        Console.Clear();
                        MoveCycle(3);
                        break;
                }
            }
        }

        public static int Choice(int min, int max)
        {
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
            {
                Console.WriteLine($"Please enter a number from {min} to {max}:");
            }

            return choice;
        }
    }
}
