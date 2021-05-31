namespace RashkouProject.Game.Entities
{
    public abstract class CharEntity : Entity
    {
        public int HP, MaxHP;
        public int Level;
        public string Name;

        public void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}   