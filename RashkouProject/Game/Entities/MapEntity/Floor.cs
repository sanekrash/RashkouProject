namespace RashkouProject.Game.Entities
{
    public class Floor : MapEntity
    {
        public Floor( int x, int y)
        {
            X = x;
            Y = y;
            Type = MapObjectType.Floor;
            Name = "Пол";
            Priority = 0;
            Glyph = '.';
            Passability = true;
        }
    }
}