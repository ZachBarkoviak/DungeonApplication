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
        private int _maxDamage;
        private WeaponType _type;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        //Props (public datatype PascalCaseOfCamelCase)
        public int MaxDamage
        {
            get
            {
                switch (Type)
                {
                    case WeaponType.Battleaxe: //Battleaxe
                        return 15;
                        break;

                    case WeaponType.BroadSword: //BroadSword
                        return 14;
                        break;

                    case WeaponType.Dagger: //Dagger
                        return 8;
                        break;

                    case WeaponType.Rapier: //Rapier
                        return 7;
                        break;

                    case WeaponType.Staff: //Staff
                        return 11;
                        break;

                    case WeaponType.Wand: //Wand
                        return 9;
                        break;

                    case WeaponType.Club: //Club
                    default:
                        return 5;
                        break;

                    case WeaponType.Stick: //Stick
                        return 7;
                        break;
                    #region Secrets
                    case WeaponType.SpencersMustache:
                        return 50;
                        break;
                    #endregion
                }
            }
        }
        public int MinDamage
        {
            get
            {
                switch (Type)
                {
                    case WeaponType.Battleaxe: 
                        return  5;
                        break;

                    case WeaponType.BroadSword: 
                        return 6;
                        break;

                    case WeaponType.Dagger: 
                        return 2;
                        break;

                    case WeaponType.Rapier: 
                        return 3;
                        break;

                    case WeaponType.Staff: 
                        return 1;
                        break;

                    case WeaponType.Wand: 
                        return 0;
                        break;

                    case WeaponType.Club: 
                    default:
                        return 1;
                        break;

                    case WeaponType.Stick: 
                        return 2;
                        break;
                    #region Secrets
                    case WeaponType.SpencersMustache:
                        return 25;
                        break;
                    #endregion
                }
            }
        }
        public string Name
        {
            get { return Type.ToString(); }

        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

        public WeaponType Type
        {
            get { return _type; }
            set {_type = value;}
        }

        //Constructors (public class(props)) (ctor + tab + tab for default)
        public Weapon(WeaponType type, /*int maxDamage, int minDamage, string name,*/ int bonusHitChance, bool isTwoHanded)
        {
            Type = type;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;//TODO **Maybe do some duel wield options?
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
