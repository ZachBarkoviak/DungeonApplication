using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
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
            switch (Race)
            {
                case PlayerRace.Elf:
                    HitChance += 5;
                    break;

                case PlayerRace.Orc:
                    HitChance -= 4;
                    Block += 5;
                    break;

                case PlayerRace.Human:
                    HitChance += 2;
                    break;

                case PlayerRace.Goblin:
                    MaxHealth -= 5;
                    Health -= 5;
                    break;

                case PlayerRace.Tiefling:
                    HitChance += 5;
                    Block += 2;
                    break;
                #region Secrets
                case PlayerRace.Developer:
                    HitChance += 5;
                    Name = "Spencer";
                    break;
                    #endregion
            }//end HitChance switch
            switch (CharacterClass)
            {
                case PlayerClass.Barbarian:
                    MaxHealth += 10;
                    Health += 10;
                    Block += 5;
                    break;

                case PlayerClass.Rogue:
                    HitChance += 8;
                    break;

                case PlayerClass.Mage:
                    MaxHealth -= 5;
                    Health -= 5;
                    break;

                case PlayerClass.Depraved:
                    MaxHealth -= 20;
                    Health -= 20;
                    break;
                #region Secrets
                case PlayerClass.FrontEndMaster:
                    MaxHealth += 100;
                    Health += 100;
                    Block += 10;
                    break;
                    #endregion
            }//end MaxHealth switch 
        }

        public Player()
        {

        }

        //Methods

        public override string ToString()
        {
            return base.ToString() +
                   $"Race: {Race}\n" +
                   $"Class: {CharacterClass}\n" +
                   $"{UserWeapon}\n";
        }
                         
                                        
        public int CalcHitChance()      
        {                               
            return HitChance + UserWeapon.BonusHitChance;           
        }                               

        public override int CalcDamage()
        {            
            return new Random().Next(UserWeapon.MinDamage, UserWeapon.MaxDamage + 1);
        }//end CalcDamage();    
    }
}
