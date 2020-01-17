namespace GameOfLife.Const
{
    public class Texts
    {
        public const string Symbol = "#";
        public const string Empthy = " ";
        public const string Return = "\r";
        public const string LiveCells = "Number of live cells: {0}";
        public const string Interations = "Number of iterations: {0}";
        public const string Games = "Number of games: {0}";
        public const string Intro = "Welcome to the Game of Life!";
        public const string StartFromSaved = "Do you want to start from saved game? 1 (yes) / 2 (no)";
        public const string Param = "Add the parameters to create game field:";
        public const string Height = "Number of rows (height):";
        public const string Width = "Number of columns (width):";
        public const string Error = "Height or width parameters were not right. Try again!";
        public const string Pause = "You have paused the game. Click 1 if you want to SAVE it! Click 2 if you want to EXIT the game; ";
        public const string Approval = "Game saved!";
        public const string DeserializationException = "Failed to deserialize. Reason: ";
        public const string SerializationException = "Failed to serialize. Reason: ";

        public bool True(string text)
        {
            return text == "1" || text == "y" || text == "yes";
        }

        public bool False (string text)
        {
            return text == "2" || text == "n" || text == "no";
        }
    }
}
