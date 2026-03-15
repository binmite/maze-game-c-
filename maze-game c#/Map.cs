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
        const string EasyMapPath = "easy.txt";
        const string MediumMapPath = "medium.txt";
        const string HardMapPath = "hard.txt";

        static string LoadMap(int difficulty, string filePath)
        {
            if (File.Exists(GetMapPath(difficulty)))
            {
                return File.ReadAllText(filePath);
            }

            return "Карта не найдена.";
        }

        public static string GetMapPath(int difficulty)
        {
            if (difficulty == 1)
            {
                return EasyMapPath;
            }

            else if (difficulty == 2) 
            {
                return MediumMapPath;
            }

            else if (difficulty == 3)
            {
                return HardMapPath;
            }

            else
            {
                return null;
            }
        }

        async public static Task MapRendering(int difficulty)
        {
            if (difficulty == 1)
            {
                using (StreamReader reader = new StreamReader(GetMapPath(difficulty)))
                {
                    string text = await reader.ReadToEndAsync();
                    Console.WriteLine(text);
                }
            }

            else if (difficulty == 2) 
            {
                using (StreamReader reader = new StreamReader(GetMapPath(difficulty)))
                {
                    string text = await reader.ReadToEndAsync();
                    Console.WriteLine(text);
                }
            }

            else if (difficulty == 3)
            {
                using (StreamReader reader = new StreamReader(GetMapPath(difficulty)))
                {
                    string text = await reader.ReadToEndAsync();
                    Console.WriteLine(text);
                }
            }
        }
    }
}
