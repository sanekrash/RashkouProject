using static System.ConsoleColor;

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
            ShortDescription.PrintLine("Аппетитного вида булочка.",0,0, White,Black);
            ShortDescription.PrintLine("Она способна восстановить часть сил.",0,1, White,Black);

        }

        public override void Use(CharEntity user)
        {
            if (user == World.Player && user.HP < user.MaxHP)
                World.Events.AddEvent("Вы съели булочку и восстановили часть сил");  
            if (user == World.Player && user.HP == user.MaxHP)
                World.Events.AddEvent("Вы съели булочку");
            
            if (user.HP < user.MaxHP)
            {
                user.HP++;
            }
            user.AddTimeLapse(TimeCost);
        }
    }
}