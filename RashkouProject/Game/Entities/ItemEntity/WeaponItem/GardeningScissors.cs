using System.Collections.Generic;

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
                World.State = new TileChoosingMode(1,
                    (int x, int y) =>
                    {
                        this.Use(user, x, y); 
                        World.State = new GameMode();
                    },
                    (x, y) =>
                    {
                        return new List<Entity>(World.CurrentLocation.Tiles[x, y].Mapentities);
                    });
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