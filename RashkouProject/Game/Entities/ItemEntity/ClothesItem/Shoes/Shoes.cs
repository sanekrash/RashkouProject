using RashkouProject.Game.Entities;

namespace RashkouProject.Game.Entities
{
    public class Shoes : ItemEntity
    {
        public Shoes()
        {
            ItemType = ItemType.Shoes;
            Priority = 100;
            TimeCost = 100;
            Name = "Туфли";
            Glyph = ']';
            Consumable = false;
        }
    }
}