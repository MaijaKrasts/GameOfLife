namespace GameOfLife.Const
{
    using GameOfLife.Interfaces;

    public class Texts : ITexts
    {
        public string Symbol()
        {
            return "#";
        }

        public string Empthy()
        {
            return " ";
        }

        public string Return()
        {
            return "\r";
        }

        public string LiveCells()
        {
            return "Number of iterations: {0}";
        }

        public string Interations()
        {
            return "Number of live cells: {0}";
        }

        public string Intro()
        {
            return "Welcome to the Game of Life!";
        }

        public string StartFromSaved()
        {
            return "Do you want to start from saved game? 1 (yes) / 2 (no)";
        }

        public string Param()
        {
            return "Add the parameters to create game field:";
        }

        public string Height()
        {
            return "Number of rows (height):";
        }

        public string Width()
        {
            return "Number of columns (width):";
        }

        public string Error()
        {
            return "Height or width parameters were not right. Try again!";
        }

        public string Pause()
        {
            return "You have paused the game? Click 1 if you want to EXIT the game; click 2 if you want to SAVE it!";
        }

        public bool True(string text)
        {
            return text == "1" || text == "y" || text == "yes";
        }

        public bool False (string text)
        {
            return text == "2" || text == "n" || text == "no";
        }

        public string Approval()
        {
            return "Game saved!";
        }

        public string DeserializationException()
        {
            return "Failed to deserialize. Reason: ";
        }

        public string SerializationException()
        {
            return "Failed to serialize. Reason: ";
        }

    }
}
