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
            HP = 1;
            MaxHP = 1;
            MP = 1;
            MaxMP = 1;
            Glyph = 'h';
            Name = name;
            Level = 1;
            Exp = 0;
        }
    }
}