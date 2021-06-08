using System;
using RashkouProject.Game.Fight;

namespace RashkouProject.Game.Entities.CharacterEntity
{
    public class Dummy : CharEntity
    {
        public Dummy(String name, int x, int y)
        {
            X = x;
            Y = y;
            Priority = 10000;
            HP = 100;
            MaxHP = 100;
            MP = 1;
            MaxMP = 1;
            Glyph = 'D';
            Name = name;
            Level = 1;
            Exp = 0;
            Passability = false;
        }

        public override void OnSpawn()
        {
            Wait();
        }

        public override void OnDespawn()
        {
            World.CurrentLocation.Tiles[X,Y].AddEntity(new TestItem());
        }

        public override void Act()
        {
            World.Player.GetHit(new Attack(1));
            CurrentTimeLapse = World.TimeController.AddTimeLapse(150,this);
        }
    }
}