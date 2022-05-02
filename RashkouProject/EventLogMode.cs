using System;
using RashkouProject.Draw;
using RashkouProject.Game;
using Char = RashkouProject.Draw.Char;
using static System.ConsoleColor;

namespace RashkouProject
{
    public class EventLogMode: World.IState
    {
        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    World.State = new GameMode();
                    break;
            }
        }

        public override void Output()
        {
            GameMatrix = new Matrix(79, 40, new Char(' ', Black, Black));
            for (int i = 0; i < 39 && i < World.Events.Events.Count; i++)
            {
                  GameMatrix.PrintLine(World.Events.Events[World.Events.Events.Count-i-1], 2, i, White, Black);
            }
            GameMatrix.MatrixDrawChar();
        }
    }

}