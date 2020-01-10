namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameOfLife.Models;

    internal class SimulationLoop
    {
        private int numOfIterations = 1;
        private int numOfLiveCells = 0;
        public List<Cell> cells { get; set; }

        //public void DrawAndGrowLoop(Field field, Field liveField)
        //{
        //    while (true)
        //    {
        //        while (!Console.KeyAvailable)
        //        {
        //            this.numOfLiveCells = 0;
        //            Console.Clear();
        //            Console.WriteLine("Number of iterations: {0}", this.numOfIterations);
        //            if (this.numOfIterations > 1)
        //            {
        //                field = liveField;
        //            }

        //            this.DrawGame(field);
        //            //this.Grow(field);
        //            Console.WriteLine("Number of live cells: {0}", this.numOfLiveCells);
        //            this.numOfIterations++;
        //            Console.SetCursorPosition(0, Console.WindowTop);
        //            System.Threading.Thread.Sleep(4000);
        //        }

        //        Console.Clear();
        //        Console.WriteLine("Game stoped!");
        //        break;
        //    }
        //}
        public void DrawFieldLoop(Field field)
        {
            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    this.numOfLiveCells = 0;
                    Console.Clear();
                    Console.WriteLine("Number of iterations: {0}", this.numOfIterations);
                    this.DrawGame(field);
                    FillCellList(field);
                    Console.WriteLine("Number of live cells: {0}", this.numOfLiveCells);
                    this.numOfIterations++;
                    Console.SetCursorPosition(0, Console.WindowTop);
                    System.Threading.Thread.Sleep(1000);

                }

                Console.Clear();
                Console.WriteLine("Game stoped!");
                break;
            }
        }

        private List<Cell> FillCellList(Field field)
        {
            List<Cell> cells = new List<Cell>();

            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    Cell cell = new Cell();

                    cell.AliveNeighbors = 0;
                    cell.CellColumn = currentColumn;
                    cell.CellRow = currentRow;
                    cells.Add(cell);
                }
            }

            FindNeighbors(cells, field);
            return cells;
        }

        public void DrawGame(Field field)
        {
            for (int currentRow = 0; currentRow < field.Height; currentRow++)
            {
                for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
                {
                    var currentCell = field.Cells[currentRow, currentColumn];
                    if (currentCell)
                    {
                        Console.Write("#");
                        this.AddLiveCells();
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    if (currentColumn == field.Width - 1)
                    {
                        Console.WriteLine("\r");
                    }
                }
            }
        }

        public int AddLiveCells()
        {
            return this.numOfLiveCells++;
        }

        private void FindNeighbors(List<Cell> cells, Field field)
        {
            foreach (var cell in cells)
            {
                cell.AliveNeighbors = GetNeighbors(cell.CellRow, cell.CellColumn, field);
            }

            Grow(field, cells);
        }
        public void Grow(Field field, List<Cell> cells)
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

        public bool ChangeLifeStatuss(int aliveneighbors, int currentRow, int currentColumn, Field field)
        {
            if (field.Cells[currentRow, currentColumn])
            {
                if (aliveneighbors < 2 || aliveneighbors > 3)
                {
                    field.Cells[currentRow, currentColumn] = false;
                }

                if (aliveneighbors == 2 || aliveneighbors == 3)
                {
                    field.Cells[currentRow, currentColumn] = true;
                }// TODO refactor

            }
            else
            {
                if (aliveneighbors == 3)
                {
                    field.Cells[currentRow, currentColumn] = true;
                }
            }

            return field.Cells[currentRow, currentColumn];
        }
        //public void Grow(Field field, List<Cell> cells)
        //{
        //    for (int currentRow = 0; currentRow < field.Height; currentRow++)
        //    {
        //        for (int currentColumn = 0; currentColumn < field.Width; currentColumn++)
        //        {
        //            field.Cells[currentRow, currentColumn] = this.LifeStatuss(currentRow, currentColumn, field);
        //        }
        //    }
        //}

        public bool LifeStatuss(int currentRow, int currentColumn, Field field)
        {
            int numOfAliveNeighbors = this.GetNeighbors(currentRow, currentColumn, field);

            if (field.Cells[currentRow, currentColumn])
            {
                if (numOfAliveNeighbors < 2 || numOfAliveNeighbors > 3)
                {
                    field.Cells[currentRow, currentColumn] = false;
                }

                if (numOfAliveNeighbors == 2 || numOfAliveNeighbors == 3)
                {
                    field.Cells[currentRow, currentColumn] = true;
                }// TODO refactor

            }
            else
            {
                if (numOfAliveNeighbors == 3)
                {
                   field.Cells[currentRow, currentColumn] = true;
                }
            }

            return field.Cells[currentRow, currentColumn];
        }

        public int GetNeighbors(int cellRow, int cellColumn, Field field)
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

        public NeighborCell AliveNeighbors(NeighborCell neighbor, Field field)
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
