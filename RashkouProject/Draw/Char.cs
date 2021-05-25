using System;

namespace RashkouProject.Draw
{
    public struct Char
    {
        public Char(char glyph, ConsoleColor forColor, ConsoleColor backColor)
        {
            Glyph = glyph;
            ForColor = forColor;
            BackColor = backColor;
        }

        public char Glyph;
        public ConsoleColor ForColor;
        public ConsoleColor BackColor;
    }
}