﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Models
{
    public class Cell
    {
        public int CellRow { get; set; }

        public int CellColumn { get; set; }

        public int AliveNeighbors { get; set; }

    }
}
