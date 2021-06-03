using RashkouProject.Game.Fight;

namespace RashkouProject.Game.Entities
{
    public abstract class CharEntity : Entity
    {
        
        public int HP, MaxHP, MP, MaxMP;
        public int Level;
        public int Exp;
        public int Damage;
        public void Move(int x, int y)
        {
            if (World.CurrentLocation.Tiles[X + x, Y + y].IsPassing())
            {
                World.CurrentLocation.Tiles[X, Y].DeleteEntity(this);
                X = X + x;
                Y = Y + y;
                World.CurrentLocation.Tiles[X, Y].AddEntity(this);
            }
            if (World.CurrentLocation.Tiles[X, Y].CharEntities.Count > 0)
            {
                foreach (var attackedEntity in World.CurrentLocation.Tiles[X + x, Y + y].CharList())
                {
                    attackedEntity.GetHit(new Attack(Damage));
                }
            }
            World.TimeController.GetRecovery(100,this);
        }
        public void Wait()
        {
            World.TimeController.GetRecovery(100,this);
        }

        public void GetHit(Attack attack)
        {
            HP = HP - attack.Damage;
            if (HP <= 0)
            {
                World.CurrentLocation.Despawn(this);
            }
        }


    }
}   