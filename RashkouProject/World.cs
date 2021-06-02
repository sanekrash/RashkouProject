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
            Player = new Human("Mailine Vestochka", 2, 2);
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
            CurrentLocation.Spawn(new Dummy("loh", 10, 10));
            CurrentLocation.Tiles[25, 25].AddEntity(new TestItem());
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