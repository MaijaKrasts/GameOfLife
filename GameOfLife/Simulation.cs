namespace GameOfLife
{
    using System.Collections.Generic;
    using System.Linq;
    using GameOfLife.Interfaces;
    using GameOfLife.Models;

    public class Simulation : ISimulation
    {
        public Field StartNewGen(Field field)
        {
            List<Cell> cells = new List<Cell>();

            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    Cell cell = new Cell()
                    {
                        AliveNeighbors = 0,
                        CellColumn = currentColumn,
                        CellRow = currentRow,
                    };
                    cells.Add(cell);
                }
            }

            this.FindNeighbors(cells, field);
            return field;
        }

        public Field Grow(Field field, List<Cell> cells)
        {
            int aliveNeighbors = 0;
            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    aliveNeighbors = cells.
                        FirstOrDefault(c => c.CellColumn == currentColumn && c.CellRow == currentRow).AliveNeighbors;
                    field.Cells[currentRow, currentColumn] = ChangeLifeStatuss(aliveNeighbors, currentRow, currentColumn, field);
                }
            }

            return field;
        }

        public bool ChangeLifeStatuss(int aliveneighbors, int currentRow, int currentColumn, Field field)
        {
            var dyingActiveCell = field.Cells[currentRow, currentColumn]
                && (aliveneighbors < 2 || aliveneighbors > 3);

            var stayingAliveCell = field.Cells[currentRow, currentColumn] &&
                (aliveneighbors == 2 || aliveneighbors == 3);

            var newBornCell = !field.Cells[currentRow, currentColumn] &&
                aliveneighbors == 3;

            if (dyingActiveCell)
            {
                field.Cells[currentRow, currentColumn] = false;
            }
            else if (stayingAliveCell)
            {
                field.Cells[currentRow, currentColumn] = true;
            }
            else if (newBornCell)
            {
                field.Cells[currentRow, currentColumn] = true;
            }

            return field.Cells[currentRow, currentColumn];
        }

        public void FindNeighbors(List<Cell> cells, Field field)
        {
            foreach (var cell in cells)
            {
                cell.AliveNeighbors = GetNeighbors(cell.CellRow, cell.CellColumn, field);
            }

            Grow(field, cells);
        }

        public int GetNeighbors(int cellRow, int cellColumn, Field field)
        {
            int numOfAliveNeighbors = 0;

            for (int cellNeighborRow = cellRow - 1; cellNeighborRow < cellRow + 2; cellNeighborRow++)
            {
                for (int cellNeighborColumn = cellColumn - 1; cellNeighborColumn < cellColumn + 2; cellNeighborColumn++)
                {
                     var negativeNeightbor = cellNeighborRow < 0
                     || cellNeighborColumn < 0
                     || cellNeighborRow >= field.Height
                     || cellNeighborColumn >= field.Width;

                     var actualCell = (cellNeighborRow == cellRow)
                        && (cellNeighborColumn == cellColumn);

                     if (!negativeNeightbor)
                    {
                        if (!actualCell)
                        {
                            if (field.Cells[cellNeighborRow, cellNeighborColumn] == true)
                            {
                                numOfAliveNeighbors++;
                            }
                        }
                    }
                }
            }

            return numOfAliveNeighbors;
        }
    }
}
