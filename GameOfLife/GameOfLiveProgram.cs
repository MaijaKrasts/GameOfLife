namespace GameOfLife
{
    using System;

    public class GameOfLiveProgram
    {
        public static void Main(string[] args)
        {
            ////single console version
            GameLoop play = new GameLoop();
            play.Loop();
            //play.Parallellllls();

            Console.Read();


        }
    }
}
