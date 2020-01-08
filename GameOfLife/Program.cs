using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Game of Life!");
            Console.WriteLine();
            Console.WriteLine("Add the parameters to create game field:");
            Console.WriteLine("Number of rows (height):");
            int Heigth = int.Parse(Console.ReadLine());

            Console.WriteLine("Number of columns (width):");

            int Width = int.Parse(Console.ReadLine());

            Console.Clear();

            Simulation sim = new Simulation(Heigth, Width);
            //LifeSimulation sim = new LifeSimulation(Heigth, Width);

            while (true)
            {
                sim.DrawAndGrow();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
