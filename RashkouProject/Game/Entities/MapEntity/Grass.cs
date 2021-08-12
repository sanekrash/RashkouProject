using System;
using static System.ConsoleColor;

namespace RashkouProject.Game.Entities
{
    public class Grass : MapEntity
    {
        public Grass( int x, int y)
        {
            X = x;
            Y = y;
            Type = MapObjectType.Floor;
            ForGlyphColor = Green;
            BackGlyphColor = DarkGray;
            Name = "Трава";
            Priority = 0;
            Glyph = ',';
            Passability = true;
        }
    }
}