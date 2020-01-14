namespace GameOfLife.Interfaces
{
    using System.Collections.Generic;
    using GameOfLife.Models;

    public interface ISimulation
    {
        List<Cell> StartNewGen(Field field);

        void Grow(Field field, List<Cell> cells);

        bool ChangeLifeStatuss(int aliveneighbors, int currentRow, int currentColumn, Field field);

        void FindNeighbors(List<Cell> cells, Field field);

        int GetNeighbors(int cellRow, int cellColumn, Field field);
    }
}
