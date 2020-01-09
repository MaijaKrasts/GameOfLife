namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Field
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public bool[,] Cells { get; set; }
    }
}
