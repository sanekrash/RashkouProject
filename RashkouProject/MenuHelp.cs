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
            switch (key.Key)
            {
                case ConsoleKey.B:
                    _.State = new Menu();
                    break;
            }
        }

        public override void Output()
        {
            GameMatrix = new Matrix(79, 39, new Char(' ', Black, Black));
            GameMatrix.PrintLine("Стрелки - перемещение", 1, 1, White, Black);
            GameMatrix.PrintLine("i - инвентарь", 1, 3, White, Black);
            GameMatrix.PrintLine("g - режим подбора", 1, 5, White, Black);
            GameMatrix.PrintLine("w - просмотр надетых вещей", 1, 7, White, Black);
            GameMatrix.PrintLine("u - взаимодействие с объектом", 1, 9, White, Black);
            GameMatrix.PrintLine("j - журнал событий", 1, 9, White, Black);
            GameMatrix.PrintLine("Хочешь выйти в меню? Нажми b", 1, 38, White, Black);
            GameMatrix.MatrixDrawChar();
        }
        

    }
}