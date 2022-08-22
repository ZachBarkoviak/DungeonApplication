using DungeonLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public ItemType Type { get; set; }

        public Item(string name, int amount, ItemType type)
        {
            Name = name;
            Amount = amount;
            Type = type;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Quantity: {Amount}\n" +
                   $"Type: {Type}\n";
        }


    }
}
