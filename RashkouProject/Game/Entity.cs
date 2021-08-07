using System;
using System.Drawing;

namespace RashkouProject.Game
{
    public abstract class Entity
    {
        public int Priority;
        public char Glyph;
        public ConsoleColor ForGlyphColor = ConsoleColor.White;
        public ConsoleColor BackGlyphColor = ConsoleColor.Black;
        public int X, Y;
        public bool Passability;
        public string Name = "test";

        public virtual void OnSpawn()
        {
        }
        public virtual void OnDespawn()
        {
        }
        public virtual void Act()
        {
        }
    }
}