using System;

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
    }
}