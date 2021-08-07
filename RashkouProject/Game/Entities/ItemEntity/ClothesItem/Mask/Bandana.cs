namespace RashkouProject.Game.Entities
{
    public class Bandana : ItemEntity
    {
        public Bandana()
        {
            ItemType = ItemType.Mask;
            Priority = 100;
            TimeCost = 100;
            Name = "Бандана";
            Glyph = ']';
            Consumable = false;
        }

        public override void Use(CharEntity user)
        {
        }
    }
}