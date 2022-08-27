using DungeonLibrary.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {

        //Fields (_camelCase)

        private PlayerRace _race;
        private PlayerClass _characterClass;
        private Weapon _userWeapon;
        private List<Item> _inventory;



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
        public List<Item> Inventory { get; set; }
        public Armor Head { get; set; }
        public Armor Chest { get; set; }
        public Armor Legs { get; set; }



        //Constructors / ctors
        public Player(int maxHealth, int health, string name, int hitChance, int block, PlayerClass characterClass, Weapon userWeapon, PlayerRace race) : base(maxHealth, health, name, hitChance, block)
        {
            CharacterClass = characterClass;
            Race = race;
            UserWeapon = userWeapon;
            Inventory = GetInventory();
            switch (Race)
            {
                case PlayerRace.Elf:
                    HitChance += 5;
                    break;

                case PlayerRace.Orc:
                    HitChance -= 4;
                    Block += 2;
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
                    Block += 1;
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
                    Block += 2;
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
            CharacterClass = PlayerClass.Barbarian;
            Race = PlayerRace.Elf;
            UserWeapon = new Weapon(WeaponType.Battleaxe);
            Inventory = GetInventory();
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

        //Methods

        public override string ToString()
        {
            return base.ToString() +
                   $"Race: {Race}\n" +
                   $"Class: {CharacterClass}\n" +
                   $"{UserWeapon}";

        }

        public void DisplayGear()
        {
            Console.Clear();

            Console.WriteLine($"Head: {(Head == null ? "Empty" : Head)}\n" +
                              $"Chest: {(Chest == null ? "Empty" : Chest)}\n" +
                              $"Legs: {(Legs == null ? "Empty" : Legs)}\n");
        }
                         
                                        
        public int CalcHitChance()      
        {                               
            return HitChance + UserWeapon.BonusHitChance;           
        }                               

        public override int CalcDamage()
        {            
            return new Random().Next(UserWeapon.MinDamage, UserWeapon.MaxDamage + 1);
        }//end CalcDamage();    

        public override int CalcBlock()
        {
            int totalBlock = Block;
            if (Head != null)
            {
                totalBlock += Head.AttributeBonus;
            }
            if (Chest != null)
            {
                totalBlock += Chest.AttributeBonus;
            }
            if (Legs != null)
            {
                totalBlock += Legs.AttributeBonus;
            }
            return totalBlock;
        }


        public List<Item> GetInventory()
        {
            List<Item> inv = new List<Item>();
            switch (CharacterClass)
            {
                case PlayerClass.Barbarian:
                    inv.Add(Potion.GetPotion());
                    inv.Add(Potion.GetPotion());
                    break;
                case PlayerClass.Rogue:
                    inv.Add(Potion.GetPotion());

                    break;
                case PlayerClass.Mage:
                    inv.Add(Potion.GetPotion());

                    break;
                case PlayerClass.Depraved:
                default:
                    break;
                case PlayerClass.FrontEndMaster:
                    inv.Add(new Potion("The Sauce", 4, Collections.ItemType.Potion, "A vibrant liquid that swirls with power", true, 15));
                    break;
            }
            return inv;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("***** Inventory *****");
            foreach (Item item in Inventory)
            {
                Console.WriteLine(item + "\n");
            }
        }

        public void Equip(Armor piece)
        {
            switch (piece.Slot)
            {
                case ArmorSlot.Head:
                    Head = piece;
                    break;

                case ArmorSlot.Chest:
                    Chest = piece;
                    break;

                case ArmorSlot.Legs:
                    Legs = piece;
                    break;
            }
        }
    }
}
