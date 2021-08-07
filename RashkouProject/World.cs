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
        public static Location CurrentLocation;
        public static CharEntity Player;
        public static TimeController TimeController = new TimeController();

        public abstract class IState
        {
            public abstract void Input(ConsoleKeyInfo key);
            public abstract void Output();
            public Matrix GameMatrix;
        }

        public static IState State;

        //       int playerX = 20, playerY = 20;
        public World()
        {
            Player = new Human("Edward Shadow ", 2, 2);
            Player.Glyph = '@';
            Console.Title = "Character: " + Player.Name + " HP: " + Player.HP + "/" + Player.MaxHP;
            CurrentLocation = new Location(50, 50);
            for (int x = 0; x < 50; x++)
            for (int y = 0; y < 50; y++)
                CurrentLocation.Tiles[x, y].AddEntity(new Floor());

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
            CurrentLocation.Spawn(Player);
            CurrentLocation.Spawn(new Somebody("loh", 2, 1));





            CurrentLocation.Tiles[25, 25].AddEntity(new TestItem());
            CurrentLocation.Tiles[4, 3].AddEntity(new Wall());
            CurrentLocation.Tiles[4, 4].AddEntity(new Wall());
            CurrentLocation.Tiles[4, 5].AddEntity(new Wall());
            CurrentLocation.Tiles[6, 5].AddEntity(new Wall());
            CurrentLocation.Tiles[6, 3].AddEntity(new Wall());
            CurrentLocation.Tiles[4, 7].AddEntity(new Wall());
            CurrentLocation.Tiles[4, 9].AddEntity(new GardeningScissors());
            CurrentLocation.Tiles[4, 8].AddEntity(new Sword());
            CurrentLocation.Tiles[4, 9].AddEntity(new Cylinder());
            CurrentLocation.Tiles[4, 9].AddEntity(new Shirt());
            CurrentLocation.Tiles[4, 9].AddEntity(new Pants());
            CurrentLocation.Tiles[4, 9].AddEntity(new Gloves());
            CurrentLocation.Tiles[4, 9].AddEntity(new Bandana());
            CurrentLocation.Tiles[4, 9].AddEntity(new Shoes());

            World.CurrentLocation.ViewMap(World.Player.X, World.Player.Y, 16);
            State = new GameMode();
            State.Output();
        }


        public override void Input(ConsoleKeyInfo key)
        {
            State.Input(key);
            State.Output();
        }

        public override void Output()
        {
        }
    }
}