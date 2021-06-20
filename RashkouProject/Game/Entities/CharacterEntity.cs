using System;
using System.Collections.Generic;
using System.Xml;
using RashkouProject.Game.Fight;
using RashkouProject.Mathematics;

namespace RashkouProject.Game.Entities
{
    public abstract class CharEntity : Entity
    {
        
        public int HP, MaxHP, MP, MaxMP;
        public int Level;
        public int Exp;
        public int Damage;
        public List<ItemEntity> Inventory = new ();
        public BinaryHeap<Entity>.Node CurrentTimeLapse;
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
            CurrentTimeLapse = World.TimeController.AddTimeLapse(100,this);
        }
        public void Wait()
        {
            CurrentTimeLapse = World.TimeController.AddTimeLapse(100,this);
        }

        public void Drop(ItemEntity entity)
        {
            World.CurrentLocation.Tiles[X,Y].AddEntity(entity);
            Inventory.Remove(entity);
        }

        public void DropAll()
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                World.CurrentLocation.Tiles[X,Y].AddEntity(Inventory[i]);
            }
            Inventory.Clear();
        }

        public void Die()
        {
            DropAll();
            CurrentTimeLapse.Remove();
            World.CurrentLocation.Despawn(this);
        }
        public void GetHit(Attack attack)
        {
            HP = HP - attack.Damage;
            if (HP <= 0)
            {
                Die();
            }
        }


    }
}   