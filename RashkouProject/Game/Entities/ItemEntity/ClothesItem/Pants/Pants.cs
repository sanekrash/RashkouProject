namespace RashkouProject.Game.Entities
{
    public class Pants : ItemEntity
    {
        public Pants()
        {
            ItemType = ItemType.Pants;
            Priority = 100;
            TimeCost = 100;
            Name = "Брюки";
            Glyph = ']';
            Consumable = false;
        }
    }
}