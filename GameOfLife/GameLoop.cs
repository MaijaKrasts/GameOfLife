namespace GameOfLife
{
    using System;
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class GameLoop : IGameLoop
    {
        private int numOfIterations = 1;

        private IDisplay display;
        private IConsoleFacade facade;
        private IFieldAlterations fieldAlterations;
        private Field field;
        private IFileWorker file;
        private ISimulation simulation;
        private IInputs userInputs;
        private ITexts texts;

        public GameLoop()
        {
            display = new Display();
            facade = new ConsoleFacade();
            field = new Field();
            fieldAlterations = new FieldAlterations();
            file = new FileWorker();
            simulation = new Simulation();
            userInputs = new Inputs();
            texts = new Texts();
        }

        public void Loop()
        {
            field = userInputs.GetUserInput();
            field = fieldAlterations.GenerateField(field);

            while (true)
            {
                facade.Clear();
                display.DrawGame(field);
                simulation.StartNewGen(field);
                display.WriteProperties(numOfIterations);
                numOfIterations++;

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.P)
                    {
                        facade.Clear();
                        facade.WriteLine(texts.Pause());
                        var answ = facade.ReadLine().ToLower();
                        if (texts.True(answ))
                        {
                            file.Save(field);
                            facade.WriteLine(texts.Approval());
                            break;
                        }
                        else if (texts.False(answ))
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}
