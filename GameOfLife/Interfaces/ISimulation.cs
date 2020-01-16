namespace GameOfLife.Interfaces
{
    using System.Collections.Generic;
    using GameOfLife.Models;

    public interface ISimulation
    {
        Field StartNewGen(Field field);

        Field Grow(Field field, List<Cell> cells);

        bool ChangeLifeStatuss(int aliveneighbors, int currentRow, int currentColumn, Field field);

        void FindNeighbors(List<Cell> cells, Field field);

        int GetNeighbors(int cellRow, int cellColumn, Field field);
    }
}
