namespace RashkouProject.Game.Entities
{
    public class GardeningScissors : ItemEntity
    {
        public GardeningScissors()
        {
            ItemType = ItemType.Weapon;
            Priority = 100;
            TimeCost = 100;
            Name = "Садовые ножницы";
            Glyph = '%';
            Consumable = false;
        }

        public override void Use(CharEntity user)
        {
        }
    }
}