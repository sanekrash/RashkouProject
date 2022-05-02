using System.Collections.Generic;
using static System.ConsoleColor;
using RashkouProject.Game;


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
            ShortDescription.PrintLine("Инструмент для срезки",0,0, White,Black);
            ShortDescription.PrintLine("растений. Также его можно",0,1, White,Black);
            ShortDescription.PrintLine("использовать как оружие.",0,2, White,Black);

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
                    }, (matrix) =>
                    {
                        matrix.PrintLine("Enter - состричь куст", 2, 37, White, Black);
                        matrix.PrintLine("PageUp/Down для прокрутки страницы", 2, 38, White, Black);
                        matrix.PrintLine("/ или * для выбора страницы", 2, 39, White, Black);
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