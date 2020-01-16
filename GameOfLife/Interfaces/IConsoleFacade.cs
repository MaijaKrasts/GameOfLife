namespace GameOfLife.Interfaces
{
    public interface IConsoleFacade
    {
        public void Write(string text);

        public void WriteLine(string text);

        public void WriteLine();

        public string ReadLine();

        public void Clear();

        public void Exception(string text, string message);

        public void Count(string text, int num);
    }
}
