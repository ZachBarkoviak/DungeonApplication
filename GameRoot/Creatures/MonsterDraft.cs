using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class MonsterDraft
    {
        //Fields (private datatype _camelCase;)
        private int _health;
        private int _maxHealth;
        private string _name;
        private string _type;
        private int _hitChance;
        private int _block;

        //Props (public datatype PascalCaseOfCamelCase)
        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }
        public int Health
        {
            get { return _health; }
            set 
            {
                if (value > MaxHealth)
                {
                    _health = MaxHealth;
                }
                else
                {
                    _health = value;
                }
            }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }


        //Constructors (public class(props)) (ctor + tab + tab for default)
        public MonsterDraft(int maxHealth, int health, string name, string type, int hitChance, int block)
        {
            MaxHealth = maxHealth;
            Health = health;
            Name = name;
            Type = type;
            HitChance = hitChance;
            Block = block;
        }

        public MonsterDraft()
        {
            Name = "Goblin";
            MaxHealth = 45;
            Health = 45;
            Type = "Goblin";
            HitChance = 20;
            Block = 5;
        }


        //Methods

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

                case "BOSS"://TODO Do something with the Boss stuff. big baddie description
                    description = @"     YOU, ARE NOT
                                           PREPARED.";
                    break;
                case "Goblin":
                default:
                    description = "A small humanoid Creature.\n" +
                        "It has a shorter-than-human stature, " +
                        "a long and hooked nose, bat-like ears, and a mischievous demeanor.";
                    break;
            }

            return $"Name: {Name}\n" +
                   $"Health: {Health}\n" +
                   $"Decription:\n{description}";
        }



    }
}
