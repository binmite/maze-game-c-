using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game_c_
{
    internal class Map
    {
        const string EasyMapPath = @"maps\easy.txt";
        const string MediumMapPath = @"maps\medium.txt";
        const string HardMapPath = @"maps\hard.txt";

        public static char[,] grid;
        public static int mapRowsEasy = 15;
        public static int mapColsEasy = 21;
        public static int mapRowsMedium = 21;
        public static int mapColsMedium = 20;
        public static int mapRowsHard = 23;
        public static int mapColsHard = 25;


        public static char[,] OneDimensionToTwoDimension(int difficulty, string[] oneDmArray)
        {
            if (difficulty == 1)
            {
                char[,] twoDmArray = new char[mapRowsEasy, mapColsEasy];

                for (int i = 0; i < mapRowsEasy; i++)
                {
                    for (int j = 0; j < mapColsEasy; j++)
                    {
                        twoDmArray[i, j] = oneDmArray[i][j];
                    }
                }

                return twoDmArray;
            }

            else if (difficulty == 2)
            {
                char[,] twoDmArray = new char[mapRowsMedium, mapColsMedium];

                for (int i = 0; i < mapRowsMedium; i++)
                {
                    for (int j = 0; j < mapColsMedium; j++)
                    {
                        twoDmArray[i, j] = oneDmArray[i][j];
                    }
                }

                return twoDmArray;
            }

            else if (difficulty == 3) 
            {
                char[,] twoDmArray = new char[mapRowsHard, mapColsHard];

                for (int i = 0; i < mapRowsHard; i++)
                {
                    for (int j = 0; j < mapColsHard; j++)
                    {
                        twoDmArray[i, j] = oneDmArray[i][j];
                    }
                }

                return twoDmArray;
            }

            else
            {
                throw new ArgumentException("Неверный уровень сложности");
            }
        }

        public static char[,] LoadMap(int difficulty)
        {
            if (difficulty == 1)
            {
                string[] fileContent = File.ReadAllLines(EasyMapPath);

                return OneDimensionToTwoDimension(difficulty, fileContent);
            }

            else if (difficulty == 2)
            {
                string[] fileContent = File.ReadAllLines(MediumMapPath);

                return OneDimensionToTwoDimension(difficulty, fileContent);
            }

            else if (difficulty == 3)
            {
                string[] fileContent = File.ReadAllLines(HardMapPath);

                return OneDimensionToTwoDimension(difficulty, fileContent);
            }

            else
            {
                throw new ArgumentException("Неверный уровень сложности");
            }
        }

        public static void MapRendering(int difficulty)
        {
            char[,] map;

            if (difficulty == 1)
            {
                map = LoadMap(difficulty);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }

                    Console.WriteLine();
                }
            }

            else if (difficulty == 2)
            {
                map = LoadMap(difficulty);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }

                    Console.WriteLine();
                }
            }

            else if (difficulty == 3)
            {
                map = LoadMap(difficulty);
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
