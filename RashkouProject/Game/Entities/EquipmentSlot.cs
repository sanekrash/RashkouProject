namespace RashkouProject.Game.Entities
{
    public class EquipmentSlot
    {
        public ItemType Type;
        public ItemEntity Slot;
        public int Index;
        public string Name;
                public EquipmentSlot(ItemType type, int index, string name)
                {
                    Type = type;
                    ItemEntity Slot;
                    Index = index;
                    Name = name;
                }

    }
}