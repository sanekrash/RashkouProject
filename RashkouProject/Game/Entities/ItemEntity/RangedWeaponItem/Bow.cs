using System.Collections.Generic;
using static System.ConsoleColor;


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
                }, (matrix) =>
                    {
                        matrix.PrintLine("Enter - выстрелить", 2, 37, White, Black);
                        matrix.PrintLine("PageUp/Down для прокрутки страницы", 2, 38, White, Black);
                        matrix.PrintLine("/ или * для выбора страницы", 2, 39, White, Black);
                    }
                    );
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