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
            Passability = false;
            Transparency = false;
        }
        public void OpenKey()
        {
            Glyph = '▯';
            Locked = false;
            Passability = true;
            Transparency = true;
        }

        public void CloseKey()
        {
            Glyph = '▮';
            Locked = true;
            Passability = false;
            Transparency = false;

        }
    }
}