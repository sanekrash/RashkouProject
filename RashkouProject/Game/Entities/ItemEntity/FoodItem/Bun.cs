namespace RashkouProject.Game.Entities
{
    public class Bun : ItemEntity
    {
        public Bun()
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
            user.AddTimeLapse(TimeCost);
        }
    }
}