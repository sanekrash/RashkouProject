using System.Collections.Generic;


namespace RashkouProject.Game.Entities
{
    public class Bow : ItemEntity
    {
        public Bow()
        {
            ItemType = ItemType.RangedWeapon;
            Priority = 100;
            TimeCost = 100;
            Name = "Лук";
            Glyph = ')';
            Consumable = false;
        }
        public override void Use(CharEntity user)
        {
            if (user == World.Player)
                World.State = new TileChoosingMode( World.Player.SightRadius, (int x, int y) =>
                {
                    Use(user, x, y); 
                    World.State = new GameMode();
                },(x, y) =>
                {
                    return new List<Entity>(World.CurrentLocation.Tiles[x, y].ReturnEntities());
                });
        }
        public override void Use(CharEntity user, int x, int y)
        {
            foreach (var entity in user.Inventory)
            {
                if (entity.ItemType == ItemType.Arrow)
                {
                    user.Throw(entity, x, y, 10, 20, 50, "Летящая стрела");
                    return;
                }
            }
        }
    }
}