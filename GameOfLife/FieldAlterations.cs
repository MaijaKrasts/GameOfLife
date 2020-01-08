using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class FieldAlterations
    {
        private int Heigth;
        private int Width;
        private bool[,] cells;

        public FieldAlterations(int Heigth, int Width)
        {
            this.Heigth = Heigth;
            this.Width = Width;
            cells = new bool[Heigth, Width];
        }

        
    }
}
