using System.Collections.Generic;
using RashkouProject;
using RashkouProject.Game;
using RashkouProject.Game.Entities;

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
            World.State = new TileChoosingMode( 1, (int x, int y) =>
            {
                this.Use(user, x, y);
                World.State = new GameMode();
            },(x, y) =>
            {
                return new List<Entity>(World.CurrentLocation.Tiles[x, y].Mapentities);
            });
    }

    public override void Use(CharEntity user, int x, int y)
    {
        Door entity = (Door)World.CurrentLocation.Tiles[x, y].HaveType(MapObjectType.Door);
        if (entity != null)
            if (KeyID == entity.KeyID)
                if (entity.Locked)
                    entity.OpenKey();
                else
                    entity.LockKey();
        user.AddTimeLapse(TimeCost);
    }
}