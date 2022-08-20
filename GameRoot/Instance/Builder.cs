using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace Instance
{
    public class Builder
    {
        public static Player MakePlayer()
        {
            bool characterCreateExit = false;
            Player user;
            do
            {
                Console.WriteLine("Enter your character's name: ");
                string pName = Console.ReadLine();
                Console.Clear();

                char raceSelect = '8';
                while (raceSelect != '1' & raceSelect != '2' & raceSelect != '3' & raceSelect != '4'
                    & raceSelect != '5' & raceSelect != '9')
                {
                    Console.WriteLine("Please select a race: ");
                    var races = Enum.GetValues(typeof(PlayerRace));
                    int index = 0;
                    foreach (var race in races)
                    {
                        if (index == races.Length - 1)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{index+1}) {race}");
                            index++;
                        }
                    }
                    char input = Console.ReadKey(true).KeyChar;
                    if (input != '1' & input != '2' & input != '3' & input != '4'
                    & input != '5' & input != '9')
                    {
                        Console.WriteLine("Invalid selection please try again...");
                        input = Console.ReadKey(true).KeyChar;
                        Console.Clear();
                    }
                    else
                    {
                        raceSelect = input;
                    }
                }
                PlayerRace pRace = (PlayerRace)Convert.ToInt32(raceSelect.ToString());
                Console.Clear();

                char classSelect = '8';
                while (classSelect != '1' & classSelect != '2' & classSelect != '3' &
                classSelect != '4' & classSelect != '9')
                {
                    Console.WriteLine("Please select a class: ");
                    var classes = Enum.GetValues(typeof(PlayerClass));
                    int index = 0;
                    foreach (var item in classes)
                    {
                        if (index == classes.Length - 1)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{index+1}) {item}");
                            index++;
                        }
                    }
                    char input = Console.ReadKey().KeyChar;
                    if (input != '1' & input != '2' & input != '3' & input != '4' & input != '9')
                    {
                        Console.WriteLine("Invalid selection please try again...");
                        input = Console.ReadKey().KeyChar;
                    }
                    else
                    {
                        classSelect = input;
                    }
                }
                PlayerClass pClass = (PlayerClass)Convert.ToInt32(classSelect.ToString());

                Console.Clear();
                Console.WriteLine("Choose your weapon: ");
                Weapon pWeapon;
                switch (pClass)
                {
                    case PlayerClass.Barbarian:
                        Console.WriteLine("1) Battleaxe\n" +
                                          "2) Buster Sword\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            pWeapon = new Weapon(WeaponType.Battleaxe);
                        }
                        else
                        {
                            pWeapon = new Weapon(WeaponType.BusterSword);
                        }
                        break;

                    case PlayerClass.Rogue:
                        Console.WriteLine("1) Dagger\n" +
                                          "2) Rapier\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            pWeapon = new Weapon(WeaponType.Dagger);
                        }
                        else
                        {
                            pWeapon = new Weapon(WeaponType.Rapier);
                        }
                        break;

                    case PlayerClass.Mage:
                        Console.WriteLine("1) Staff\n" +
                                          "2) Wand\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            pWeapon = new Weapon(WeaponType.Staff);
                        }
                        else
                        {
                            pWeapon = new Weapon(WeaponType.Wand);
                        }
                        break;

                    case PlayerClass.Depraved:
                        Console.WriteLine("1) Club\n" +
                                          "2) Stick\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            pWeapon = new Weapon(WeaponType.Club);
                        }
                        else
                        {
                            pWeapon = new Weapon(WeaponType.Stick);
                        }
                        break;
                    default:
                        pWeapon = new Weapon(WeaponType.Stick);
                        break;
                    #region Secrets
                    case PlayerClass.FrontEndMaster:
                        pWeapon = new Weapon(WeaponType.SpencersMustache);
                        break;
                        #endregion
                }
                user = new Player(40, 40, pName, 60, 5, pClass, pWeapon, pRace);
                Console.Clear();
                Console.WriteLine("Your Character will be as Follows:");
                Console.WriteLine(user);
                Console.WriteLine("Does this look right? Y/N: ");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        characterCreateExit = true;
                        break;

                    case ConsoleKey.N:
                    default:
                        Console.Clear();
                        break;
                } 
            } while (!characterCreateExit);
            return user;

        }//end MakePlayer() defaults: Player(40, 40, pName, 60, 5, pClass, pWeapon, pRace);
                                                                             //max, min,    , hit, block, ...

        public static void Attack(Character attacker, Character defender)
        {
            int roll = new Random().Next(1, 101);
            if (roll <=(attacker.CalcHitChance() - defender.CalcBlock()))//hit
            {
                int damage = attacker.CalcDamage();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
                Console.ResetColor();
                Console.WriteLine("defender HP before: " + defender.Health);
                defender.Health -= damage;
                Console.WriteLine("defender HP after: " + defender.Health);
            }
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }
        }//end Attack

        public static void Battle(Player player, Monster monster)
        {
            Attack(player, monster);
            if(monster.Health > 0)
            {
                Attack(monster, player);
            }
            Console.WriteLine("Player health: " + player.Health);
            Console.WriteLine("Monster health: " + monster.Health);
        }


    }//end class
}//end namespace
