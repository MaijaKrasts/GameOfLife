namespace GameOfLife.Interfaces
{
    using System.Collections.Generic;
    using GameOfLife.Models;

    internal interface INeighbors
    {
        void FindNeighbors(List<Cell> cells, Field field);

        int GetNeighbors(int cellRow, int cellColumn, Field field);

        NeighborCell AliveNeighbors(NeighborCell neighbor, Field field);
    }
}
