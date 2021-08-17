using RashkouProject.Game.Fight;
using static System.ConsoleColor;

namespace RashkouProject.Game.Entities
{
    public class BearTrap : MapEntity
    {
        public bool Activated;
        public BearTrap ( int x, int y)
        {
            Activated = true;
            X = x;
            Y = y;
            Type = MapObjectType.Trap;
            Name = "Медвежий капкан";
            ForGlyphColor = White;
            Priority = 100;
            Glyph = '^';
            Passability = true;
        }
        public override void OnStep(CharEntity entity)
        {
            if (Activated)
            entity.GetHit(new Attack(50));
            Activated = false;
        }
    }
}