using System;
using System.Collections.Generic;
using RashkouProject.Game.Entities;
using static System.ConsoleColor;
using Char = RashkouProject.Draw.Char;

namespace RashkouProject.Game
{
    public class Tile
    {
        public List<MapEntity> Mapentities = new List<MapEntity>();
        public List<CharEntity> CharEntities = new List<CharEntity>();


        public void AddEntity(MapEntity entity)
        {
            Mapentities.Add(entity);
        }
        public void AddEntity(CharEntity entity)
        {
            CharEntities.Add(entity);
        }
        public void DeleteEntity(CharEntity entity)
        {
            CharEntities.Remove(entity);
        }

        public bool IsPassing()
        {
            foreach (var mapEntity in Mapentities)
            {
                if (mapEntity.Passability == false)
                {
                    return mapEntity.Passability;
                }
            }

            return true;
        }

        public Char PrintTile()
        {
            int priority = -1;
            char glyph = ' ';
            foreach (var mapEntity in Mapentities)
            {
                if (mapEntity.Priority > priority)
                {
                    priority = mapEntity.Priority;
                    glyph = mapEntity.Glyph;
                }
            }
            foreach (var charEnrtity in CharEntities)
            {
                if (charEnrtity.Priority > priority)
                {
                    priority = charEnrtity.Priority;
                    glyph = charEnrtity.Glyph;
                }
            }

            return (new Char(glyph, White, Black));
        }
    }
}