namespace GameOfLife
{
    using System;
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

        public GameLoop()
        {
            display = new Display();
            facade = new ConsoleFacade();
            field = new Field();
            fieldAlterations = new FieldAlterations();
            file = new FileWorker();
            simulation = new Simulation();
            userInputs = new Inputs();
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
                        facade.WriteLine("You have paused the game? Click X if you want to exit the game; click S if you want to save it!");
                        var answ = facade.ReadLine().ToLower();
                        if (answ == "s")
                        {
                            file.Save(field);
                            facade.WriteLine("saved");
                            break;
                        }
                        else if (answ == "x")
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
