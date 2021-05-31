namespace RashkouProject.Game.Entities
{
    public class Floor : MapEntity
    {
        public Floor()
        {
            Priority = 0;
            Glyph = '.';
            Passability = true;
        }
    }
}