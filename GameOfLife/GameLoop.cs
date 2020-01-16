namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using GameOfLife.Const;
    using GameOfLife.Interfaces;

    public class GameLoop : IGameLoop
    {
        private int numOfIterations = 1;

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

        public void SimplifiedLoop(Field field)
        {
            var x = 0;
            while (x < 10)
            {
                facade.Clear();
                display.DrawGame(field);
                simulation.StartNewGen(field);
                numOfIterations++;
                display.WriteProperties(numOfIterations);
                x++;
            }
        }

        public void ParallelLoops()
        {
            field = userInputs.GetUserInput();
            field = fieldAlterations.GenerateField(field);

            List<Field> fieldList = new List<Field>();
            var r = 0;

            while (r < 100)
            {
                field = fieldAlterations.GenerateField(field);
                fieldList.Add(field);
                r++;

            }

            Parallel.For(1, 100, i =>
            {
                if (i < 9)
                {
                    //print only 8 games
                    SimplifiedLoop(fieldList[i]);
                }

                else
                {
                    //dont print the rest of 92 games, just execute them
                    simulation.StartNewGen(fieldList[i]);
                }

            });

            //Parallel.ForEach(fieldList, SimplifiedLoop);
        }
    }
}