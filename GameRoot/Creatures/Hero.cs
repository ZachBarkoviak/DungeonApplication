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
        private string _race;
        private int _hitChance;
        private int _block;
        private string _characterClass;



        //Props (PascalCase of the field)

        public string Race
        {
            get { return _race; }
            set { _race = value; }
        }
        public string CharacterClass
        {
            get { return _characterClass; }
            set { _characterClass = value; }
        }
        public int MaxHealth
        {
            get { return _maxHealth; }
            set
            {
                switch (CharacterClass)
                {
                    case "Barbarian":
                        _maxHealth = 50;
                        break;

                    case "Rogue":
                        _maxHealth = 40;
                        break;

                    case "Mage":
                        _maxHealth = 45;
                        break;

                    case "Depraved":
                        _maxHealth = 30;
                        break;
                }//end max health switch            
            }
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
            set
            {
                switch (Race)
                {
                    case "Elf":
                        _hitChance = 70;
                        break;

                    case "Orc":
                        _hitChance = 65;
                        break;

                    case "Human":
                        _hitChance = 60;
                        break;

                    case "Goblin"://TODO ?Maybe this race will impact the hit chance against it bc it's "friendly" to monsters?
                        _hitChance = 55;
                        break;
                }
            }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }




        //Constructors / ctors
        public Hero(string characterClass, string race, int maxHealth, int health, string name, int hitChance, int block)
        {
            CharacterClass = characterClass;
            Race = race;
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
                   $"Defence: {Block}\n" +//TODO Impliment Defence stat with armor and stuff
                   $"Race: {Race}\n" +
                   $"Class: {CharacterClass}\n";
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
            Weapon item = new Weapon(10, 2, "Staff", 10, true);
            Random rand = new Random();
            int chance = (100 / (item.BonusHitChance + HitChance));
            int dmg = 1;
            if (item.Name == "staff")
            {

            }

            return dmg; //TODO impliment damage based on weapon strength and current opponent defence

    }
}