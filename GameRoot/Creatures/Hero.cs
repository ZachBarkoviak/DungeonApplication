using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Hero
    {

        //Fields (_camelCase)

        private int _health;
        private int _maxHealth;
        private string _name;
        private int _hitChance;
        private int _block;



        //Props (PascalCase of the field)

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
                if (value > _maxHealth)
                {
                    _health = _maxHealth;
                }
                else if (value <= 0)
                {
                    _health = 1;
                }
                else
                {
                    _health = value;
                }
            }//end business rule to make sure health !> maxHealth
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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




        //Constructors / ctors
        public Hero(int maxHealth, int health, string name, int hitChance, int block)
        {
            MaxHealth = maxHealth;
            Health = health;
            Name = name;
            HitChance = hitChance;
            Block = block;
        }
        public Hero()
        {

        }


        //Methods

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Health: {Health} / {MaxHealth}\n" +
                   $"Defence: {Block}\n";
        }

        public int CalcBlock() //TODO Impliment defence stat to modify the block chance
        {
            return Block;
        }

        public int CalcHitChance()//TODO impliment chance to hit against current Monster's Block/Defense stat
        {
            return HitChance;
        }

        public int CalcDamage()
        {
            return 10; //TODO impliment damage based on weapon strength and current opponent defence
        }
    }
}
