using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (newX >= 0 && newX < Map.Grid.GetLength(0) && newY >= 0 && newY < Map.Grid.GetLength(1) && Map.Grid[newX, newY] == '-')
            {
                Map.Grid[newX, newY] = '*';
                Map.Grid[X, Y] = '-';

                X = newX;
                Y = newY;
            }

            else if (newX >= 0 && newX < Map.Grid.GetLength(0) && newY >= 0 && newY < Map.Grid.GetLength(1) && Map.Grid[newX, newY] == 'M')
            {
                //Monster.Battle();
                X = newX;
                Y = newY;
            }

            else if (newX >= 0 && newX < Map.Grid.GetLength(0) && newY >= 0 && newY < Map.Grid.GetLength(1) && Map.Grid[newX, newY] == 'E')
            {
                //метод победы
            }

            
        }



    }
}
