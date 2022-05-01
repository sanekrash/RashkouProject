using System;
using RashkouProject.Core;
using static System.ConsoleColor;


namespace RashkouProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(79, 41);
            _.State = new Menu();
            _.State.Output();
            Console.BackgroundColor = Black;
            while (true) 
            {
                var key = Console.ReadKey(true);
                _.State.Input(key);
                _.State.Output();
                
            }
        }
    }
}