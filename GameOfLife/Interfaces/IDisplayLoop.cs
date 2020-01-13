namespace GameOfLife.Interfaces
{
    internal interface IDisplayLoop
    {
        void PrintResultsLoop(Field field);

        void DrawGame(Field field);

        void CreateNewGame(Field field);
    }
}
