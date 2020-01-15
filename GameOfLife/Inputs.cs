namespace GameOfLife
{
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class Inputs : IInputs
    {
        private string inputHeight;
        private string inputWidth;

        private Field field;
        private IValidatior validation;
        private IFileWorker fileWorker;
        private IConsoleFacade facade;
        private ITexts texts;

        public Inputs()
        {
            facade = new ConsoleFacade();
            field = new Field();
            fileWorker = new FileWorker();
            validation = new Validatior();
            texts = new Texts();
        }

        public Field GetUserInput()
        {
            facade.WriteLine(texts.Intro());
            facade.WriteLine();
            facade.WriteLine(texts.StartFromSaved());
            var answ = facade.ReadLine().ToLower();

            if (validation.ValidateQuestion(answ))
            {
                field = fileWorker.Load();
                return field;
            }
            else if (!validation.ValidateQuestion(answ))
            {
                facade.WriteLine(texts.Param());
                facade.WriteLine(texts.Height());
                inputHeight = facade.ReadLine();
                facade.WriteLine(texts.Width());
                inputWidth = facade.ReadLine();

                var validH = validation.ValidateInt(inputHeight);
                var validW = validation.ValidateInt(inputWidth);

                if (validH && validW)
                {
                    field = CreateInputField(inputHeight, inputWidth);
                    return field;
                }
                else
                {
                    facade.WriteLine(texts.Error());
                    GetUserInput();
                    return field;
                }
            }
            return field;
        }

        public Field CreateInputField(string inputHeight, string inputWidth)
        {
            Field field = new Field();

            int height = int.Parse(inputHeight);
            int width = int.Parse(inputWidth);

            field.Height = height;
            field.Width = width;
            field.Cells = new bool[height, width];
            facade.Clear();
            return field;

        }
    }
}
