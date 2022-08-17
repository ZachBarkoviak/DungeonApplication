using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Character
    {

        //Fields (_camelCase)

        private int _health;
        private int _maxHealth;
        private string _name;
        private PlayerRace _race;
        private int _hitChance;
        private int _block;
        private PlayerClass _characterClass;
        private Weapon _userWeapon;



        //Props (PascalCase of the field)

        public PlayerRace Race
        {
            get { return _race; }
            set { _race = value; }
        }
        public PlayerClass CharacterClass
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
                    case (PlayerClass)1: //Barbarian
                        _maxHealth = 50;
                        break;

                    case (PlayerClass)2://Rogue
                        _maxHealth = 40;
                        break;

                    case (PlayerClass)3://Mage
                        _maxHealth = 45;
                        break;

                    case (PlayerClass)4://Depraved
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
                    case (PlayerRace)1://Elf
                        _hitChance = 45;
                        break;

                    case (PlayerRace)2://Orc
                        _hitChance = 35;
                        break;

                    case (PlayerRace)3://Human
                        _hitChance = 40;
                        break;

                    case (PlayerRace)4://Goblin
                        _hitChance = 25;
                        break;

                    case (PlayerRace)5://Tiefling
                        _hitChance = 25;
                        break;
                }
            }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }

        public Weapon UserWeapon
        {
            get { return _userWeapon; }
            set { _userWeapon = value; }
            #region Old Class based weapon choice
            //{
            //    switch (CharacterClass)
            //    {
            //        case (PlayerClass)1: //Barbarian
            //            Weapon battleAxe = new Weapon(15, 5, "Battleaxe", 5, true);
            //            _userWeapon = battleAxe;
            //            break;
            //        case (PlayerClass)2://Rogue
            //            Weapon dagger = new Weapon(8, 2, "Dagger", 10, false);
            //            _userWeapon = dagger;
            //            break;
            //        case (PlayerClass)3://Mage
            //            Weapon staff = new Weapon(11, 0, "Staff", 15, true);
            //            _userWeapon = staff;
            //            break;
            //        case (PlayerClass)4://Depraved
            //        default:
            //            Weapon club = new Weapon(5, 1, "Club", 20, true);
            //            _userWeapon = club;
            //            break;
            //    }//end weapon select switch  
            //}
            #endregion
        }




        //Constructors / ctors
        public Character(PlayerClass characterClass, Weapon userWeapon, PlayerRace race, int maxHealth, int health, string name, int hitChance, int block)
        {
            CharacterClass = characterClass;
            Race = race;
            UserWeapon = userWeapon;
            MaxHealth = maxHealth;
            Health = health;
            Name = name;
            HitChance = hitChance;
            Block = block;
            //UserWeapon = UserWeapon;
        }
        public Character()
        {

        }


        //Methods

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Health: {Health} / {MaxHealth}\n" +
                   $"Defense: {Block}\n" +//TODO Impliment Defence stat with armor and stuff
                   $"Race: {Race}\n" +
                   $"Class: {CharacterClass}\n" +
                   $"{UserWeapon}\n";
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
            Weapon item = UserWeapon;
            Random rand = new Random();
            Console.WriteLine($"Hit Chance: {HitChance}");
            Console.WriteLine($"Bonus: {item.BonusHitChance}");
            double chance = rand.Next(1, 101);
            Console.WriteLine($"Chance Roll: {chance}");
            int dmg = 0;
            if (chance <= (HitChance + item.BonusHitChance))
            {
                dmg = rand.Next(item.MinDamage, item.MaxDamage + 1);

            }
            else
            {
                dmg = 0;
            }
            return dmg;



        }//end CalcDamage();    
    }
}
