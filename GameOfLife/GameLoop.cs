namespace GameOfLife
{
    using System;
    using System.Threading.Tasks;
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class GameLoop : IGameLoop
    {
        private int numOfIterations = 2;

        private Display display;
        private IConsoleFacade facade;
        private IFieldAlterations fieldAlterations;
        private Field field;
        private IFileWorker file;
        private ISimulation simulation;
        private IInputs userInputs;
        private Texts texts;

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
                        facade.WriteLine(Texts.Pause);
                        var answ = facade.ReadLine().ToLower();
                        if (texts.True(answ))
                        {
                            file.Save(field);
                            facade.WriteLine(Texts.Approval);
                            continue;
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

        public void ParallelLoop()
        {
            var fieldList = fieldAlterations.GetFieldList();
            facade.Clear();
            display.DrawMultipleGames(fieldList);
            display.Sleep();

            while (true)
            {
                int games = 0;

                Parallel.For(1, 1000, i =>
                {
                    simulation.StartNewGen(fieldList[i]);
                    Console.SetCursorPosition(0, 0);
                    games++;
                });

                display.DrawMultipleGames(fieldList);
                display.Sleep();
                display.WritePropertiesForMultiple(numOfIterations, games);
                numOfIterations++;

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.P)
                    {
                        facade.WriteLine(Texts.Pause);
                        var answ = facade.ReadLine().ToLower();
                        if (texts.True(answ))
                        { 
                            file.SaveMultiple(fieldList);
                            facade.WriteLine(Texts.Approval);
                            continue;
                        }
                        facade.WriteLine(Texts.Pause);
                        Console.ReadLine();
                        facade.Clear();
                    }
                }
            }
        }
    }
}