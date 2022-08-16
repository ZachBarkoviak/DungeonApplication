using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    internal class MonsterDraft
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

        //Methods





    }
}
