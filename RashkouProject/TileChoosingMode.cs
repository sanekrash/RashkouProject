using System;
using System.Collections.Generic;
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
        private int _select = 0, _page = 0, _maxpage = 0, _maxselect = 0;
        private List<MapEntity> _selectedTileEntities;

        public TileChoosingMode(CharEntity entity, int range, Command command)
        {
            Init(entity, range, command);
            LookTile();
        }

        public TileChoosingMode(ItemEntity itemEntity, CharEntity entity, int range, Command command)
        {
            _item = itemEntity;
            Init(entity, range, command);
        }

        public void Init(CharEntity entity, int range, Command command)
        {
            _user = entity;
            _x = _user.X;
            _y = _user.Y;
            _chooseRange = range;
            _currentCommand = command;
        }

        public void LookTile()
        {
            _selectedTileEntities = World.CurrentLocation.Tiles[_x, _y].Mapentities;
            _maxpage = _selectedTileEntities.Count / 10;
            _maxselect = _selectedTileEntities.Count;
            _select = 0;
            _page = 0;
        }

        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (_y > 0 && GetRange(_x, _user.X, _y - 1, _user.Y) <= Math.Pow(_chooseRange, 2))
                        _y--;
                    LookTile();
                    break;
                case ConsoleKey.LeftArrow:
                    if (_x > 0 && GetRange(_x - 1, _user.X, _y, _user.Y) <= Math.Pow(_chooseRange, 2))
                        _x--;
                    LookTile();
                    break;
                case ConsoleKey.RightArrow:
                    if (_x < World.CurrentLocation.Tiles.GetLength(0) - 1
                        && GetRange(_x + 1, _user.X, _y, _user.Y) <= Math.Pow(_chooseRange, 2))
                        _x++;
                    LookTile();
                    break;
                case ConsoleKey.DownArrow:
                    if (_y < World.CurrentLocation.Tiles.GetLength(1) - 1
                        && GetRange(_x, _user.X, _y + 1, _user.Y) <= Math.Pow(_chooseRange, 2))
                        _y++;
                    LookTile();
                    break;
                case ConsoleKey.Divide:
                    if (_page > 0)
                        _page--;
                    _select = 0;
                    break;
                case ConsoleKey.Multiply:
                    if (_page < _maxpage)
                        _page++;
                    _select = 0;
                    break;
                case ConsoleKey.PageUp:
                    if (_select > 0)
                        _select--;
                    break;
                case ConsoleKey.PageDown:
                    if (_select < 9 && _select < _maxselect - _page * 10 - 1)
                        _select++;
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
                        case Command.Activate:
                            World.CurrentLocation.Tiles[_x, _y].Mapentities[_select + _page * 10].Activate(World.Player);
                            LookTile();
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
            if (World.CurrentLocation.VisionMap[_x,_y])
                for (int y = 0; y < 10 && y < _maxselect - _page * 10; y++)
                    if (y == _select)
                        GameMatrix.PrintLine("[.]" + _selectedTileEntities[y + _page * 10].Name, 1, y + 27, White, Black);
                    else
                        GameMatrix.PrintLine(" . " + _selectedTileEntities[y + _page * 10].Name, 1, y + 27, White, Black);

            GameMatrix.PrintLine("Enter - для выбора области", 2, 37, White, Black);
            GameMatrix.PrintLine("PageUp/Down для прокрутки страницы", 2, 38, White, Black);
            GameMatrix.PrintLine("/ или * для выбора страницы", 2, 39, White, Black);

            GameMatrix.MatrixDrawChar();
        }
    }

    public enum Command
    {
        Throw,
        Use,
        Activate
    }
}