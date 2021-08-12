using System;
using RashkouProject.Game.Fight;

namespace RashkouProject.Game.Entities.CharacterEntity
{
    public class Somebody : CharEntity
    {
        public Somebody(String name, int x, int y)
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
            Damage = 10;
            Passability = false;
            Transparency = false;
        }

        public override void OnSpawn()
        {
            Wait();
            for (int i = 0; i < 99; i++)
            {
                Inventory.Add(new Bun());
                Inventory[i].Name = i+ "Булочка";


            }

        }

        public override void OnDespawn()
        {
        }

        public override void Act()
        {
            Move(0,1);
        }
    }
}