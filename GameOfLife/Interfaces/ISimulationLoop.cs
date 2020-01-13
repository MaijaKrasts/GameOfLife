namespace GameOfLife.Interfaces
{
    using System.Collections.Generic;
    using GameOfLife.Models;

    internal interface ISimulationLoop
    {
        List<Cell> FillCellList(Field field);

        void Grow(Field field, List<Cell> cells);

        bool ChangeLifeStatuss(int aliveneighbors, int currentRow, int currentColumn, Field field);

    }
}
