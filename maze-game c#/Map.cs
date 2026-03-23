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

        public static char[,] grid; //придумать как это использовать
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
            char[,] loadedMap;

            if (difficulty == 1)
            {
                string[] fileContent = File.ReadAllLines(EasyMapPath);

                loadedMap = OneDimensionToTwoDimension(difficulty, fileContent);
            }

            else if (difficulty == 2)
            {
                string[] fileContent = File.ReadAllLines(MediumMapPath);

                loadedMap = OneDimensionToTwoDimension(difficulty, fileContent);
            }

            else if (difficulty == 3)
            {
                string[] fileContent = File.ReadAllLines(HardMapPath);

                loadedMap = OneDimensionToTwoDimension(difficulty, fileContent);
            }

            else
            {
                throw new ArgumentException("Неверный уровень сложности");
            }

            grid = loadedMap;
            return loadedMap;

        }

        public static void MapRendering(int difficulty)
        {
            grid = LoadMap(difficulty);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
