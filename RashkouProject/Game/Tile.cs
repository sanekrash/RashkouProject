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
        public List<ItemEntity> ItemEntities = new List<ItemEntity>();


        public void AddEntity(MapEntity entity)
        {
            Mapentities.Add(entity);
        }
        public void AddEntity(CharEntity entity)
        {
            CharEntities.Add(entity);
        }
        public void AddEntity(ItemEntity entity)
        {
            ItemEntities.Add(entity);
        }
        public void DeleteEntity(CharEntity entity)
        {
            CharEntities.Remove(entity);
        }

        public bool IsPassing()
        {
            foreach (var mapEntity in Mapentities)
                if (mapEntity.Passability == false)
                    return mapEntity.Passability;
            foreach (var charEntity in CharEntities)
                if (charEntity.Passability == false)
                    return charEntity.Passability;

            return true;
        }
        public List<CharEntity> CharList()
        {
            List<CharEntity> charEntities = new List<CharEntity>(); 
            foreach (var charEntity in CharEntities)
            {
                charEntities.Add(charEntity);
            }
            return charEntities;
        }

        public Char PrintTile()
        {
            return new(PriorityEntity().Glyph, White, Black);
        }

        public List<Entity> ReturnEntities()
        {
            var entities = new List<Entity>();
            int priority = -1;
            foreach (var mapEntity in Mapentities)
            {
                entities.Add(mapEntity);
            }
            foreach (var itemEntity in ItemEntities)
            {
                entities.Add(itemEntity);
            }
            foreach (var charentity in CharEntities)
            {
                entities.Add(charentity);
            }
            return entities;
        }
        public Entity PriorityEntity()
        {

            Entity returnentity = null;
            int priority = -1;
            foreach (var entity in ReturnEntities())
            {
                if (entity.Priority > priority)
                {
                    priority = entity.Priority;
                    returnentity = entity;
                }
            }
            return returnentity;
        }

    }
}