using System;
using System.Collections.Generic;
using RashkouProject.Game.Entities;

namespace RashkouProject.Game
{
    public class EventList
    {
        public List<String> Events = new List<String>();

        public void AddEvent(String description)
        {
            Events.Add(description);
        }
    }
}