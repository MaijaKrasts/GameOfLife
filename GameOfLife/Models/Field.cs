using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class Field
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public bool[,] cells { get; set; }
    }
}
