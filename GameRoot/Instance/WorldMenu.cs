using System;
using System.Collections.Generic;
using System.Linq;
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

            Player userHero = new Player();
            Console.WriteLine("Welcome to the Dungeon!\nPress any key to start creating your character...");
            Console.ReadKey();
            Console.Clear();
            bool characterCreateExit = false;

            #region Make Character Create a method
            do
            {
                PlayerClass sClass;
                PlayerRace sRace;
                Weapon sWeapon;
                string sName = "";
                Console.WriteLine("Enter your character's name: ");
                sName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Please select a Character Class:\n" +
                                  "1) Barbarian\n" +
                                  "2) Rogue\n" +
                                  "3) Mage\n" +
                                  "4) \"Other\"");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        sClass = PlayerClass.Barbarian;
                        break;

                    case ConsoleKey.D2:
                        sClass = PlayerClass.Rogue;
                        break;

                    case ConsoleKey.D3:
                        sClass = PlayerClass.Mage;
                        break;

                    case ConsoleKey.D4:
                    default:
                        sClass = PlayerClass.Depraved;
                        break;
                    #region Secrets
                    case ConsoleKey:D9:
                        sClass = PlayerClass.FrontEndMaster;
                        sName = "Spencer";
                        break;
                    #endregion
                }
                Console.Clear();
                Console.WriteLine("Choose your weapon: ");
                switch (sClass)
                {
                    case PlayerClass.Barbarian:
                        Console.WriteLine("1) Battleaxe\n" +
                                          "2) Broad Sword\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            sWeapon = new Weapon(WeaponType.Battleaxe, 5, true);
                        }
                        else
                        {
                            sWeapon = new Weapon(WeaponType.BroadSword, 8, true);
                        }
                        break;

                    case PlayerClass.Rogue:
                        Console.WriteLine("1) Dagger\n" +
                                          "2) Rapier\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            sWeapon = new Weapon(WeaponType.Dagger, 10, false);
                        }
                        else
                        {
                            sWeapon = new Weapon(WeaponType.Rapier, 9, false);
                        }
                        break;

                    case PlayerClass.Mage:
                        Console.WriteLine("1) Staff\n" +
                                          "2) Wand\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            sWeapon = new Weapon(WeaponType.Staff, 15, true);
                        }
                        else
                        {
                            sWeapon = new Weapon(WeaponType.Wand, 12, false);
                        }
                        break;

                    case PlayerClass.Depraved:
                        Console.WriteLine("1) Club\n" +
                                          "2) Stick\n");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            sWeapon = new Weapon(WeaponType.Club, 18, true);
                        }
                        else
                        {
                            sWeapon = new Weapon(WeaponType.Stick, 20, false);
                        }
                        break;
                    default:
                        sWeapon = new Weapon(WeaponType.Stick, 20, false);
                        break;
                    #region Secrets
                    case PlayerClass.FrontEndMaster:
                        sWeapon = new Weapon(WeaponType.SpencersMustache, 30, true);
                        break;
                    #endregion
                }
                Console.Clear();
                Console.WriteLine("Please select a Character Race:\n" +
                                  "1) Elf\n" +
                                  "2) Orc\n" +
                                  "3) Human\n" +
                                  "4) Goblin\n" +
                                  "5) Tiefling");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        sRace = PlayerRace.Elf;
                        break;

                    case ConsoleKey.D2:
                        sRace = PlayerRace.Orc;
                        break;

                    case ConsoleKey.D3:
                    default:
                        sRace = PlayerRace.Human;
                        break;

                    case ConsoleKey.D4:
                        sRace = PlayerRace.Goblin;
                        break;

                    case ConsoleKey.D5:
                        sRace = PlayerRace.Tiefling;
                        break;
                    #region Secrets
                    case ConsoleKey.D9:
                        sRace = PlayerRace.Developer;
                        break;
                    #endregion
                }
                Player user = new Player(1, 100, sName, 1, 1, sClass, sWeapon, sRace);
                Console.Clear();
                Console.WriteLine("Your Character will be as Follows:");
                Console.WriteLine(user);
                Console.WriteLine("Does this look right? Y/N: ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        characterCreateExit = true;
                        userHero = user;
                        break;

                    case ConsoleKey.N:
                    default:
                        Console.Clear();
                        break;
                }

            } while (!characterCreateExit);
            #endregion
            
            
            Console.Clear();
            Monster RoomMonster = new Monster();
            Room room = new Room(1, false, false, RoomMonster.GetMonster());
            bool newRoom = false;
            bool worldExit = false;
            int roomCount = 1;
            Random rand = new Random();
            do
            {
                //Console.WriteLine(userHero.Health);
                //userHero.Health -= 2;
                //Console.WriteLine(userHero.Health);
                Console.WriteLine("\n\nPress a key to enter the first room... ");

                Console.ReadKey();
                if(newRoom) //TODO create condition for completed room (kinda implimented)
                {
                    roomCount++;
                    if (roomCount == 6)
                    {
                        room = new Room(6, false, false, RoomMonster.GetMonster(6));
                    }
                    room = new Room(roomCount, (rand.Next(2) == 1 ? false : true),
                                   (rand.Next(2) == 1 ? false : true), RoomMonster.GetMonster());
                    newRoom = false;
                }

                bool encounterExit = false;
                Console.Clear();
                
                do
                {
                    Console.WriteLine(room);
                    Console.WriteLine($"\nThe {room.RoomMonster.Name} stands before you...");
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
                            Console.WriteLine("***** YOUR ATTACK *****\n");
                            int dmg = userHero.CalcDamage(room.RoomMonster);
                            if (dmg >= room.RoomMonster.Health)
                            {
                                Console.WriteLine("you slay the monster. Press key to continue...");
                                encounterExit = true;
                                newRoom = true;
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else if (dmg > 0 && dmg > room.RoomMonster.Block)
                            {
                                Console.WriteLine($"You attack the Monster and hit it for {dmg} damage!");
                                Console.WriteLine($"\nMonster Health before attack: {room.RoomMonster.Health}");
                                room.RoomMonster.Health -= dmg;
                                Console.WriteLine($"\nMonster Health after attack: {room.RoomMonster.Health}");
                            }
                            else
                            {
                                Console.WriteLine($"You attack the Monster and miss!");
                            }
                            Console.WriteLine("***** MONSTER ATTACK *****\n");
                            int monDam = room.RoomMonster.CalcDamage(userHero);
                            if (monDam > 0 && monDam > userHero.Block)
                            {
                                Console.WriteLine($"The monster hits you for {monDam} damage!");
                                userHero.Health -= monDam;
                            }
                            else
                            {
                                Console.WriteLine("The monster takes a swipe at you, but it misses!");
                            }
                            break;

                        case ConsoleKey.B:
                            Console.Clear();
                            Console.WriteLine("You Ran Away\n");
                            encounterExit = true;
                            worldExit = false;
                            break;

                        case ConsoleKey.C:
                            Console.Clear();
                            Console.WriteLine(userHero);//TODO Inventory/Stats impliment
                            break;

                        case ConsoleKey.D:
                            Console.Clear();
                            Console.WriteLine(room.RoomMonster);//DONE Monster info impliment
                            break;

                        case ConsoleKey.E:
                            encounterExit = true;
                            worldExit = true;
                            break;

                        default:
                            Console.Clear();
                            break;
                    }
                } while (!encounterExit);//end Encounter while
            } while (!worldExit); //end World DoWhile



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
    }//end class
}//end namespace
