namespace RashkouProject.Game.Entities
{
    public class Wall : MapEntity
    {
        public Wall( int x, int y)
        {
            X = x;
            Y = y;
            Type = MapObjectType.Wall;
            Name = "Стена";
            Priority = 1;
            Glyph = '■';
            Passability = false;
            Transparency = false;
        }
    }
}