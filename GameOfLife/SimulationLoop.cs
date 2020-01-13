namespace GameOfLife
{
    using System.Collections.Generic;
    using System.Linq;
    using GameOfLife.Models;

    internal class SimulationLoop
    {
        public List<Cell> FillCellList(Field field)
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
            return cells;
        }

        private void FindNeighbors(List<Cell> cells, Field field)
        {
            foreach (var cell in cells)
            {
                cell.AliveNeighbors = this.GetNeighbors(cell.CellRow, cell.CellColumn, field);
            }

            Grow(field, cells);
        }

        private void Grow(Field field, List<Cell> cells)
        {
            int aliveNeighbors = 0;
            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    aliveNeighbors = cells.FirstOrDefault(c => c.CellColumn == currentColumn && c.CellRow == currentRow).AliveNeighbors;
                    field.Cells[currentRow, currentColumn] = this.ChangeLifeStatuss(aliveNeighbors, currentRow, currentColumn, field);
                }
            }
        }

        private bool ChangeLifeStatuss(int aliveneighbors, int currentRow, int currentColumn, Field field)
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

        private int GetNeighbors(int cellRow, int cellColumn, Field field)
        {
            int numOfAliveNeighbors = 0;

            for (int cellNeighborRow = cellRow - 1; cellNeighborRow < cellRow + 2; cellNeighborRow++)
            {
                for (int cellNeighborColumn = cellColumn - 1; cellNeighborColumn < cellColumn + 2; cellNeighborColumn++)
                {
                    NeighborCell neighbor = new NeighborCell()
                    {
                        CellColumn = cellColumn,
                        CellNeighborColumn = cellNeighborColumn,
                        CellNeighborRow = cellNeighborRow,
                        CellRow = cellRow,
                        AliveNeighbors = numOfAliveNeighbors,
                    };

                    this.AliveNeighbors(neighbor, field);
                    numOfAliveNeighbors = neighbor.AliveNeighbors;
                }
            }

            return numOfAliveNeighbors;
        }

        private NeighborCell AliveNeighbors(NeighborCell neighbor, Field field)
        {
            var negativeNeightbor = neighbor.CellNeighborRow < 0
             || neighbor.CellNeighborColumn < 0
             || neighbor.CellNeighborRow >= field.Height
             || neighbor.CellNeighborColumn >= field.Width;

            var actualCell = (neighbor.CellNeighborRow == neighbor.CellRow)
                && (neighbor.CellNeighborColumn == neighbor.CellColumn);

            if (!negativeNeightbor)
            {
                if (!actualCell)
                {
                    if (field.Cells[neighbor.CellNeighborRow, neighbor.CellNeighborColumn] == true)
                    {
                        neighbor.AliveNeighbors++;
                    }
                }
            }

            return neighbor;
        }
    }
}
