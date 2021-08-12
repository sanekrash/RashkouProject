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
        private int _x, _y;
        private ItemEntity _item;
        private CharEntity _user;
        private int _chooseRange;
        private Command _currentCommand;

        public TileChoosingMode(ItemEntity itemEntity, CharEntity entity, int range, Command command)
        {
            _item = itemEntity;
            _user = entity;
            _x = _user.X;
            _y = _user.Y;
            _chooseRange = range;
            _currentCommand = command;
        }


        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (_y > 0 && GetRange(_x, _user.X, _y-1, _user.Y) <= Math.Pow(_chooseRange, 2))
                        _y--;
                    break;
                case ConsoleKey.LeftArrow:
                    if (_x > 0 && GetRange(_x-1, _user.X, _y, _user.Y) <= Math.Pow(_chooseRange, 2))
                        _x--;
                    break;
                case ConsoleKey.RightArrow:
                    if (_x < World.CurrentLocation.Tiles.GetLength(0) - 1
                        && GetRange(_x+1, _user.X, _y, _user.Y) <= Math.Pow(_chooseRange, 2))
                        _x++;
                    break;
                case ConsoleKey.DownArrow:
                    if (_y < World.CurrentLocation.Tiles.GetLength(1) - 1
                        && GetRange(_x, _user.X, _y+1, _user.Y) <= Math.Pow(_chooseRange, 2))
                        _y++;
                    break;
                case ConsoleKey.Enter:
                    switch (_currentCommand)
                    {
                        case Command.Use:
                            _item.Use(_user, _x, _y);
                            World.State = new GameMode();
                            World.CurrentLocation.ViewMap(World.Player.X, World.Player.Y, World.Player.SightRadius);
                            break;
                        case Command.Throw:
                            _user.Throw(_item, _x, _y);
                            World.State = new GameMode();
                            World.CurrentLocation.ViewMap(World.Player.X, World.Player.Y, World.Player.SightRadius);
                            break;
                    }
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
            GameMatrix.Print(World.CurrentLocation.Camera(_x, _y), 0, 0);
            GameMatrix.Print(new Draw.Char('X', Red, Black), 39, 12);
            for (int x = 0; x < 79; x++)
            {
                GameMatrix[x, 24] = new Draw.Char('≡', White, Black);
                GameMatrix[x, 26] = new Draw.Char('≡', White, Black);
            }

            if (World.CurrentLocation.VisionMap[_x, _y])
                GameMatrix.PrintLine(World.CurrentLocation.Tiles[_x, _y].PriorityEntity().Name,
                    40 - World.CurrentLocation.Tiles[_x, _y].PriorityEntity().Name.Length / 2, 25, Green, Black);
            else
                GameMatrix.PrintLine("Вы не видите эту область", 40 - 24 / 2, 25, Green, Black);

            GameMatrix.PrintLine("Enter - для выбора области", 2, 39, White, Black);
            GameMatrix.MatrixDrawChar();
        }
    }

    public enum Command
    {
        Throw,
        Use
    }
}