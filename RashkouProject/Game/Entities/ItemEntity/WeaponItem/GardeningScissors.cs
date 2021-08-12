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
            if (user == World.Player)
                World.State = new TileChoosingMode(this, user, 1, Command.Use);
        }

        public override void Use(CharEntity user, int x, int y)
        {
            var entity = World.CurrentLocation.Tiles[x, y].HaveType(MapObjectType.Bush);
            if (entity != null)
            {
                entity.Destroy();
                user.AddTimeLapse(TimeCost);
            }
        }
    }
}