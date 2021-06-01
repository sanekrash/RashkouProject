namespace RashkouProject.Game.Entities
{
    public class Wall : MapEntity
    {
        public Wall()
        {
            Priority = 1;
            Glyph = '#';
            Passability = false;
        }
    }
}