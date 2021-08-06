namespace RashkouProject.Game.Entities
{
    public abstract class ItemEntity : Entity
    {
        public int TimeCost;
        public bool Consumable;
        public virtual void Use(CharEntity user)
        {
        }
    }
}