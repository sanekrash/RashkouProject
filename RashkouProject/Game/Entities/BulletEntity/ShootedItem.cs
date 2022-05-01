using System;

namespace RashkouProject.Game.Entities
{
    public class ShootedItem : BulletEntity
    {
        public ItemEntity Item;

        public ShootedItem(int x, int y, int x1, int y1, int speed, int lifeTime, int damage, ItemEntity itemEntity, string name)
        {
            Priority = 125;
            Name = name;
            X = x;
            Y = y;
            LifeTime = lifeTime;
            Damage = damage;
            Speed = speed;
            Fx = X;
            Fy = Y;
            double l = Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2));
            if (l != 0)
            {
                Vx = (x1 - x) / l;
                Vy = (y1 - y) / l;
            }
            else
            {
                LifeTime = 0;
            }
            Glyph = itemEntity.Glyph;
            Item = itemEntity;
        }

        public override void OnSpawn()
        {
            Move();
        }

        public override void Act()
        {
            Move();
        }

        public override void OnDespawn()
        {
            World.CurrentLocation.Tiles[X, Y].AddEntity(Item);
        }
    }
}