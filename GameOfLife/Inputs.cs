namespace GameOfLife
{

    using GameOfLife.Interfaces;

    public class Inputs : IInputs
    {
        private string inputHeight;
        private string inputWidth;

        private Field field;
        private IValidation validation;
        private IFileWorker fileWorker;
        private ConsoleFacade facade;

        public Inputs()
        {
            facade = new ConsoleFacade();
            field = new Field();
            fileWorker = new FileWorker();
            validation = new Validation();
        }

        public Field GetUserInput()
        {
            facade.WriteLine("Welcome to the Game of Life!");
            facade.WriteLine();

            facade.WriteLine("Do you want to start from saved game? y/n");
            var answ = facade.ReadLine().ToLower();

            if (validation.ValidateQuestion(answ))
            {
                field = fileWorker.Load();
            }
            else if (!validation.ValidateQuestion(answ))
            {
                facade.WriteLine("Add the parameters to create game field:");

                facade.WriteLine("Number of rows (height):");
                inputHeight = facade.ReadLine();

                facade.WriteLine("Number of columns (width):");
                inputWidth = facade.ReadLine();

                field = validation.VertifyInput(inputHeight, inputWidth);
            }

            return field;
        }
    }
}
