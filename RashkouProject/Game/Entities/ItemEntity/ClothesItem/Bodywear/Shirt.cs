namespace RashkouProject.Game.Entities
{
    public class Shirt : ItemEntity
    {
        public Shirt()
        {
            ItemType = ItemType.Bodywear;
            Priority = 100;
            TimeCost = 100;
            Name = "Рубашка";
            Glyph = ']';
            Consumable = false;
        }
    }
}