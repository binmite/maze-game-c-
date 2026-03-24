namespace maze_game_c_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static void Greetings()
        {
            Console.WriteLine("Maze-Game by @binmite");
            Console.WriteLine("Press any key to start...");
        }

        public static void SelectDifficulty()
        {
            Console.WriteLine("Select difficulty:");

            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
        }
    }
}
