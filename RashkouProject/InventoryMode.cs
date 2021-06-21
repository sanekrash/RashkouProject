using System;
using RashkouProject.Draw;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject
{
    public class InventoryMode : World.IState
    {
        private int _select = 0, _page = 0, _maxpage = 0, _maxselect = 0;

        public InventoryMode()
        {
            _maxpage = World.Player.Inventory.Count / 35;
            _maxselect = World.Player.Inventory.Count;
            _select = 0; _page = 0;
        }

        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
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
                    if (_select < 35 && _select < _maxselect - _page * 35 - 1)
                        _select++;
                    break;
                case ConsoleKey.D:
                    if (World.Player.Inventory.Count > 0) 
                    { 
                        World.Player.Drop(World.Player.Inventory[_select + _page * 35]);
                        World.TimeController.ExecuteUntil(World.Player);
                        _maxselect = World.Player.Inventory.Count;
                        _maxpage = World.Player.Inventory.Count / 35;
                    }

                    break;
            }
        }

        public override void Output()
        {
            GameMatrix = new Matrix(79, 40, new Char(' ', Black, Black));
            for (int y = 0; y < 35 && y < _maxselect - _page * 35; y++)
                if (y == _select)
                    GameMatrix.PrintLine("[.]" + World.Player.Inventory[y + _page * 35].Name , 1, y, White, Black);
                else 
                    GameMatrix.PrintLine(" . " + World.Player.Inventory[y + _page * 35].Name , 1, y, White, Black);
            GameMatrix.MatrixDrawChar();

        }
    }
}