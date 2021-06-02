using System;
using RashkouProject.Draw;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject
{
    public class LookMode : World.IState
    {
        private int X, Y;
        public LookMode(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override void Input(ConsoleKeyInfo key)
        {

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    Y--;
                    break;
                case ConsoleKey.LeftArrow:
                    X--;
                    break;
                case ConsoleKey.RightArrow:
                    X++;
                    break;
                case ConsoleKey.DownArrow:
                    Y++;
                    break;
                case ConsoleKey.N:
                    World.State = new GameMode();
                    break;
            }
        }

        public override void Output()
        {
            GameMatrix = new Matrix(79, 40, new Char(' ', Black, Black));
            GameMatrix.Print(World.CurrentLocation.Camera(X, Y), 0, 0);
            GameMatrix.Print(new Char('X',Red,Black), 39, 12);
            for (int x = 0; x < 79; x++)
            {
                GameMatrix[x, 24] = new Char('≡', White, Black);
                GameMatrix[x, 26] = new Char('≡', White, Black);
            }
            GameMatrix.PrintLine(World.CurrentLocation.Tiles[X,Y].PriorityEntity().Name, 
                40 - World.CurrentLocation.Tiles[X,Y].PriorityEntity().Name.Length / 2, 25, Green, Black);

            GameMatrix.MatrixDrawChar();            
        }
    }
}