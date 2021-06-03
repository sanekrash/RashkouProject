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
            Recoveries.List[0].Subject.Act();
            Time = Recoveries.GetMin().Time;
        }

        public void ExecuteUntil(Entity entity)
        {
            while (true)
            {
                Time = Recoveries.List[0].Time;
                var subject = Recoveries.GetMin();
                subject.Subject.Act();
                if (subject.Subject == World.Player) 
                    return;
            }
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