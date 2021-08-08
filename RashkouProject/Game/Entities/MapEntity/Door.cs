using System.Security.Cryptography.X509Certificates;
using static System.ConsoleColor;

namespace RashkouProject.Game.Entities
{

    public class Door : MapEntity
    {
        public int KeyID;
        public bool Closed;

        public Door(int x, int y, int id, bool closed)
        {
            KeyID = id;
            Closed = closed;
            X = x;
            Y = y;
            Type = MapObjectType.Door;
            Name = "Дверь" + id;
            ForGlyphColor = White;
            Priority = 1;
            Glyph = '▮';
            Passability = false;
        }
        public void OpenKey()
        {
            Glyph = '▯';
            Closed = false;
            Passability = true;
        }

        public void CloseKey()
        {
            Glyph = '▮';
            Closed = true;
            Passability = false;
        }
    }
}