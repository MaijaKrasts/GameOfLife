namespace GameOfLife
{
    public class Field
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public bool[,] Cells { get; set; }
    }
}
