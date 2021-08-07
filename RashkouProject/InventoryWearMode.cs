using System;
using RashkouProject.Draw;
using RashkouProject.Game.Entities;
using static System.ConsoleColor;
using Char = System.Char;

namespace RashkouProject
{
    public class InventoryWearMode : World.IState
    {
        private int _select = 0, _maxselect = 6;

        public override void Input(ConsoleKeyInfo key)
        {
            {
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        World.State = new GameMode();
                        break;
                    case ConsoleKey.UpArrow:
                        if (_select > 0)
                            _select--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (_select < _maxselect)
                            _select++;
                        break;
                    case ConsoleKey.W:
                        World.Player.UnEquip(World.Player.EquipmentSlots[_select]); 
                        break;
                    case ConsoleKey.U:
                        if (World.Player.EquipmentSlots[_select] != null) 
                            World.Player.Use(World.Player.EquipmentSlots[_select].Slot);
                        break;
                }
            }
        }

        public string NullCheck(EquipmentSlot slot)
        {
            if (slot.Slot != null)
                return (slot.Name+": " + slot.Slot.Name);
            else
                return (slot.Name+": " + "отсутствует");
        }


        public override void Output()
        {
            GameMatrix = new Matrix(79, 40, new Draw.Char(' ', Black, Black));
            for (int i = 0; i < 7; i++)
            {
                if (i == _select)
                    GameMatrix.PrintLine("[.]"+NullCheck(World.Player.EquipmentSlots[i]), 2, 2 + i, White, Black);
                else
                    GameMatrix.PrintLine(" . "+NullCheck(World.Player.EquipmentSlots[i]), 2, 2 + i, White, Black);

            }
            GameMatrix.PrintLine("u - использовать, d - выбросить, w - снять", 2, 36, White, Black);
            GameMatrix.PrintLine("Стрелки для прокрутки страницы", 2, 38, White, Black);
            GameMatrix.MatrixDrawChar();        }
    }
}