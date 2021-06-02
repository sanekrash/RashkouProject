using System;
using RashkouProject.Draw;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject
{
    public class GameMode : World.IState
    {
        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    World.Player.Move(0, -1);
                    break;
                case ConsoleKey.LeftArrow:
                    World.Player.Move(-1, 0);
                    break;

                case ConsoleKey.RightArrow:
                    World.Player.Move(1, 0);
                    break;

                case ConsoleKey.DownArrow:
                    World.Player.Move(0, 1);
                    break;
                case ConsoleKey.L:
                    World.State = new LookMode(World.Player.X,World.Player.Y);
                    break;
            }
        }

        public override void Output()
        {
            GameMatrix = new Matrix(79, 40, new Char(' ', Black, Black));
            GameMatrix.Print(World.CurrentLocation.Camera(World.Player.X, World.Player.Y), 0, 0);

            for (int x = 0; x < 79; x++)
            {
                for (int y = 24; y < 40; y++)
                {
                    GameMatrix[x, y] = new Char(' ', White, Black);
                }
            }
            
            for (int x = 0; x < 79; x++)
            {
                GameMatrix[x, 24] = new Char('≡', White, Black);
                GameMatrix[x, 26] = new Char('≡', White, Black);
            }

            GameMatrix.PrintLine(World.Player.Name, 40 - World.Player.Name.Length / 2, 25, Green, Black);
            GameMatrix.PrintLine("HP: " + World.Player.HP + "/" + World.Player.MaxHP, 2, 28, White, Black);
            GameMatrix.PrintLine("HP: " + World.Player.MP + "/" + World.Player.MaxMP, 40, 28, White, Black);
            GameMatrix.PrintLine("Level: " + World.Player.Level, 2, 30, White, Black);
            GameMatrix.PrintLine("EXP: " + World.Player.Exp, 40, 30, White, Black);
            GameMatrix.MatrixDrawChar();
        }
    }
}