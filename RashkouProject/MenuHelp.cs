using System;
using RashkouProject.Core;
using RashkouProject.Draw;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;


namespace RashkouProject
{
    public class MenuHelp : _.IState
    {
        public MenuHelp()
        {
 
        }
        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.KeyChar)
            {
                case 'b':
                    _.State = new Menu();
                    break;
            }
        }

        public override void Output()
        {
            GameMatrix = new Matrix(79, 25, new Char(' ', Black, Black));
            GameMatrix.PrintLine("Тут нихуя нет, нажми b, чтобы вернуться в меню", 1, 1, White, Black);
            GameMatrix.MatrixDrawChar();
        }
        

    }
}