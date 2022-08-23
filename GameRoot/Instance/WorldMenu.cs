using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace Instance
{
    internal class WorldMenu
    {
        static void Main(string[] args)
        {     
            Console.Title = "The Dungeon of Fungeon";
            Console.WriteLine("Welcome to the Dungeon!\nPress any key to start creating your character...");
            Console.ReadKey(true);
            Console.Clear();
            Player hero = Builder.MakePlayer();
            Console.Clear();

            bool worldExit = false;
            int roomCount = 1;            
            Console.WriteLine("\n\nPress a key to enter the first room... ");
            Console.ReadKey(true);
            do
            {
                Room room = new Room(roomCount);
                bool encounterExit = false;
                Console.Clear();  
                Console.WriteLine(room);
                do
                {
                    Console.WriteLine($"\nThe {room.RoomMonster.Name} stands before you...");
                    Console.WriteLine("What are you going to do?" +
                                        "\nA) Attack" +
                                        "\nR) Run Away" +
                                        "\nI) Use Item" +
                                        "\nC) Character Info" +
                                        "\nM) Monster Info" +
                                        "\nE) Exit" +
                                        $"\nRoom Number: {roomCount}");
                    ConsoleKey userAction = Console.ReadKey(true).Key;

                    switch (userAction)
                    {
                        case ConsoleKey.A:
                            Console.Clear();
                            Builder.Battle(hero, room.RoomMonster);
                            if(room.RoomMonster.Health <= 0)
                            {
                                if (room.HasChest)
                                {
                                    //display reward options
                                }
                                roomCount++;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"You have vanquished the {room.RoomMonster.Name}!");
                                Console.ResetColor();
                                Console.WriteLine("Press and key to enter the next room...");
                                Console.ReadKey(true);
                                encounterExit = true;
                            }
                            else if (hero.Health <=0)
                            {
                                Console.WriteLine("You DIED!");
                                worldExit = true;
                            }
                            break;

                        case ConsoleKey.R:
                            Console.Clear();
                            Console.WriteLine($"The {room.RoomMonster.Name} swipes at you as you run.\n" +
                                              $"Press any key to continue. Coward...");
                            Builder.Attack(room.RoomMonster, hero);
                            Console.ReadKey(true);
                            encounterExit = true;
                            break;
                        case ConsoleKey.I:
                            Console.Clear();
                            Builder.ItemSelect(hero);
                            if (hero.Health <= 0)
                            {
                                Console.WriteLine("You DIED!");
                                worldExit = true;
                            }
                            break;

                        case ConsoleKey.C:
                            Console.Clear();
                            Console.WriteLine(hero);
                            hero.DisplayInventory();
                            if (hero.Inventory.Count() == 0)
                            {
                                Console.WriteLine("EMPTY POCKETSES");
                            }
                            break;

                        case ConsoleKey.M:
                            Console.Clear();
                            Console.WriteLine(room.RoomMonster);
                            break;

                        case ConsoleKey.E:
                            worldExit = true;
                            break;

                        default:
                            Console.Clear();
                            break;
                    }
                } while (!encounterExit && !worldExit);//end Encounter while
            } while (!worldExit); //end World DoWhile

            string goodbye = $"Thanks for playing! You made it through {roomCount-1} room{((roomCount-1 > 1 || roomCount-1 == 0) ? "s." : ".")}";
            foreach (char character in goodbye)
            {
                Console.Write(character);
                Thread.Sleep(15);
            }
            #region Press to quit
            Console.WriteLine("\n\n\nPlease enter a key to exit the application.");
            Console.ReadKey(true);
            #endregion
        }//end Main()

        static bool Encounter() //TODO make Encounter() accept a monster as param
        {
            bool encounterExit = false;
            bool worldExit = false;
            Console.WriteLine("!!!! You Have Encountered A (Insert Monster) !!!!");
            do
            {


                Console.WriteLine("What are you going to do?" +
                                  "\nA) Attack" +
                                  "\nB) Run Away" +
                                  "\nC) Character Info" +
                                  "\nD) Monster Info" +
                                  "\nE) Exit");
                ConsoleKey userAction = Console.ReadKey(true).Key;

                switch (userAction)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.WriteLine("You attack the Monster and (Insert attack result here)");//TODO Attack function impliment
                        break;

                    case ConsoleKey.B:
                        Console.Clear();
                        Console.WriteLine("You Ran Away");
                        encounterExit = true;
                        worldExit = false;
                        break;

                    case ConsoleKey.C:
                        Console.Clear();
                        Console.WriteLine("Display Character info/inventory");//TODO Inventory/Stats impliment
                        break;

                    case ConsoleKey.D:
                        Console.Clear();
                        Console.WriteLine("Display Monster info");//TODO Monster info impliment
                        break;

                    case ConsoleKey.E:
                        encounterExit = true;
                        worldExit = true;
                        break;

                    default:
                        break;
                }
            } while (!encounterExit);//end Encounter while
            return worldExit;
        }//end Encounter()    //PROBABLY WONT USE

        static Monster MakeRoom() //TODO PHASE OUT FOR CUSTOM ROOM CLASS CreateRoom()
        {
            Random rand = new Random();
            string[] size = { "small", "medium", "large" };
            string[] vibe = { "foul", "musty", "dark", };
            string[] vibe2 = { "gloomy", "uncomfortable", "dismal" };
            string adjSize = size[rand.Next(3)];
            string adj1 = vibe[rand.Next(3)];
            string adj2 = vibe2[rand.Next(3)];
            int monsterCount = rand.Next(1, 4);
            bool plural = false;
            Monster monster = new Monster();
            //MonsterDraft[] monster = new MonsterDraft[monsterCount];
            //for (int i = 0; i < monster.Length; i++)
            //{
            //    monster[i] = new MonsterDraft();
            //}
            //for (int i = 0; i < monster.Length; i++)
            //{
                string monName = "";
                switch (rand.Next(4))
                {
                    case 0:
                        monName = "Goblin";
                        break;

                    case 1:
                        monName = "Spider";
                        break;

                    case 2:
                        monName = "Skeleton";
                        break;

                    case 3:
                        monName = "Zombie";
                        break;

                    //case 4:
                    //    break;

                }//end monster select switch
                monster.Name = monName;
            //}
            //if (monsterCount > 1)
            //{
            //    plural = true;
            //}//end if plural
            //Console.WriteLine($"You find yourself in a {adjSize}, {adj1}, {adj2} room. There {(plural ? "are" : "is")} {monsterCount} Monster{(plural ? "s" : "")} in the room.\n" +
            //    $"You see a {monster[0].Name}{(monster.Length == 2 ? $", and a {(monster.Length == 3 ? $"{monster[1].Name} and a {monster[2].Name}" : $"{monster[1].Name}")}" : ".")}");
            Console.WriteLine($"You find yourself in a {adjSize}, {adj1}, {adj2} room. You see a {monster.Name} in the corner");
            return monster;
        }//end MakeRoom()

        /*static Player MakePlayer()
        {
            bool characterCreateExit = false;
            Player user;
            do
            {
                Console.WriteLine("Enter your character's name: ");
                string pName = Console.ReadLine();
                Console.Clear();

                int raceSelect = 8;
                while ((raceSelect != 1) && (raceSelect != 2) && (raceSelect != 3) && (raceSelect != 4)
                    && (raceSelect != 5) && (raceSelect != 9))
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
                            Console.WriteLine($"{index}) {race}");
                            index++;
                        }
                    }
                    var input = Console.ReadKey(true).KeyChar;
                    if ((input != 1) && (input != 2) && (input != 3) && (input != 4)
                        && (input != 5) && (input != 9))
                    {
                        Console.WriteLine("Invalid selection please try again...");
                    }
                    else
                    {
                        raceSelect = Console.ReadKey(true).KeyChar;
                    }
                }
                PlayerRace pRace = (PlayerRace)raceSelect;
                Console.Clear();

                int classSelect = 8;
                while (classSelect != 1 && classSelect != 2 && classSelect != 3 &&
                classSelect != 4 && classSelect != 9)
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
                            Console.WriteLine($"{index}) {item}");
                            index++;
                        }
                    }
                    var input = Console.ReadKey().KeyChar;
                    if ((input != 1) && (input != 2) && (input != 3) && (input != 4)
                        && (input != 9))
                    {
                        Console.WriteLine("Invalid selection please try again...");
                    }
                    else
                    {
                        classSelect = Console.ReadKey(true).KeyChar;
                    }
                }
                PlayerClass pClass = (PlayerClass)classSelect;

                Console.Clear();
                Console.WriteLine("Choose your weapon: ");
                Weapon pWeapon;
                switch (pClass)
                {
                    case PlayerClass.Barbarian:
                        Console.WriteLine("1) Battleaxe\n" +
                                          "2) Broad Sword\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            pWeapon = new Weapon(WeaponType.Battleaxe, 5, true);
                        }
                        else
                        {
                            pWeapon = new Weapon(WeaponType.BroadSword, 8, true);
                        }
                        break;

                    case PlayerClass.Rogue:
                        Console.WriteLine("1) Dagger\n" +
                                          "2) Rapier\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            pWeapon = new Weapon(WeaponType.Dagger, 10, false);
                        }
                        else
                        {
                            pWeapon = new Weapon(WeaponType.Rapier, 9, false);
                        }
                        break;

                    case PlayerClass.Mage:
                        Console.WriteLine("1) Staff\n" +
                                          "2) Wand\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            pWeapon = new Weapon(WeaponType.Staff, 15, true);
                        }
                        else
                        {
                            pWeapon = new Weapon(WeaponType.Wand, 12, false);
                        }
                        break;

                    case PlayerClass.Depraved:
                        Console.WriteLine("1) Club\n" +
                                          "2) Stick\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            pWeapon = new Weapon(WeaponType.Club, 18, true);
                        }
                        else
                        {
                            pWeapon = new Weapon(WeaponType.Stick, 20, false);
                        }
                        break;
                    default:
                        pWeapon = new Weapon(WeaponType.Stick, 20, false);
                        break;
                    #region Secrets
                    case PlayerClass.FrontEndMaster:
                        pWeapon = new Weapon(WeaponType.SpencersMustache, 30, true);
                        break;
                        #endregion
                }
                Console.Clear();

                user = new Player(40, 40, pName, 60, 5, pClass, pWeapon, pRace);
                Console.Clear();
                Console.WriteLine("Your Character will be as Follows:");
                Console.WriteLine(user);
                Console.WriteLine("Does this look right? Y/N: ");
                switch (Console.ReadKey().Key)
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

        }//end MakePlayer()*/




    }//end class
}//end namespace
