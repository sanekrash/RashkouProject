using System;
using RashkouProject.Draw;
using RashkouProject.Game;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject
{
    public class DebugMode : World.IState
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
            GameMatrix.PrintLine(World.Player.Name, 0, 0, Green, Black);
            GameMatrix.PrintLine(World.Player.HP+"/"+World.Player.HP+"HP", 0, 1, Green, Black);
            GameMatrix.PrintLine(World.Player.MP+"/"+World.Player.MP+"MP", 0, 2, Green, Black);
            GameMatrix.PrintLine("Level: "+World.Player.Level, 0, 3, Green, Black);
            GameMatrix.PrintLine("Exp: "+World.Player.Exp, 0, 4, Green, Black);
            GameMatrix.PrintLine("Time: "+TimeController.Time,0, 5, Green, Black);
            GameMatrix.MatrixDrawChar();
        }
    }
}