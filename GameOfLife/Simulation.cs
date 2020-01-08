using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Simulation
    {
        private int Heigth;
        private int Width;
        private bool[,] cells;
        private int NumOfIterations = 0;
        private int NumOfAliveCells = 0;

        public Simulation(int Heigth, int Width)
        {
            this.Heigth = Heigth;
            this.Width = Width;
            cells = new bool[Heigth, Width];
            GenerateField();
        }

        public void GenerateField()
        {
            Random generator = new Random();
            int number;

            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                }
            }
        }

        public void DrawAndGrow()
        {
            Console.WriteLine("Number of iterations: {0}", NumOfIterations);   
            Console.WriteLine("Number of live cells: {0}", NumOfAliveCells);
            DrawGame();
            Grow();
            NumOfIterations++;
        }

        public void DrawGame()
        {
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(cells[i, j] ? "1" : " ");
                    if (j == Width - 1) Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        public void Grow()
        {
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (cells[i, j])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            cells[i, j] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            cells[i, j] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            cells[i, j] = true;
                        }
                    }

                    
                }
            }
        }

        public int GetNeighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= Heigth || j >= Width)))
                    {
                        if (!((i == x) && (j == y)))
                        {
                            if (cells[i, j] == true) NumOfAliveNeighbors++;
                        }
                    }
                }
            }
            return NumOfAliveNeighbors;
        }
    }
}