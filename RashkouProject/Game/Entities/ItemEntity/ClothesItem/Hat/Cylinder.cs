namespace RashkouProject.Game.Entities
{
    public class Cylinder : ItemEntity
    {
        public Cylinder()
        {
            ItemType = ItemType.Hat;
            Priority = 100;
            TimeCost = 100;
            Name = "Цилиндр";
            Glyph = ']';
            Consumable = false;
        }

        public override void Use(CharEntity user)
        {
        }
    }
}