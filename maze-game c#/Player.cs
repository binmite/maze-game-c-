namespace maze_game_c_
{
    internal class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private int StartX { get; }
        private int StartY { get; }
        public bool IsAlive { get; set; }
        public bool HasWon { get; set; }

        public Player(int startX, int startY)
        {
            StartX = startX;
            StartY = startY;
            this.X = StartX;
            this.Y = StartY;
            IsAlive = true;
            HasWon = false;
        }

        public static (int X, int Y) FindStartPosition(char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == '@')
                    {
                        return (j, i);
                    }
                }
            }

            return (-1, -1);
        }

        public void Move(int deltaX, int deltaY)
        {
            int newX = X + deltaX;
            int newY = Y + deltaY;

            if (newY >= 0 && newY < Map.Grid.GetLength(0) && newX >= 0 && newX < Map.Grid.GetLength(1))
            {
                if (Map.Grid[newY, newX] == '·')
                {
                    Map.Grid[newY, newX] = '*';
                    Map.Grid[Y, X] = '·';

                    X = newX;
                    Y = newY;
                }
                else if (Map.Grid[newY, newX] == 'M')
                {
                    Monster monster = Map.Monsters.Find(m => m.X == newX && m.Y == newY);

                    if (monster != null && !monster.IsDefeated)
                    {
                        Console.Clear();
                        Console.ResetColor();
                        Console.WriteLine(monster.CurrentQuestion);

                        int answer;
                        while (true)
                        {
                            string input = Console.ReadLine()!;

                            if (int.TryParse(input, out answer))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a number!");
                            }
                        }

                        if (monster.CheckAnswer(answer))
                        {
                            Console.ResetColor();
                            Console.WriteLine("Victory!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                            Console.Clear();
                            Map.Monsters.Remove(monster);
                            Map.Grid[newY, newX] = '·';

                            Map.Grid[newY, newX] = '*';
                            Map.Grid[Y, X] = '·';
                            X = newX;
                            Y = newY;
                        }
                        else
                        {
                            IsAlive = false;
                            Console.ResetColor();
                            Console.WriteLine("Defeat");
                            Console.WriteLine("Press any key to return to start...");
                            Console.ReadKey(true);
                        }
                    }
                }
                else if (Map.Grid[newY, newX] == 'E')
                {
                    HasWon = true;

                    Map.Grid[newY, newX] = '*';
                    Map.Grid[Y, X] = '·';

                    X = newX;
                    Y = newY;
                }
            }
        }
    }
}
