using System;
using RashkouProject.Core;
using RashkouProject.Draw;
using RashkouProject.Game;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject
{
    public class DieScreen : _.IState
    {
        private String _name; 
            public DieScreen(string name)
            {
                _name = name;
                World.TimeController.TimeLapseList.Nodes.Clear();
                
            }
            public override void Input(ConsoleKeyInfo key)
            {
                switch (key.Key)
                {
                    case ConsoleKey.F:
                        _.State = new Menu();
                        break;
                }
            }

            public override void Output()
            {
                GameMatrix = new Matrix(79, 39, new Char(' ', Black, Black));
                GameMatrix.PrintLine("Вы умерли.", 1, 1, White, Black);
                GameMatrix.PrintLine("Вас звали: " + _name, 1, 3, White, Black);
                GameMatrix.PrintLine("Вы помогли довести игру до конца", 1, 5, White, Black);
                GameMatrix.PrintLine("Сегодня тот день, когда вы сияли ярче всех", 1, 7, White, Black);
                GameMatrix.PrintLine("Мёртвым не положено грустить, эмоции не нужны сейчас", 1, 9, White, Black);
                GameMatrix.PrintLine("И никогда с этого момента", 1, 11, White, Black);
                GameMatrix.PrintLine("Для того, чтобы выйти в меню нажмите F", 1, 38, White, Black);
                GameMatrix.MatrixDrawChar();
            }


    }
}