namespace GameOfLife.Models
{

    public class NeighborCell
    {
        public int CellNeighborRow { get; set; }

        public int CellNeighborColumn { get; set; }
        
        public int CellRow { get; set; }
        
        public int CellColumn { get; set; }
        
        public int AliveNeighbors { get; set; }
    }
}