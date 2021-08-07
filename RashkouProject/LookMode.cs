using System;
using System.Collections.Generic;
using RashkouProject.Draw;
using RashkouProject.Game;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject
{
    public class LookMode : World.IState
    {
        private int X, Y;
        private int _select = 0, _page = 0, _maxpage = 0, _maxselect = 0;
        private List<Entity> _selectedTileEntities;

        public LookMode(int x, int y)
        {
            X = x;
            Y = y;
            LookTile();
        }

        public void LookTile()
        {
            _selectedTileEntities = World.CurrentLocation.Tiles[X, Y].ReturnEntities();
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
                    if (Y > 0)
                    {
                        Y--;
                        LookTile();
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    if (X > 0)
                    {
                        X--;
                        LookTile();
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (X < World.CurrentLocation.Tiles.GetLength(0) - 1)
                    {
                        X++;
                        LookTile();
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (Y < World.CurrentLocation.Tiles.GetLength(1) - 1)
                    {
                        Y++;
                        LookTile();
                    }

                    break;

                case ConsoleKey.Escape:
                    World.State = new GameMode();
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
                case ConsoleKey.R:
                    break;
                // DEBUG 
            }
        }

        public override void Output()
        {
            GameMatrix = new Matrix(79, 40, new Char(' ', Black, Black));
            GameMatrix.Print(World.CurrentLocation.Camera(X, Y), 0, 0);
            GameMatrix.Print(new Char('X', Red, Black), 39, 12);
            for (int x = 0; x < 79; x++)
            {
                GameMatrix[x, 24] = new Char('≡', White, Black);
                GameMatrix[x, 26] = new Char('≡', White, Black);
            }
            if (World.CurrentLocation.VisionMap[X,Y])
                GameMatrix.PrintLine(World.CurrentLocation.Tiles[X, Y].PriorityEntity().Name,
                40 - World.CurrentLocation.Tiles[X, Y].PriorityEntity().Name.Length / 2, 25, Green, Black);
            else
                GameMatrix.PrintLine("Вы не видите эту область", 40 - 24 / 2, 25, Green, Black);
            for (int y = 27; y < 40; y++)
                GameMatrix.Print(new Char('|', White, Black), 40, y);
            if (World.CurrentLocation.VisionMap[X,Y])
                for (int y = 0; y < 10 && y < _maxselect - _page * 10; y++)
                    if (y == _select)
                        GameMatrix.PrintLine("[.]" + _selectedTileEntities[y + _page * 10].Name, 1, y + 27, White, Black);
                    else
                        GameMatrix.PrintLine(" . " + _selectedTileEntities[y + _page * 10].Name, 1, y + 27, White, Black);


            GameMatrix.PrintLine("PageUp/Down для прокрутки страницы", 2, 38, White, Black);
            GameMatrix.PrintLine("/ или * для выбора страницы", 2, 39, White, Black);
            GameMatrix.MatrixDrawChar();
        }
    }
}