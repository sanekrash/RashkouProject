namespace RashkouProject.Game.Entities
{
    public class Lattice : MapEntity
    {
        public Lattice( int x, int y)
        {
            X = x;
            Y = y;
            Type = MapObjectType.Lattice;
            Name = "Решетка";
            Priority = 1;
            Glyph = '#';
            Passability = false;
            Transparency = true;
        }
    }
}