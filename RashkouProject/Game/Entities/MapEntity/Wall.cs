namespace RashkouProject.Game.Entities
{
    public class Wall : MapEntity
    {
        public Wall()
        {
            Name = "Стена";
            Priority = 1;
            Glyph = '#';
            Passability = false;
        }
    }
}