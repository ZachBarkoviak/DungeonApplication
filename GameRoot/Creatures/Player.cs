using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {

        //Fields (_camelCase)

        private PlayerRace _race;
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
        public Player(int maxHealth, int health, string name, int hitChance, int block, PlayerClass characterClass, Weapon userWeapon, PlayerRace race) : base(maxHealth, health, name, hitChance, block)
        {
            CharacterClass = characterClass;
            Race = race;
            UserWeapon = userWeapon;
            switch (Race) //TODO make these increase the current stat (you only make one player so when you make it, just put in the base values and let the constructor adjust them)
                //Just make hit chance increase with the weapon bonus. keep it a default for the character stat.
            {
                case PlayerRace.Elf:
                    HitChance = 45;
                    break;

                case PlayerRace.Orc:
                    HitChance = 35;
                    break;

                case PlayerRace.Human:
                    HitChance = 40;
                    break;

                case PlayerRace.Goblin:
                    HitChance = 25;
                    break;

                case PlayerRace.Tiefling:
                    HitChance = 25;
                    break;
                #region Secrets
                case PlayerRace.Developer:
                    HitChance = 50;
                    break;
                    #endregion
            }//end HitChance switch
            switch (CharacterClass)
            {
                case PlayerClass.Barbarian:
                    MaxHealth = 50;
                    Block = 10;
                    break;

                case PlayerClass.Rogue:
                    MaxHealth = 40;
                    Block = 5;
                    break;

                case PlayerClass.Mage:
                    MaxHealth = 45;
                    Block = 4;
                    break;

                case PlayerClass.Depraved:
                    MaxHealth = 30;
                    Block = 2;
                    break;
                #region Secrets
                case PlayerClass.FrontEndMaster:
                    MaxHealth = 100;
                    Block = 15;
                    break;
                    #endregion
            }//end MaxHealth/Block switch 
            Health = health;
        }

        public Player()
        {

        }

        //Methods

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Health: {Health} / {MaxHealth}\n" +
                   $"Defense: {Block}\n" +
                   $"Race: {Race}\n" +
                   $"Class: {CharacterClass}\n" +
                   $"{UserWeapon}\n";
        }

       public int CalcBlock()         
        {                               
            return Block;               
        }                               
                                        
        public int CalcHitChance()      
        {                               
            return HitChance;           
        }                               

        public override int CalcDamage(Monster enemy)
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
                Console.WriteLine("damage before block: " + dmg);
                Console.WriteLine("Enemy block: " + enemy.Block);
                dmg -= enemy.Block;
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
