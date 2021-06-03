using System.Collections.Generic;
using RashkouProject.Game.Entities;
using RashkouProject.Mathematics;

namespace RashkouProject.Game
{
    public class TimeController
    {
        public BinaryHeap Recoveries = new BinaryHeap();
        public static int Time = 0;

        public void GetRecovery(int time, Entity entity)
        {
            Recoveries.Add(new Recovery(time, entity));
        }

        public void Execute()
        {
            Time = Recoveries.GetMin().Time;
        }
    }

    public class Recovery
    {
        public int Time;
        public Entity Subject;
        public Recovery(int time, Entity entity)
        {
            Time = TimeController.Time + time;
            Subject = entity;
        }
    }
}