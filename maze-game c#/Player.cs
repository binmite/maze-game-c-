using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game_c_
{
    internal class Player
    {
        private int x;
        private int y;
        private int startX;
        private int startY;
        public bool IsAlive { get; set; }
        public bool HasWon { get; set; }

        public Player(int startX, int startY)
        {
            this.startX = startX;
            this.startY = startY;
            this.x = startX;
            this.y = startY;
            IsAlive = true;
            HasWon = false;
        }

        public static char[,] Spawn(char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == '@')
                    {
                        grid[i, j] = '*';
                    }
                }
            }

            return grid;
        }

        public static (int X, int Y) GetPlayerPosition(char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == '*')
                    {
                        return (j, i);
                    }
                }
            }

            return (-1, -1);
        }

        public void Move(int deltaX, int deltaY)
        {
            int newX = x + deltaX;
            int newY = y + deltaY;

            
                
        }

    }
}
