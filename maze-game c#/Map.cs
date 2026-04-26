namespace maze_game_c_
{
    internal class Map
    {
        const string EasyMapPath = @"maps\easy.txt";
        const string MediumMapPath = @"maps\medium.txt";
        const string HardMapPath = @"maps\hard.txt";

        public static char[,] Grid { get; private set; }

        public static List<Monster> Monsters = new List<Monster>();

        public static string GetMapPath(int difficulty)
        {
            return difficulty switch
            {
                1 => (EasyMapPath),
                2 => (MediumMapPath),
                3 => (HardMapPath),
                _ => throw new ArgumentException("Invalid difficulty level")
            };
        }

        public static char[,] ConvertToGrid(string[] oneDmArray, int rows, int cols)
        {
            char[,] twoDmArray = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    twoDmArray[i, j] = oneDmArray[i][j];
                }
            }

            return twoDmArray;
        }

        public static char[,] LoadMap(int difficulty)
        {
            string mapPath = GetMapPath(difficulty);
            string[] fileContent = File.ReadAllLines(mapPath);

            int rows = fileContent.Length;
            int cols = fileContent[0].Length;

            char[,] loadedMap = ConvertToGrid(fileContent, rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (loadedMap[i, j] == 'M')
                    {
                        Monster monster = new Monster(j, i, difficulty);
                        Monsters.Add(monster);
                    }
                }
            }

            Grid = loadedMap;
            return loadedMap;
        }

        public static void MapRendering(char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 'x')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }

                    else if (grid[i, j] == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    else if (grid[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    else if (grid[i, j] == 'E')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    else if (grid[i, j] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    else if (grid[i, j] == '·')
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
