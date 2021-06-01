namespace RashkouProject.Game.Entities
{
    public abstract class CharEntity : Entity
    {
        public int HP, MaxHP, MP, MaxMP;
        public int Level;
        public int Exp;
        public string Name;

        public void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}   