using System;
using System.Collections.Generic;
using RashkouProject.Game.Entities;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject.Game
{
    public class ContainsEntity
    {
        public List<MapEntity> Mapentities = new List<MapEntity>();

        public void AddEntity(MapEntity entity)
        {
            Mapentities.Add(entity);
        }

        public Char PrintTile()
        {
            int priority = 0;
  /*          foreach (var entity in Mapentities)
            {
                if (entity.Priority > priority)
                {
                    priority = entity.Priority;
                }
            } */

            return (new Char(' ', Black, Black));
        }
    }
}