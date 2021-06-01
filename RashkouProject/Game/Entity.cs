namespace RashkouProject.Game
{
    public abstract class Entity
    {
        public int Priority;
        public char Glyph;
        public int X, Y;
        public virtual void OnSpawn()
        {
        }
    }
}