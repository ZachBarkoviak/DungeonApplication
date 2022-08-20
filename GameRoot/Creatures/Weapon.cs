using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //Fields (private datatype _camelCase;)
        private int _minDamage;
        //private int _maxDamage;
        //private WeaponType _type;
        //private string _name;
        //private int _bonusHitChance;
        //private bool _isTwoHanded;

        //Props (public datatype PascalCaseOfCamelCase)
        public int MaxDamage { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > MaxDamage | value <= 0)
                {
                    _minDamage = 1;
                }
                else
                {
                    _minDamage = value;
                }
            }
        }
        public string Name { get; set; }
        public int BonusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }
        public WeaponType Type { get; set; }

        //Constructors (public class(props)) (ctor + tab + tab for default)
        public Weapon(WeaponType type)
        {
            Type = type;
            MaxDamage = 2;
            MinDamage = 1;
            Name = "null";
            BonusHitChance = 0;
            IsTwoHanded = false;
            switch (Type)
            {
                case WeaponType.Battleaxe:
                    MaxDamage = 15;
                    MinDamage = 5;
                    Name = "Battleaxe";
                    BonusHitChance = 5;
                    IsTwoHanded = true;
                    break;
                case WeaponType.BusterSword:
                    MaxDamage = 13;
                    MinDamage = 8;
                    Name = "Buster Sword";
                    BonusHitChance = 4;
                    IsTwoHanded = true;
                    break;
                case WeaponType.Dagger:
                    MaxDamage = 8;
                    MinDamage = 2;
                    Name = "Dagger";
                    BonusHitChance = 8;
                    IsTwoHanded = false;
                    break;
                case WeaponType.Rapier:
                    MaxDamage = 7;
                    MinDamage = 3;
                    Name = "Rapier";
                    BonusHitChance = 7;
                    IsTwoHanded = false;
                    break;
                case WeaponType.Staff:
                    MaxDamage = 11;
                    MinDamage = 4;
                    Name = "Staff";
                    BonusHitChance = 5;
                    IsTwoHanded = true;
                    break;
                case WeaponType.Wand:
                    MaxDamage = 13;
                    MinDamage = 1;
                    Name = "Wand";
                    BonusHitChance = 3;
                    IsTwoHanded = false;
                    break;
                case WeaponType.Club:
                    MaxDamage = 5;
                    MinDamage = 1;
                    Name = "Club";
                    BonusHitChance = 3;
                    IsTwoHanded = true;
                    break;
                case WeaponType.Stick:
                default:
                    MaxDamage = 4;
                    MinDamage = 3;
                    Name = "Stick";
                    BonusHitChance = 7;
                    IsTwoHanded = false;
                    break;
                case WeaponType.SpencersMustache:
                    MaxDamage = 50;
                    MinDamage = 15;
                    Name = "Spencer's Mustache";
                    BonusHitChance = 10;
                    IsTwoHanded = false;
                    break;
            }
        }

        //Methods
        public override string ToString()
        {
            return $"----- Weapon -----\n" +
                   $"Name: {Name}\n" +
                   $"Damage Range: {MinDamage} - {MaxDamage}\n" +
                   $"Hit Bonus: {BonusHitChance}%\n" +
                   $"Type: {(IsTwoHanded ? "Two Handed" : "One Handed")}\n";
        }



    }
}
