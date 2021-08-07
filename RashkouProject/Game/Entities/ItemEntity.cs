namespace RashkouProject.Game.Entities
{
    public abstract class ItemEntity : Entity
    {
        public int TimeCost;
        public bool Consumable;
        public ItemType ItemType;
        public virtual void Use(CharEntity user)
        {
            
        }
        public virtual void Use(CharEntity user, int x, int y)
        {
        }
    }
}