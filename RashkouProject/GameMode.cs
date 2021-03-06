using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using RashkouProject.Draw;
using RashkouProject.Game;
using RashkouProject.Game.Entities;
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
                    break;
                case ConsoleKey.LeftArrow:
                    World.Player.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    World.Player.Move(1, 0);
                    break;
                case ConsoleKey.DownArrow:
                    World.Player.Move(0, 1);
                    break;
                /*              case ConsoleKey.:
                                  World.Player.Wait();
                                  World.TimeController.Execute();
                                  break;*/
                case ConsoleKey.L:
                    World.State = new TileChoosingMode(World.Player.SightRadius, (Entity e) => {},
                        (x, y) => {
                            return new List<Entity>(World.CurrentLocation.Tiles[x, y].ReturnEntities());
                        }, (matrix) => {
                            matrix.PrintLine("", 2, 37, White, Black);
                            matrix.PrintLine("PageUp/Down для прокрутки страницы", 2, 38, White, Black);
                            matrix.PrintLine("/ или * для выбора страницы", 2, 39, White, Black);}
                        );
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
                case ConsoleKey.J:
                    World.State = new EventLogMode();
                    break;
                case ConsoleKey.G:
                    World.State = new TileChoosingMode(0,
                        (e) =>
                        {
                            World.Player.Pickup((ItemEntity)e);
                            World.Events.AddEvent("Вы подобрали: "+e.Name);
                        },
                        (x, y) => { return new List<Entity>(World.CurrentLocation.Tiles[x, y].ItemEntities); },
                        (matrix) =>
                        {
                            matrix.PrintLine("Enter - для подбора предмета", 2, 37, White, Black);
                            matrix.PrintLine("PageUp/Down для прокрутки страницы", 2, 38, White, Black);
                            matrix.PrintLine("/ или * для выбора страницы", 2, 39, White, Black);
                        }
                        );
                    break;
                case ConsoleKey.U:
                    World.State = new TileChoosingMode(1, (Entity e) =>
                        {
                            var mapEntity = (MapEntity)e;
                            mapEntity.Activate(World.Player);
                            World.State = new GameMode();
                        },
                        ((x, y) =>
                        {
                            return new List<Entity>(World.CurrentLocation.Tiles[x, y].Mapentities);
                        }), (matrix) =>
                        {
                            matrix.PrintLine("Enter - для использования этого объекта", 2, 37, White, Black);
                            matrix.PrintLine("PageUp/Down для прокрутки страницы", 2, 38, White, Black);
                            matrix.PrintLine("/ или * для выбора страницы", 2, 39, White, Black);
                        }
                    );
                    break;
            }

            World.CurrentLocation.ViewMap(World.Player.X, World.Player.Y, World.Player.SightRadius);
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
                GameMatrix[x, 24] = new Char('-', White, Black);
                GameMatrix[x, 26] = new Char('-', White, Black);
                GameMatrix[x, 37] = new Char('-', White, Black);
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
            if (World.Events.Events.Count > 0)
                GameMatrix.PrintLine(World.Events.Events[World.Events.Events.Count - 1], 2, 38, White, Black);
            GameMatrix.MatrixDrawChar();
            Console.Title = "Character: " + World.Player.Name + " HP: " + World.Player.HP + "/" + World.Player.MaxHP;
            
            
        }
    }
}