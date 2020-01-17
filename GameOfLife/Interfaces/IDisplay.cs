namespace GameOfLife.Interfaces
{
    using System.Collections.Generic;

    public interface IDisplay
    {
        void DrawGame(Field field);

        int AddLiveCells();

        void WriteProperties(int numOfIterations);

        void DrawMultipleGames(List<Field> fieldList);

        void WritePropertiesForMultiple(int numOfIterations, int games);
    }
}
