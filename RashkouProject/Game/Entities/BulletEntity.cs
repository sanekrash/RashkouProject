using System;

namespace RashkouProject.Game.Entities
{
    public class BulletEntity : Entity
    {
        public int Speed, LifeTime;
        public double Fx, Fy, Vx, Vy;
        

        public void Move()
        {
            AddTimeLapse(Speed);
            Fx = Fx + Vx;
            Fy = Fy + Vy;
            if (World.CurrentLocation.Tiles[(int) Math.Round(Fx), (int) Math.Round(Fy)].IsPassing() && LifeTime > 0)
            {
                World.CurrentLocation.Tiles[X, Y].DeleteEntity(this);
                X = (int) Fx;
                Y = (int) Fy;
                World.CurrentLocation.Tiles[X, Y].AddEntity(this);
                LifeTime--;
            }
            else 
                Destroy();

        }
        public void Destroy()
        {
            CurrentTimeLapse.Remove();
            World.CurrentLocation.Despawn(this);
        }
    }
}