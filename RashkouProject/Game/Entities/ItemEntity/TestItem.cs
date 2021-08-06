namespace RashkouProject.Game.Entities
{
    public class TestItem : ItemEntity
    {
        public TestItem()
        {
            Priority = 100;
            TimeCost = 100;
            Name = "Булочка";
            Glyph = '%';
            Consumable = true;
        }

        public override void Use(CharEntity user)
        {
            if (user.HP < user.MaxHP) 
                user.HP++;
        }
    }
}