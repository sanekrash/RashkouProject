using RashkouProject;
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
            World.State = new TileChoosingMode(this, user, 1, Command.Use);
    }

    public override void Use(CharEntity user, int x, int y)
    {
        Door entity = (Door) World.CurrentLocation.Tiles[x, y].HaveType(MapObjectType.Door);
            if (entity != null)
                if (KeyID == entity.KeyID)
                    if (entity.Locked)
                        entity.OpenKey();
                    else
                        entity.CloseKey();
            user.AddTimeLapse(TimeCost);
    }
}