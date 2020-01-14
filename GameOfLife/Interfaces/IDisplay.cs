namespace GameOfLife.Interfaces
{
    public interface IDisplay
    {
        void DrawGame(Field field);

        int AddLiveCells();

        void WriteProperties(int numOfIterations);
    }
}
