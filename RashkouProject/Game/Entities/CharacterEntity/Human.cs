using System;

namespace RashkouProject.Game.Entities.CharacterEntity
{
    public class Human : CharEntity
    {
        public Human(String name, int x, int y)
        {
            X = x;
            Y = y;
            Priority = 10000;
            HP = 100;
            MaxHP = 100;
            MP = 1;
            MaxMP = 1;
            Glyph = 'd';
            Name = name;
            Level = 1;
            Exp = 0;
            Passability = false;
            Damage = 100;
            Transparency = false;
        }
    }
}