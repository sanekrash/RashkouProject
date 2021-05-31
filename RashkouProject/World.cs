using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
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
            Player = new Human("Mailine Vestocka", 3,3);
            Player.Glyph = '@';
            Console.Title = "Character: "+Player.Name+" HP: "+Player.HP+"/"+Player.MaxHP;
            CurrentLocation = new Location(79, 24);

            for (int x = 0; x < 79; x++)
            for (int y = 0; y < 24; y++)
            {
                CurrentLocation.Tiles[x, y].AddEntity(new Floor());
            }

            for (int x = 0; x < 79; x++)
            {
                CurrentLocation.Tiles[x, 0].AddEntity(new Wall());
                CurrentLocation.Tiles[x, 23].AddEntity(new Wall());
            }

            for (int y = 1; y < 23; y++)
            {
                CurrentLocation.Tiles[0, y].AddEntity(new Wall());
                CurrentLocation.Tiles[78, y].AddEntity(new Wall());
            }
            CurrentLocation.Spawn(Player, Player.X,Player.Y);

        }



        public override void Input(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                {
                    CurrentLocation.Tiles[Player.X, Player.Y].DeleteEntity(Player);
                    Player.MoveTo(Player.X, Player.Y-1);
                    CurrentLocation.Tiles[Player.X, Player.Y].AddEntity(Player);
                    break;
                }
                case ConsoleKey.LeftArrow:
                {
                    CurrentLocation.Tiles[Player.X, Player.Y].DeleteEntity(Player);
                    Player.MoveTo(Player.X-1, Player.Y);
                    CurrentLocation.Tiles[Player.X, Player.Y].AddEntity(Player);
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    CurrentLocation.Tiles[Player.X, Player.Y].DeleteEntity(Player);
                    Player.MoveTo(Player.X+1, Player.Y);
                    CurrentLocation.Tiles[Player.X, Player.Y].AddEntity(Player);
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    CurrentLocation.Tiles[Player.X, Player.Y].DeleteEntity(Player);
                    Player.MoveTo(Player.X, Player.Y+1);
                    CurrentLocation.Tiles[Player.X, Player.Y].AddEntity(Player);
                    break;
                }
            }
        }

        public override void Output()
        {
            GameMatrix = new Matrix(79, 25, new Char(' ', Black, Black));
            for (int x = 0; x < CurrentLocation.Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < CurrentLocation.Tiles.GetLength(1); y++)
                {
                    GameMatrix[x, y] = CurrentLocation.Tiles[x, y].PrintTile();
                }
            }

            //          _matrix.Print(new Char('@',White,Black),playerX,playerY); 
            GameMatrix.MatrixDrawChar();
        }
    }
}