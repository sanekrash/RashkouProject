using RashkouProject.Game.Fight;

namespace RashkouProject.Game.Entities
{
    public abstract class CharEntity : Entity
    {
        
        public int HP, MaxHP, MP, MaxMP;
        public int Level;
        public int Exp;
        public int Damage;
        public string Name;
        public void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public void GetHit(Attack attack)
        {
            HP = HP - attack.Damage;
            if (HP == 0)
            {
                World.CurrentLocation.Despawn(this);
            }
        }

        public void MoveUp()
        {
            if (World.CurrentLocation.Tiles[X, Y - 1].IsPassing())
            {
                World.CurrentLocation.Tiles[X, Y].DeleteEntity(this);
                MoveTo(X, Y - 1);
                World.CurrentLocation.Tiles[X, Y].AddEntity(this);
            }

            if (World.CurrentLocation.Tiles[X, Y - 1].CharEntities.Count > 0)
            {
                foreach (var attackedEntity in World.CurrentLocation.Tiles[X, Y - 1].CharList())
                {
                    attackedEntity.GetHit(new Attack(Damage));
                }
            }
            
            
        }
        public void MoveLeft()
        {
            if (World.CurrentLocation.Tiles[X - 1, Y].IsPassing())
            {
                World.CurrentLocation.Tiles[X, Y].DeleteEntity(this);
                MoveTo(X - 1, Y);
                World.CurrentLocation.Tiles[X, Y].AddEntity(this);
            }
            if (World.CurrentLocation.Tiles[X - 1, Y].CharEntities.Count > 0)
            {
                foreach (var attackedEntity in World.CurrentLocation.Tiles[X - 1, Y].CharList())
                {
                    attackedEntity.GetHit(new Attack(Damage));
                }
            }
        }
        
        public void MoveRight()
        {
            if (World.CurrentLocation.Tiles[X + 1, Y].IsPassing())
            {
                World.CurrentLocation.Tiles[X, Y].DeleteEntity(this);
                MoveTo(X + 1, Y);
                World.CurrentLocation.Tiles[X, Y].AddEntity(this);
            }
            if (World.CurrentLocation.Tiles[X + 1, Y].CharEntities.Count > 0)
            {
                foreach (var attackedEntity in World.CurrentLocation.Tiles[X + 1, Y].CharList())
                {
                    attackedEntity.GetHit(new Attack(Damage));
                }
            }
        }
        public void MoveDown()
        {
            if (World.CurrentLocation.Tiles[X, Y + 1].IsPassing() == true)
            {
                World.CurrentLocation.Tiles[X, Y].DeleteEntity(this);
                MoveTo(X, Y + 1);
                World.CurrentLocation.Tiles[X, Y].AddEntity(this);
            }
            if (World.CurrentLocation.Tiles[X, Y + 1].CharEntities.Count > 0)
            {
                foreach (var attackedEntity in World.CurrentLocation.Tiles[X, Y + 1].CharList())
                {
                    attackedEntity.GetHit(new Attack(Damage));
                }
            }
        }



 
    }
}   