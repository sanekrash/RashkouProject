using System.Collections.Generic;
using RashkouProject;
using RashkouProject.Game;
using RashkouProject.Game.Entities;
using static System.ConsoleColor;

public class Key : ItemEntity
{
    public int KeyID;

    public Key(int id)
    {
        KeyID = id;
        ItemType = ItemType.Key;
        Priority = 100;
        TimeCost = 100;
        Name = "Ключ" + id;
        Glyph = '⊸';
        Consumable = false;
    }

    public override void Use(CharEntity user)
    {
        if (user == World.Player)
            World.State = new TileChoosingMode(1, (int x, int y) =>
            {
                this.Use(user, x, y);
                World.State = new GameMode();
            }, (x, y) => { return new List<Entity>(World.CurrentLocation.Tiles[x, y].Mapentities); },
                (matrix) =>
                {
                    matrix.PrintLine("Enter - состричь куст", 2, 37, White, Black);
                    matrix.PrintLine("PageUp/Down для прокрутки страницы", 2, 38, White, Black);
                    matrix.PrintLine("/ или * для выбора страницы", 2, 39, White, Black);
                }
                );
    }

    public override void Use(CharEntity user, int x, int y)
    {
        Door entity = (Door) World.CurrentLocation.Tiles[x, y].HaveType(MapObjectType.Door);
        if (entity != null)
            if (KeyID == entity.KeyID)
                if (entity.Locked)
                {
                    entity.OpenKey();
                    if (user == World.Player)
                        World.Events.AddEvent("Вы отперли дверь");
                }
                else
                {
                    entity.LockKey();
                    if (user == World.Player)
                        World.Events.AddEvent("Вы заперли дверь");
                }

        user.AddTimeLapse(TimeCost);
    }
}