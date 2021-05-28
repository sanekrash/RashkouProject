using System;
using RashkouProject.Core;
using RashkouProject.Draw;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject
{
    class Menu : _.IState
    {
        public Menu()
        {
        }

        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.N:
                    _.State = new World();
                    break;
                case ConsoleKey.H:
                    _.State = new MenuHelp();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }

        public override void Output()
        {
            _matrix = new Matrix(79, 25, new Char(' ', Black, Black));
            _matrix.PrintLine("n - новая игра", 1, 1, White, Black);
            _matrix.PrintLine("h - справка", 1, 3, White, Black);
            _matrix.PrintLine("q - выйти", 1, 5, White, Black);
            _matrix.PrintLine("Федя лох, господа, мимо ваш Sanekrash", 1, 23, White, Black);
            _matrix.MatrixDrawChar();
        }
        
    }
}