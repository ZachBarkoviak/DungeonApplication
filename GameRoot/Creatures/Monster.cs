using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //Fields (private datatype _camelCase;)
        private int _minDamage;
        private int _maxDamage;

        //Props (public datatype PascalCaseOfCamelCase)
        public int MaxDamage 
        { 
            get { return _maxDamage; } 
            set { _maxDamage = value; } 
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > MaxDamage)
                {
                    _minDamage = MaxDamage;
                }
                else
                {
                    _minDamage = value;
                }
            }
        }


        //Constructors (public class(props)) (ctor + tab + tab for default)
        public Monster(int maxHealth, int health, string name, int hitChance, int block, int minDamage, int maxDamage) : base(maxHealth, health, name, hitChance, block)
        {

            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }

        public Monster()
        {
            Name = "Goblin";
            MaxHealth = 45;
            Health = 45;
            HitChance = 20;
            Block = 5;
        }


        //Methods

        public Monster GetMonster()
        {
            Monster spawn = new Monster();
            Random rand = new Random();

            switch (rand.Next(1, 5))
            {
                case 1:
                default:
                    spawn = new Monster(25, 25, "Goblin", 15, 2, 1, 4);
                    return spawn;
                    break;

                case 2:
                    spawn = new Monster(15, 15, "Spider", 20, 1, 1, 4);
                    return spawn;
                    break;

                case 3:
                    spawn = new Monster(30, 30, "Zombie", 35, 4, 2, 5);
                    return spawn;
                    break;

                case 4:
                    spawn = new Monster(35, 35, "Skeleton", 35, 5, 2, 6);
                    return spawn;
                    break;
            }//end switch
        }//end GetMonster()

        public Monster GetMonster(int roomNumber)
        {
            Monster spawn = new Monster();
            Random rand = new Random();
            spawn = new Monster(100, 100, "Boss", 40, 8, 5, 15);
            return spawn;
        }//end GetMonster() overload for Boss room spawn

        public override string ToString()
        {
            string description = "";
            switch (Name)
            {
                case "Skeleton":
                    description = "It's.....It's a moving pile of bones....";
                    break;

                case "Spider":
                    description = "A malevolent 8 legged creature.\n" +
                                  "When you look closer, you notice venom dripping from it's exposed fangs.";
                    break;

                case "Zombie":
                    description = "Did it just say \"BRAINS\"?\n" +
                                  "It shambles toward you, dragging one foot as it goes.\n" +
                                  "Bits of flesh and rot fall from its body with every step";
                    break;

                case "Goblin":
                default:
                    description = "A small humanoid Creature.\n" +
                        "It has a shorter-than-human stature, " +
                        "a long and hooked nose, bat-like ears, and a mischievous demeanor.";
                    break;

                case "BOSS"://TODO Do something with the Boss stuff. big baddie description
                    description = @"     YOU, ARE NOT
                                           PREPARED.";
                    break;
            }

            return $"Name: {Name}\n" +
                   $"Health: {Health}\n" +
                   $"Decription:\n{description}";
        }//end ToString() override


        public int CalcDamage(Player user)//TODO Comment out the WriteLines after testing is complete
        {
            Random rand = new Random();
            Console.WriteLine($"Hit Chance: {HitChance}");
            double chance = rand.Next(1, 101);
            Console.WriteLine($"Chance Roll: {chance}");
            int dmg = 0;
            if (chance <= HitChance)
            {
                dmg = rand.Next(MinDamage, MaxDamage + 1);
                Console.WriteLine("damage before block: " + dmg);
                Console.WriteLine("Enemy block: " + user.Block);
                dmg -= user.Block;
                Console.WriteLine("Damage after block: " + dmg);
            }
            else
            {
                dmg = 0;
            }
            return dmg;
        }//end CalcDamage();  
    }
}
