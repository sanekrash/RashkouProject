using System;
using System.Collections.Generic;
using RashkouProject.Core;
using RashkouProject.Draw;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;


namespace RashkouProject
{
    public class CommandMode : World.IState
    {
        private string _command = "BENIS";
        public CommandMode()
        {
        }

        private void Execute(string command)
        {
            switch (command)
            {
                case "DEBUG":
                    World.State = new DebugMode();
                    break;
                case "ADDHP":
                    World.Player.HP = World.Player.HP + 9000;
                    World.State = new GameMode();
                    break;
                case "wait":
                    World.Player.Wait();
                    World.State = new GameMode();
                    break;
                default:
                    World.State = new GameMode();
                    break;
            }
        }

        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Backspace:
                    if (_command.Length > 0)
                    {
                        _command = _command.Remove(_command.Length - 1, 1);
                    }
                    break;
                case ConsoleKey.Escape:
                    World.State = new GameMode();
                    break;
                case ConsoleKey.Enter:
                    Execute(_command);
                    break;
                default:
                    if (_command.Length < 79)
                        _command = _command + key.KeyChar;
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

            GameMatrix.PrintLine(">" + _command, 0, 25, Green, Black);
            GameMatrix.PrintLine("HP: " + World.Player.HP + "/" + World.Player.MaxHP, 2, 28, White, Black);
            GameMatrix.PrintLine("HP: " + World.Player.MP + "/" + World.Player.MaxMP, 40, 28, White, Black);
            GameMatrix.PrintLine("Level: " + World.Player.Level, 2, 30, White, Black);
            GameMatrix.PrintLine("EXP: " + World.Player.Exp, 40, 30, White, Black);
            GameMatrix.MatrixDrawChar();
        }
    }
}