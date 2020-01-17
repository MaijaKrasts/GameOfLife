namespace GameOfLife
{
    using System;

    public class GameOfLiveProgram
    {
        public static void Main(string[] args)
        {
            GameLoop play = new GameLoop();
            play.ParallelLoop();

            Console.Read();


        }
    }
}
