using System.Collections.Generic;
using RashkouProject.Game.Entities;
using RashkouProject.Mathematics;

namespace RashkouProject.Game
{
    public class TimeController
    {
        public BinaryHeap<Entity> TimeLapseList = new BinaryHeap<Entity>();
        public static int Time = 0;

        public BinaryHeap<Entity>.Node AddTimeLapse(int time, Entity entity)
        {
            return TimeLapseList.Add(entity, Time + time);
        }

        public void Execute()
        {
            TimeLapseList.GetMin().Data.Act();
            TimeLapseList.GetMin().Remove(); 
            Time = TimeLapseList.GetMin().Priority;
        }


        public void ExecuteUntil(Entity entity)
        {
            while (true)
            {
                var subject = TimeLapseList.GetMin();
                Time = TimeLapseList.GetMin().Priority;
                TimeLapseList.GetMin().Remove();
                subject.Data.Act();
                if (subject.Data == World.Player) 
                    return;
            }
        }


    }


}