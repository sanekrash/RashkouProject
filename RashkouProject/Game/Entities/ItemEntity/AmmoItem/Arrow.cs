using static System.ConsoleColor;

namespace RashkouProject.Game.Entities
{
    public class Arrow : ItemEntity
    {
        public Arrow()
        {
            ItemType = ItemType.Arrow;
            Priority = 100;
            TimeCost = 100;
            Name = "Стрела";
            Glyph = '-';
            Consumable = false;
            ShortDescription.PrintLine("Предназначенный для лука снаряд.",0,0, White,Black);

        }
        
    }
}