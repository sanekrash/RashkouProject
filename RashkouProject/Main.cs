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
            Console.BackgroundColor = Black;
            while (true) 
            {
                var key = Console.ReadKey(true);
                _.State.Input(key);
            }
        }
    }
}