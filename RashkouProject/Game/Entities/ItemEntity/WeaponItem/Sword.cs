using static System.ConsoleColor;

namespace RashkouProject.Game.Entities

{
    public class Sword : ItemEntity
    {
        public Sword() 
        {
            ItemType = ItemType.Weapon;
            Priority = 100;
            TimeCost = 100;
            Name = "Меч";
            Glyph = '/';
            Consumable = false;
            ShortDescription.PrintLine("Оружие, предназначенное для нанесения",0,0, White,Black);
            ShortDescription.PrintLine("ран",0,1, White,Black);


        }

        public override void Use(CharEntity user)
        {
        }
    }
}