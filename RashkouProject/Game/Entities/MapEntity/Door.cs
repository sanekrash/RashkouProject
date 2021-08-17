using System.Security.Cryptography.X509Certificates;
using static System.ConsoleColor;

namespace RashkouProject.Game.Entities
{
    public class Door : MapEntity
    {
        public int KeyID;
        public bool Locked;

        public Door(int x, int y, int id, bool locked)
        {
            KeyID = id;
            Locked = locked;
            X = x;
            Y = y;
            Type = MapObjectType.Door;
            Name = "Дверь" + id;
            ForGlyphColor = White;
            Priority = 1;
            Glyph = '▮';
            Locked = true;
            Passability = false;
            Transparency = false;
        }

        public override void Activate(CharEntity entity)
        {
            if (!Locked)
                if (Passability)
                {
                    Passability = false;
                    Glyph = '▮';
                }
                else
                {
                    Passability = true;
                    Glyph = '▯';
                }
        }

        public void OpenKey()
        {
            if (!Passability)
                Locked = false;
        }

        public void LockKey()
        {
            if (!Passability)
                Locked = true;
        }
    }
}