using System;
using System.Diagnostics;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Einstein Riddle: \n 'Who eats Swedish Fish?'");
        
        EinsteinRiddleSolver solver = new EinsteinRiddleSolver();
        
        solver.SolvePuzzle();

        Console.Write("Press any key to end.");
        Console.ReadKey();
    }
}
