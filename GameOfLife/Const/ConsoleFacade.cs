namespace GameOfLife
{
    using System;
    using GameOfLife.Interfaces;

    public class ConsoleFacade : IConsoleFacade
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public string ReadLine()
        {
           var text = Console.ReadLine();
           return text;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
