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
            Matrix matrix = new Matrix(79, 25, new Char(' ', Black, Black));
            matrix.PrintLine("n - новая игра", 1, 1, White, Black);
            matrix.PrintLine("h - справка", 1, 3, White, Black);
            matrix.PrintLine("q - выйти", 1, 5, White, Black);
            matrix.PrintLine("Федя лох, господа, мимо ваш Sanekrash", 1, 23, White, Black);
            DrawMatrix.Draw(matrix.Chars);
        }

        public void Input(ConsoleKeyInfo key)
        {
            switch (key.KeyChar)
            {
                case 'n':
                    _.State = new World();
                    break;
                case 'h':
                    _.State = new MenuHelp();
                    break;
                case 'q':
                    Environment.Exit(0);
                    break;
            }
        }

        public void Output()
        {
        }
    }
}