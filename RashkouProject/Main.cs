using System;
using RashkouProject.Core;
using System.Threading;
using static System.ConsoleColor;
using RashkouProject.Draw;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            _.State = new Menu();
            _.State.Output();
            Console.BackgroundColor = Black;
            Console.Title = "Mailine Vestochka";
            while (true) 
            {
                var key = Console.ReadKey(true);
                _.State.Input(key);
                _.State.Output();
            }
        }
    }
}