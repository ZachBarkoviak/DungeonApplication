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
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        //Props (public datatype PascalCaseOfCamelCase)
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value >= _maxDamage)
                {
                    _minDamage = _maxDamage - 1;
                }
                else if(value <= 0)
                {
                    _minDamage = 1;
                }
                else
                {
                    _minDamage = value;
                }
            }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
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

        //Constructors (public class(props)) (ctor + tab + tab for default)
        public Weapon(int maxDamage, int minDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;//TODO impliment crit chance
            IsTwoHanded = isTwoHanded;//TODO **Maybe do some duel wield options?
        }

        //Methods
        public override string ToString()
        {
            return $"Weapon Name:\t{Name}\n" +
                   $"Damage Range:\t{MinDamage} - {MaxDamage}\n" +
                   $"Crit Chance:\t{BonusHitChance}\n" +
                   $"Type:\t{(IsTwoHanded ? "Two Handed" : "One Handed")}\n";
        }



    }
}
