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

        public Potion(string name, int amount, ItemType type, string description, int healthAdjust) : base(name, amount, type, description)
        {
            HealthAdjust = healthAdjust;
        }

        public static Potion GetPotion()
        {
            Random rand = new Random();
            Potion healing = new Potion("Potion of minor healing", 1, ItemType.Potion, "A glowing gold liquid.", rand.Next(1,6));
            Potion mystery = new Potion("unknown", 1, ItemType.Potion, "A mysterious gray liquid",
                (rand.Next(2) == 1 ? rand.Next(1, 5) : rand.Next(-5,-1)));
            Potion damage = new Potion("Potion of sacrifice", 1, ItemType.Potion, "A thick red liquid.", rand.Next(-7, -1));
            
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

        public override void UseItem(Player player)
        {
            Console.Clear();
            Console.Write($"Your health has {(HealthAdjust > 0 ? "increased" : "decreased")} by: {Math.Abs(HealthAdjust)} | ");
            player.Health += HealthAdjust;
            Console.WriteLine($"Your Current Health: {player.Health}");
        }

    }
}
