namespace RashkouProject.Game.Entities
{
    public abstract class MapEntity : Entity
    {
        public MapObjectType Type;
        
        public void Destroy() => World.CurrentLocation.Despawn(this);


        public virtual void OnStep(CharEntity entity)
        {
            
        }
    }
}