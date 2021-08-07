namespace RashkouProject.Game.Entities
{
    public class TestItem : ItemEntity
    {
        public TestItem()
        {
            ItemType = ItemType.Food;
            Priority = 100;
            TimeCost = 100;
            Name = "Булочка";
            Glyph = ',';
            Consumable = true;
        }

        public override void Use(CharEntity user)
        {
            if (user.HP < user.MaxHP) 
                user.HP++;
        }
    }
}