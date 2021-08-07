namespace RashkouProject.Game.Entities
{
    public class Gloves : ItemEntity
    {
        public Gloves()
        {
            ItemType = ItemType.Gloves;
            Priority = 100;
            TimeCost = 100;
            Name = "Перчатки";
            Glyph = ']';
            Consumable = false;
        }

        public override void Use(CharEntity user)
        {
        }
    }
}