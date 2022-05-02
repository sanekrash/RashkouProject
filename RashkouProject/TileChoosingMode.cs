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
        private const int PageElements = 10;
        private int _x, _y;
        private ItemEntity _item;
        private CharEntity _user;
        private int _chooseRange;
        private int _select = 0, _page = 0, _maxpage = 0, _maxselect = 0;
        private List<Entity> _selectedTileEntities;
        private readonly Action<Matrix> _bottomText;
        private readonly Action<int, int> _activate;
        private readonly Action<Entity> _objectActivate;
        private Func<int, int, List<Entity>> _entityList;


        public TileChoosingMode(int range, Action<Entity> action, Func<int, int, List<Entity>> entityList, Action<Matrix> bottomText)
        {
            Init(World.Player, range);
            _objectActivate = action;
            _entityList = entityList;
            _bottomText = bottomText;
            LookTile();
        }

        public TileChoosingMode(int range, Action<int, int> action, Func<int, int, List<Entity>> entityList, Action<Matrix> bottomText)
        {
            Init(World.Player, range);
            _activate = action;
            _entityList = entityList;
            _bottomText = bottomText;
            LookTile();
        }

        public void Init(CharEntity entity, int range)
        {
            _user = entity;
            _x = _user.X;
            _y = _user.Y;
            _chooseRange = range;
        }

        public void LookTile()
        {
            _selectedTileEntities = _entityList(_x, _y);
            _maxpage = _selectedTileEntities.Count / PageElements;
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
                    if (_select < 9 && _select < _maxselect - _page * PageElements - 1)
                        _select++;
                    break;
                case ConsoleKey.Enter:
                    if (_activate != null)
                        _activate(_x, _y);
                    if ((_objectActivate != null) && _selectedTileEntities.Count > 0)
                        _objectActivate(_selectedTileEntities[_select + _page * PageElements]);
                    LookTile();
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
                GameMatrix[x, 24] = new Draw.Char('-', White, Black);
                GameMatrix[x, 26] = new Draw.Char('-', White, Black);
            }

            if (World.CurrentLocation.VisionMap[_x, _y])
            {
                GameMatrix.PrintLine(World.CurrentLocation.Tiles[_x, _y].PriorityEntity().Name,
                    40 - World.CurrentLocation.Tiles[_x, _y].PriorityEntity().Name.Length / 2, 25, Green, Black);
            }
            else
                GameMatrix.PrintLine("Вы не видите эту область", 40 - 24 / 2, 25, Green, Black);

            if (World.CurrentLocation.VisionMap[_x, _y])
                for (int y = 0; y < 10 && y < _maxselect - _page * PageElements; y++)
                    if (y == _select)
                    {
                        GameMatrix.PrintLine("[.]" + _selectedTileEntities[y + _page * PageElements].Name, 1, y + 27,
                            White, Black);
                        GameMatrix.Print(_selectedTileEntities[y + _page * PageElements].ShortDescription, 42, 27);
                    }
                    else
                        GameMatrix.PrintLine(" . " + _selectedTileEntities[y + _page * PageElements].Name, 1, y + 27,
                            White, Black);
            
            _bottomText(GameMatrix);
            GameMatrix.MatrixDrawChar();
        }
    }
}