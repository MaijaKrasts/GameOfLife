namespace GameOfLife
{
    using System.IO;
    using GameOfLife.Interfaces;

    public class ProjFile : IFile
    {
        private Validations validation;
        private ConsoleFacade facade;

        public ProjFile()
        {
            validation = new Validations();
            facade = new ConsoleFacade();
        }

        public Field ReadInformation(Field field)
        {
            var path = Configurations.PATH;
            string savedInput = File.ReadAllText(path);

            string[] substrings = savedInput.Split(',');
            string inputHeight = substrings[0];
            string inputWidth = substrings[1];

            field = validation.VertifyInput(inputHeight, inputWidth, field);

            return field;
        }

        public void SaveInformation(string inputHeight, string inputWidth)
        {
            facade.WriteLine("Do you want to save information to a file? y/n");
            var saveInput = facade.ReadLine().ToLower();

            if (validation.ValidateQuestion(saveInput))
            {
                string input = inputHeight + "," + inputWidth;

                var path = Configurations.PATH;
                File.WriteAllText(path, input);
            }
        }
    }
}
