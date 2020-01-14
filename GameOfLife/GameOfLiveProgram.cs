namespace GameOfLife
{
    using System;
    using System.Threading;

    public class GameOfLiveProgram
    {
        public static void Main(string[] args)
        {
            GameLoop play = new GameLoop();
            play.Loop();

            Console.Read();
        }
    }
}
