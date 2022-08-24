using DungeonLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public ItemType Type { get; set; }
        public string Description { get; set; }

        public Item(string name, int amount, ItemType type, string description)
        {
            Name = name;
            Amount = amount;
            Type = type;
            Description = description;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Quantity: {Amount}\n" +
                   $"Type: {Type}\n" +
                   $"Description: {Description}\n";
        }

        public abstract void UseItem(Player player);
    }
}
