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

        //Props (public datatype PascalCaseOfCamelCase)
        public int MaxDamage { get; set; }
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
        public string Description { get; set; }


        //Constructors (public class(props)) (ctor + tab + tab for default)
        public Monster(int maxHealth, int health, string name, int hitChance, int block, int minDamage, int maxDamage, string description) : base(maxHealth, health, name, hitChance, block)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
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

        public static Monster GetMonster()
        {
            #region Descriptions
            string dSkeleton = "It's.....It's a moving pile of bones....";
            string dSpider = "A malevolent 8 legged creature.\n" +
                                  "When you look closer, you notice venom dripping from it's exposed fangs.";
            string dZombie = "Did it just say \"BRAINS\"?\n" +
                                  "It shambles toward you, dragging one foot as it goes.\n" +
                                  "Bits of flesh and rot fall from its body with every step";
            string dGoblin = "A small humanoid Creature.\n" +
                        "It has a shorter-than-human stature, " +
                        "a long and hooked nose, bat-like ears, and a mischievous demeanor.";

            #endregion
            Monster goblin = new Monster(30, 30, "Goblin", 50, 5, 2, 4, dGoblin);
            Monster spider = new Monster(20, 20, "Spider", 45, 4, 2, 5, dSpider);
            Monster zombie = new Monster(35, 35, "Zombie", 55, 7, 2, 6, dZombie);
            Monster skeleton = new Monster(40, 40, "Skeleton", 60, 8, 3, 8, dSkeleton);

            List<Monster> monsters = new List<Monster>
            {
                goblin, goblin, goblin,
                spider, spider, spider, spider, spider,
                zombie, zombie,
                skeleton,
            };
            return monsters[new Random().Next(monsters.Count())];

        }//end GetMonster()

        public static Monster GetBoss()
        {
            string dBoss = "YOU ARE NOT PREPARED!";
            Monster spawn = new Monster(100, 100, "Boss", 40, 8, 5, 15, dBoss);          
            return spawn;
        }//end GetBoss()

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Health: {Health}\n" +
                   $"Decription:\n{Description}";
        }//end ToString() override


        public override int CalcDamage()//TODO Comment out the WriteLines after testing is complete
        {
            int dmg = new Random().Next(MinDamage, MaxDamage + 1);
            return dmg;
        }//end CalcDamage();  
    }
}
