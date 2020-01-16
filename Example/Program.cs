namespace Example
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Example
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;

        public static void Main()
        {
            List<int> it = new List<int>();

            var result = Parallel.For(1, 50, (i, state) =>
            {

                Console.WriteLine(i);
                it.Add(i);
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.P)
                {
                    foreach (var z in it)
                    {
                        Console.WriteLine(z);
                    }

                    state.Break();
                }
                Thread.Sleep(500);
            });

        }
    }
}
