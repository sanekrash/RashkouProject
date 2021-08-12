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
        public List<BulletEntity> BulletEntities = new List<BulletEntity>();


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
        public void AddEntity(BulletEntity entity)
        {
            BulletEntities.Add(entity);
        }

        public void DeleteEntity(CharEntity entity)
        {
            CharEntities.Remove(entity);
        }

        public void DeleteEntity(ItemEntity entity)
        {
            ItemEntities.Remove(entity);
        }
        public void DeleteEntity(MapEntity entity)
        {
            Mapentities.Remove(entity);
        }
        public void DeleteEntity(BulletEntity entity)
        {
            BulletEntities.Remove(entity);
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
        public bool IsTransparent()
        {
            foreach (var mapEntity in Mapentities)
                if (mapEntity.Transparency == false)
                    return mapEntity.Transparency;
            foreach (var charEntity in CharEntities)
                if (charEntity.Transparency == false)
                    return charEntity.Transparency;
            return true;
        }

        public MapEntity HaveType(MapObjectType type)
        {
            foreach (var entity in Mapentities)
                if (entity.Type == type)
                    return entity;
            return null;
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
            return new(PriorityEntity().Glyph, PriorityEntity().ForGlyphColor, HaveType(MapObjectType.Floor).BackGlyphColor);
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
            foreach (var bulletEntity in BulletEntities)
            {
                entities.Add(bulletEntity);
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