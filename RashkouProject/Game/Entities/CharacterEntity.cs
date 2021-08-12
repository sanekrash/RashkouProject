using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using RashkouProject.Game.Fight;
using RashkouProject.Mathematics;

namespace RashkouProject.Game.Entities
{
    public abstract class CharEntity : Entity
    {
        public int HP, MaxHP, MP, MaxMP;
        public int Level;
        public int Exp;
        public int Damage;
        public int SightRadius = 16;
        public List<ItemEntity> Inventory = new();

        public List<EquipmentSlot> EquipmentSlots = new()
        {
            new EquipmentSlot(ItemType.Weapon, 0, "Оружие"),
            new EquipmentSlot(ItemType.Bodywear, 1, "Одежда"),
            new EquipmentSlot(ItemType.Pants, 2, "Штаны"),
            new EquipmentSlot(ItemType.Shoes, 3, "Ботинки"),
            new EquipmentSlot(ItemType.Gloves, 4, "Перчатки"),
            new EquipmentSlot(ItemType.Mask, 5, "Маска"),
            new EquipmentSlot(ItemType.Hat, 6, "Головной убор")
        };


        public void Move(int x, int y)
        {
            if (World.CurrentLocation.Tiles[X + x, Y + y].IsPassing())
            {
                World.CurrentLocation.Tiles[X, Y].DeleteEntity(this);
                X = X + x;
                Y = Y + y;
                World.CurrentLocation.Tiles[X, Y].AddEntity(this);
                foreach (var mapentity in World.CurrentLocation.Tiles[X, Y].Mapentities)
                {
                    mapentity.OnStep(this);
                }
            }
            else if (World.CurrentLocation.Tiles[X, Y].CharEntities.Count > 0)
            {
                foreach (var attackedEntity in World.CurrentLocation.Tiles[X + x, Y + y].CharList())
                {
                    attackedEntity.GetHit(new Attack(Damage));
                }
            }

            AddTimeLapse(100);
        }

        public void Wait()
        {
            AddTimeLapse(100);
        }

        public void Pickup(ItemEntity entity)
        {
            Inventory.Add(entity);
            World.CurrentLocation.Tiles[X, Y].DeleteEntity(entity);
            AddTimeLapse(100);

        }

        public void Drop(ItemEntity entity)
        {
            World.CurrentLocation.Tiles[X, Y].AddEntity(entity);
            Inventory.Remove(entity);
            AddTimeLapse(100);
        }

        public void Use(ItemEntity entity)
        {
            entity.Use(this);
            if (entity.Consumable)
                Inventory.Remove(entity);
        }

        public void Throw(ItemEntity entity, int x, int y)
        {
            World.CurrentLocation.Spawn(new ThrowedItem(X, Y, x, y, 25, 12, entity));
            Inventory.Remove(entity);
            AddTimeLapse(100);
        }

        public void Equip(ItemEntity entity)
        {
            foreach (var slot in EquipmentSlots)
            {
                if (entity.ItemType == slot.Type)
                {
                    if (slot.Slot != null)
                        Inventory.Add(slot.Slot);
                    slot.Slot = entity;
                    Inventory.Remove(entity);
                }
            }
        }

        public void UnEquip(EquipmentSlot slot)
        {
            if (slot.Slot != null)
            {
                Inventory.Add(slot.Slot);
                slot.Slot = null;
            }
        }

        public void DropAll()
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                World.CurrentLocation.Tiles[X, Y].AddEntity(Inventory[i]);
            }

            Inventory.Clear();
        }

        public void Die()
        {
            DropAll();
            CurrentTimeLapse.Remove();
            World.CurrentLocation.Despawn(this);
        }

        public void GetHit(Attack attack)
        {
            HP = HP - attack.Damage;
            if (HP <= 0)
            {
                Die();
            }
        }
    }
}