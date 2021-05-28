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
            GameMatrix = new Matrix(79, 25, new Char(' ', Black, Black));
            GameMatrix.PrintLine("n - новая игра", 1, 1, White, Black);
            GameMatrix.PrintLine("h - справка", 1, 3, White, Black);
            GameMatrix.PrintLine("q - выйти", 1, 5, White, Black);
            GameMatrix.PrintLine("Федя лох, господа, мимо ваш Sanekrash", 1, 23, White, Black);
            GameMatrix.MatrixDrawChar();
        }
        
    }
}