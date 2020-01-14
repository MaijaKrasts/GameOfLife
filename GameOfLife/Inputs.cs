namespace GameOfLife
{

    using GameOfLife.Interfaces;

    public class Inputs : ISetup
    {
        private string inputHeight;
        private string inputWidth;

        private Field field;
        private Validations validation;
        private ProjFile file;
        private ConsoleFacade facade;

        public Inputs()
        {
            facade = new ConsoleFacade();
            field = new Field();
            file = new ProjFile();
            validation = new Validations();
        }

        public Field GetUserInput()
        {
            facade.WriteLine("Welcome to the Game of Life!");
            facade.WriteLine();

            facade.WriteLine("Do you want to start from saved game? y/n");
            var answ = facade.ReadLine().ToLower();

            if (validation.ValidateQuestion(answ))
            {
                field = file.ReadInformation(field);
            }
            else if (!validation.ValidateQuestion(answ))
            {
                facade.WriteLine("Add the parameters to create game field:");

                facade.WriteLine("Number of rows (height):");
                inputHeight = facade.ReadLine();

                facade.WriteLine("Number of columns (width):");
                inputWidth = facade.ReadLine();

                file.SaveInformation(inputHeight, inputWidth);
                field = validation.VertifyInput(inputHeight, inputWidth, field);
            }

            return field;
        }
    }
}
