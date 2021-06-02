namespace RashkouProject.Game.Entities
{
    public class Floor : MapEntity
    {
        public Floor()
        {
            Name = "Пол";
            Priority = 0;
            Glyph = '.';
            Passability = true;
        }
    }
}