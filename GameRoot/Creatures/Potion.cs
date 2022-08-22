using DungeonLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Potion : Item
    {

        public int HealthAdjust { get; }

        public Potion(string name, int amount, ItemType type, int healthAdjust) : base(name, amount, type)
        {
            HealthAdjust = healthAdjust;
        }

        public static Potion GetPotion()
        {
            Random rand = new Random();
            Potion healing = new Potion("A glowing gold liquid.", 1, ItemType.Potion, rand.Next(1,6));
            Potion mystery = new Potion("A mysterious gray liquid", 1, ItemType.Potion,
                (rand.Next(2) == 1 ? rand.Next(3) : rand.Next(-1,-5)));
            Potion damage = new Potion("A thick red liquid.", 1, ItemType.Potion, rand.Next(-1, -7));
            
            List<Potion> potions = new List<Potion>
            {
                healing, healing, healing,
                mystery, mystery, mystery, mystery, mystery,
                damage, damage,
            };
            return potions[rand.Next(potions.Count())];
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
