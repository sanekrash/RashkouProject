using System;
using RashkouProject.Draw;
using RashkouProject.Game;
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
                    World.TimeController.ExecuteUntil(World.Player);
                    break;
                case ConsoleKey.LeftArrow:
                    World.Player.Move(-1, 0);
                    World.TimeController.ExecuteUntil(World.Player);
                    break;
                case ConsoleKey.RightArrow:
                    World.Player.Move(1, 0);
                    World.TimeController.ExecuteUntil(World.Player);
                    break;
                case ConsoleKey.DownArrow:
                    World.Player.Move(0, 1);
                    World.TimeController.ExecuteUntil(World.Player);
                    break;
  /*              case ConsoleKey.:
                    World.Player.Wait();
                    World.TimeController.Execute();
                    break;*/
                case ConsoleKey.L:
                    World.State = new LookMode(World.Player.X,World.Player.Y);
                    break;
                case ConsoleKey.C:
                    World.State = new CommandMode();
                    break;
                case ConsoleKey.I:
                    World.State = new InventoryMode();
                    break;
                case ConsoleKey.W:
                    World.State = new InventoryWearMode();
                    break;
                case ConsoleKey.G:
                    World.State = new PickupMode(World.Player.X,World.Player.Y);
                    break;

            }
            World.CurrentLocation.ViewMap(World.Player.X, World.Player.Y, 16);
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
            GameMatrix.PrintLine("MP: " + World.Player.MP + "/" + World.Player.MaxMP, 40, 28, White, Black);
            GameMatrix.PrintLine("Level: " + World.Player.Level, 2, 30, White, Black);
            GameMatrix.PrintLine("EXP: " + World.Player.Exp, 40, 30, White, Black);
            if (World.Player.EquipmentSlots[0].Slot != null)
                GameMatrix.PrintLine("Оружие: " + World.Player.EquipmentSlots[0].Slot.Name, 2, 32, White, Black);
            else
                GameMatrix.PrintLine("Оружие: отсутствует", 2, 32, White, Black);
            GameMatrix.MatrixDrawChar();
            Console.Title = "Character: " + World.Player.Name + " HP: " + World.Player.HP + "/" + World.Player.MaxHP;
        }
    }
}