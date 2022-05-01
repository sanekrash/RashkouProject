using System;
using System.Drawing;
using RashkouProject.Draw;
using RashkouProject.Mathematics;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

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
        public bool Transparency = true;
        public string Name = "blank";
        public Matrix ShortDescription = new Matrix(39, 13, new Char(' ', Black, Black));
        public BinaryHeap<Entity>.Node CurrentTimeLapse;


        public virtual void OnSpawn()
        {
        }
        public virtual void OnDespawn()
        {
        }
        public virtual void Act()
        {
        }
        public void AddTimeLapse(int number)
        {
            CurrentTimeLapse = World.TimeController.AddTimeLapse(number, this);
            if (this == World.Player)
                World.TimeController.ExecuteUntil(World.Player);
        }
    }
}