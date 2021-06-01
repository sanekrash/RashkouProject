using System;
using RashkouProject.Core;
using RashkouProject.Draw;
using RashkouProject.Game;
using RashkouProject.Game.Entities;
using RashkouProject.Game.Entities.CharacterEntity;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;


namespace RashkouProject
{
    public class World : _.IState
    {
        public Location CurrentLocation;
        public CharEntity Player;

        //       int playerX = 20, playerY = 20;
        public World()
        {
            Player = new Human("Mailine Vestochka ", 2, 2);
            Player.Glyph = '@';
            Console.Title = "Character: " + Player.Name + " HP: " + Player.HP + "/" + Player.MaxHP;
            CurrentLocation = new Location(50, 50);

            for (int x = 0; x < 50; x++)
            for (int y = 0; y < 50; y++)
            {
                CurrentLocation.Tiles[x, y].AddEntity(new Floor());
            }

            for (int x = 0; x < 50; x++)
            {
                CurrentLocation.Tiles[x, 0].AddEntity(new Wall());
                CurrentLocation.Tiles[x, 49].AddEntity(new Wall());
            }

            for (int y = 1; y < 50; y++)
            {
                CurrentLocation.Tiles[0, y].AddEntity(new Wall());
                CurrentLocation.Tiles[49, y].AddEntity(new Wall());
            }

            CurrentLocation.Spawn(Player, Player.X, Player.Y);
        }


        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CurrentLocation.Tiles[Player.X, Player.Y - 1].IsPassing())
                    {
                        CurrentLocation.Tiles[Player.X, Player.Y].DeleteEntity(Player);
                        Player.MoveTo(Player.X, Player.Y - 1);
                        CurrentLocation.Tiles[Player.X, Player.Y].AddEntity(Player);
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    if (CurrentLocation.Tiles[Player.X - 1, Player.Y].IsPassing())
                    {
                        CurrentLocation.Tiles[Player.X, Player.Y].DeleteEntity(Player);
                        Player.MoveTo(Player.X - 1, Player.Y);
                        CurrentLocation.Tiles[Player.X, Player.Y].AddEntity(Player);
                    }

                    break;

                case ConsoleKey.RightArrow:
                    if (CurrentLocation.Tiles[Player.X + 1, Player.Y].IsPassing())
                    {
                        CurrentLocation.Tiles[Player.X, Player.Y].DeleteEntity(Player);
                        Player.MoveTo(Player.X + 1, Player.Y);
                        CurrentLocation.Tiles[Player.X, Player.Y].AddEntity(Player);
                    }

                    break;

                case ConsoleKey.DownArrow:
                    if (CurrentLocation.Tiles[Player.X, Player.Y + 1].IsPassing() == true)
                    {
                        CurrentLocation.Tiles[Player.X, Player.Y].DeleteEntity(Player);
                        Player.MoveTo(Player.X, Player.Y + 1);
                        CurrentLocation.Tiles[Player.X, Player.Y].AddEntity(Player);
                    }

                    break;
            }
        }

        public override void Output()
        {
            GameMatrix = new Matrix(79, 40, new Char(' ', Black, Black));
            for (int x = Player.X - 39; x < Player.X + 39; x++)
            {
                for (int y = Player.Y - 12; y < Player.Y + 12; y++)
                {
                    if ((x >= 0 && x < CurrentLocation.Tiles.GetLength(0)) &&
                        (y >= 0 && y < CurrentLocation.Tiles.GetLength(1)))
                    {
                        GameMatrix[x + 39 - Player.X, y + 12 - Player.Y] =
                            CurrentLocation.Tiles[x, y].PrintTile();
                    }
                    else
                    {
                        GameMatrix[x + 39 - Player.X, y + 12 - Player.Y] = new Char('~', White, Black);
                    }
                }
            }
            
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

            GameMatrix.PrintLine(Player.Name, 40 - Player.Name.Length / 2, 25, Green, Black);
            GameMatrix.PrintLine("HP: " + Player.HP + "/" + Player.MaxHP, 2, 28, White, Black);
            GameMatrix.PrintLine("HP: " + Player.MP + "/" + Player.MaxMP, 40, 28, White, Black);
            GameMatrix.PrintLine("Level: " + Player.Level, 2, 30, White, Black);
            GameMatrix.PrintLine("EXP: " + Player.Exp, 40, 30, White, Black);


            GameMatrix.MatrixDrawChar();
        }
    }
}