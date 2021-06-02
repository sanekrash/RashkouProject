namespace RashkouProject.Game
{
    public abstract class Entity
    {
        public int Priority;
        public char Glyph;
        public int X, Y;
        public bool Passability;

        public virtual void OnSpawn()
        {
        }
        public virtual void OnDespawn()
        {
        }
    }
}