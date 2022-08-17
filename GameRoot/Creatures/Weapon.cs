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
                    case (WeaponType)1: //Battleaxe
                        return 15;
                        break;

                    case (WeaponType)2: //BroadSword
                        return 14;
                        break;

                    case (WeaponType)3: //Dagger
                        return 8;
                        break;

                    case (WeaponType)4: //Rapier
                        return 7;
                        break;

                    case (WeaponType)5: //Staff
                        return 11;
                        break;

                    case (WeaponType)6: //Wand
                        return 9;
                        break;

                    case (WeaponType)7: //Club
                    default:
                        return 5;
                        break;

                    case (WeaponType)8: //Stick
                        return 7;
                        break;
                }
            }
        }
        public int MinDamage
        {
            get
            {
                switch (Type)
                {
                    case (WeaponType)1: //Battleaxe
                        return  5;
                        break;

                    case (WeaponType)2: //BroadSword
                        return 6;
                        break;

                    case (WeaponType)3: //Dagger
                        return 2;
                        break;

                    case (WeaponType)4: //Rapier
                        return 3;
                        break;

                    case (WeaponType)5: //Staff
                        return 1;
                        break;

                    case (WeaponType)6: //Wand
                        return 0;
                        break;

                    case (WeaponType)7: //Club
                    default:
                        return 1;
                        break;

                    case (WeaponType)8: //Stick
                        return 2;
                        break;
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
            BonusHitChance = bonusHitChance;//TODO impliment crit chance
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
