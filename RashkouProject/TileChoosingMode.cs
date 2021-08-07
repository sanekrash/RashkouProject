using System;
using RashkouProject.Draw;
using RashkouProject.Game;
using RashkouProject.Game.Entities;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;


namespace RashkouProject
{
    public class TileChoosingMode : World.IState
    {
        private int X, Y;
        private ItemEntity Item;
        private CharEntity User;
        private int ChooseRange;

        public TileChoosingMode(ItemEntity itemEntity, CharEntity entity, int range)
        {
            Item = itemEntity;
            User = entity;
            X = User.X;
            Y = User.Y;
            ChooseRange = range;
        }


        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Y > 0 && GetRange(X, User.X, Y-1, User.Y) <= Math.Pow(ChooseRange, 2))
                        Y--;
                    break;
                case ConsoleKey.LeftArrow:
                    if (X > 0 && GetRange(X-1, User.X, Y, User.Y) <= Math.Pow(ChooseRange, 2))
                        X--;
                    break;
                case ConsoleKey.RightArrow:
                    if (X < World.CurrentLocation.Tiles.GetLength(0) - 1
                        && GetRange(X+1, User.X, Y, User.Y) <= Math.Pow(ChooseRange, 2))
                        X++;
                    break;
                case ConsoleKey.DownArrow:
                    if (Y < World.CurrentLocation.Tiles.GetLength(1) - 1
                        && GetRange(X, User.X, Y+1, User.Y) <= Math.Pow(ChooseRange, 2))
                        Y++;
                    break;
                case ConsoleKey.Enter:
                    Item.Use(User, X, Y);
                    World.State = new GameMode();
                    break;
                case ConsoleKey.Escape:
                    World.State = new GameMode();
                    break;
            }
        }

        public double GetRange(int x1, int x2, int y1, int y2)
        {
            return Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2);
        }
        public override void Output()
        {
            GameMatrix = new Matrix(79, 40, new Draw.Char(' ', Black, Black));
            GameMatrix.Print(World.CurrentLocation.Camera(X, Y), 0, 0);
            GameMatrix.Print(new Draw.Char('X', Red, Black), 39, 12);
            for (int x = 0; x < 79; x++)
            {
                GameMatrix[x, 24] = new Draw.Char('≡', White, Black);
                GameMatrix[x, 26] = new Draw.Char('≡', White, Black);
            }

            if (World.CurrentLocation.VisionMap[X, Y])
                GameMatrix.PrintLine(World.CurrentLocation.Tiles[X, Y].PriorityEntity().Name,
                    40 - World.CurrentLocation.Tiles[X, Y].PriorityEntity().Name.Length / 2, 25, Green, Black);
            else
                GameMatrix.PrintLine("Вы не видите эту область", 40 - 24 / 2, 25, Green, Black);

            GameMatrix.PrintLine("Enter - для выбора области", 2, 39, White, Black);
            GameMatrix.MatrixDrawChar();
        }
    }
}