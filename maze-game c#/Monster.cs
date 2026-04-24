using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game_c_
{
    internal class Monster
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Difficulty { get; set; }
        public string CurrentQuestion { get; set; }
        public int Answer { get; set; }
        public bool IsDefeated { get; set; }

        private static readonly Random _random = new Random();

        public Monster(int x, int y, int difficulty)
        {
            X = x;
            Y = y;
            Difficulty = difficulty;
            IsDefeated = false;
            GenerateQuestion();
        }

        public bool CheckAnswer(int playerAnswer)
        {
            if (playerAnswer == Answer)
            {
                return true;
            }

            return false;
        }

        private void GenerateQuestion()
        {
            if (Difficulty == 1)
            {
                var questions = new List<(string, int)>
                {
                    ("5 + 3 = ?", 8),
                    ("10 - 4 = ?", 6),
                    ("2 * 3 = ?", 6)
                };

                var selected = questions[_random.Next(questions.Count)];
                CurrentQuestion = selected.Item1;
                Answer = selected.Item2;
            }

            else if (Difficulty == 2)
            {
                var questions = new List<(string, int)>
                {
                    ("15 + 27 = ?", 42),
                    ("50 - 18 = ?", 32),
                    ("8 * 7 = ?", 56)
                };

                var selected = questions[_random.Next(questions.Count)];
                CurrentQuestion = selected.Item1;
                Answer = selected.Item2;
            }

            else if (Difficulty == 3)
            {
                var questions = new List<(string, int)>
                {
                    ("25 * 4 - 30 = ?", 70),
                    ("144 / 12 + 7 = ?", 19),
                    ("√169 = ?", 13)
                };

                var selected = questions[_random.Next(questions.Count)];
                CurrentQuestion = selected.Item1;
                Answer = selected.Item2;
            }
        }
    }
}
