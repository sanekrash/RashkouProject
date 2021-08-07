namespace RashkouProject.Game.Entities
{
    public class Sword : ItemEntity
    {
        public Sword() 
        {
            ItemType = ItemType.Weapon;
            Priority = 100;
            TimeCost = 100;
            Name = "Меч";
            Glyph = '/';
            Consumable = false;
        }

        public override void Use(CharEntity user)
        {
        }
    }
}