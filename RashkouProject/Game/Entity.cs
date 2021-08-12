using System;
using System.Drawing;
using RashkouProject.Mathematics;

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
        public string Name = "test";
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