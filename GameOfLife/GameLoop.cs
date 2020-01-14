namespace GameOfLife
{
    using System;
    using GameOfLife.Interfaces;

    public class GameLoop : IGameLoop
    {
        private int numOfIterations = 1;

        private Display display;
        private ConsoleFacade facade;
        private FieldAlterations fieldAlterations;
        private Field field;
        private Simulation simulation;
        private Inputs userInputs;

        public GameLoop()
        {
            display = new Display();
            facade = new ConsoleFacade();
            field = new Field();
            fieldAlterations = new FieldAlterations();
            simulation = new Simulation();
            userInputs = new Inputs();
        }

        public void Loop()
        {
            field = userInputs.GetUserInput();
            field = fieldAlterations.GenerateField(field);

            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    facade.Clear();

                    display.DrawGame(field);
                    simulation.StartNewGen(field);
                    display.WriteProperties(numOfIterations);
                    numOfIterations++;
                }

                facade.Clear();
                facade.WriteLine("Game stoped!");
                break;
            }
        }
    }
}
