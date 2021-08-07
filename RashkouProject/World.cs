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
            Player = new Human("Emilia", 2, 2);
            Player.Glyph = '@';
            Console.Title = "Character: " + Player.Name + " HP: " + Player.HP + "/" + Player.MaxHP;
            CurrentLocation = new Location(50, 50);
            for (int x = 0; x < 50; x++)
            for (int y = 0; y < 50; y++)
                CurrentLocation.Spawn(new Floor(x, y));


            for (int x = 0; x < 50; x++)
            {
                CurrentLocation.Spawn(new Bush(x, 0));
                CurrentLocation.Spawn(new Bush(x, 49));
            }


            for (int y = 0; y < 50; y++)
            {
                CurrentLocation.Spawn(new Bush(0, y));
                CurrentLocation.Spawn(new Bush(49, y));
            }
            for (int x = 25; x < 50; x++)
            for (int y = 25; y < 50; y++)
                CurrentLocation.Spawn(new Bush(x, y));
            CurrentLocation.Spawn(new BearTrap(10, 10));
            CurrentLocation.Spawn(new BearTrap(11, 11));



            CurrentLocation.Spawn(Player);
            CurrentLocation.Spawn(new Somebody("loh", 2, 1));





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