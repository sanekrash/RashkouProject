using System;

namespace RashkouProject.Game.Entities
{
    public class Bush: MapEntity
    {
        public Bush ( int x, int y)
        {
            X = x;
            Y = y;
            Type = MapObjectType.Bush;
            Name = "Кустарник";
            ForGlyphColor = ConsoleColor.Green;
            Priority = 1;
            Glyph = '♤';
            Passability = false;
            Transparency = false;
        }

    }
}