namespace GameOfLife.Interfaces
{
    public interface ITexts
    {
        public string Symbol();

        public string Empthy();

        public string Return();

        public string LiveCells();

        public string Interations();

        public string Intro();

        public string StartFromSaved();

        public string Param();

        public string Height();

        public string Width();

        public string Error();

        public string Pause();

        public bool True(string text);

        public bool False(string text);

        public string Approval();

        public string DeserializationException();

        public string SerializationException();
    }
}
