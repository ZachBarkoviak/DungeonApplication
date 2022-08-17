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
            int[,] roomMap = new int[6, 6];
            roomMap[0, 0] = 1;
            bool worldExit = false;
            Character userHero = new Character();
            Console.WriteLine("\nWelcome to the Dungeon!\nPress any key to start creating your character...");
            Console.ReadKey();
            Console.Clear();
            bool characterCreateExit = false;
            do
            {
                string sClass = "";
                string sRace = "";
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
                        sClass = "Barbarian";
                        break;

                    case ConsoleKey.D2:
                        sClass = "Rogue";
                        break;

                    case ConsoleKey.D3:
                        sClass = "Mage";
                        break;

                    case ConsoleKey.D4:
                    default:
                        sClass = "Depraved";
                        break;
                }
                Console.Clear();
                Console.WriteLine("Please select a Character Race:\n" +
                                  "1) Human\n" +
                                  "2) Elf\n" +
                                  "3) Orc\n" +
                                  "4) Goblin");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        sRace = "Human";
                        break;

                    case ConsoleKey.D2:
                        sRace = "Elf";
                        break;

                    case ConsoleKey.D3:
                        sRace = "Orc";
                        break;

                    case ConsoleKey.D4:
                    default:
                        sRace = "Goblin";
                        break;
                }
                Character user = new Character(sClass, sRace, 1, 100, sName, 70, 20);
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
            Console.Clear();

            do
            {
                //Console.WriteLine(userHero.Health);
                //userHero.Health -= 2;
                //Console.WriteLine(userHero.Health);
                Console.WriteLine("\n\nPress E to enter the first room... ");

                ConsoleKey encounter = Console.ReadKey(true).Key;

                if (encounter == ConsoleKey.E)
                {
                    bool encounterExit = false;
                    Console.Clear();
                    MonsterDraft roomMonster = MakeRoom();
                    



                    do
                    {
                        Console.WriteLine($"The {roomMonster.Name} stands before you...");
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
                                int dmg = userHero.CalcDamage();
                                Console.WriteLine($"You attack the Monster and {(dmg > 0 ? $"you hit it for {dmg} damage!" : "miss!")}");//TODO Attack function impliment
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
                                Console.WriteLine(roomMonster);//TODO Monster info impliment
                                break;

                            case ConsoleKey.E:
                                encounterExit = true;
                                worldExit = true;
                                break;

                            default:
                                break;
                        }
                    } while (!encounterExit);//end Encounter while
                }
                else
                {
                    Console.Clear();
                }
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
        }//end Encounter()

        static MonsterDraft MakeRoom()
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
            MonsterDraft monster = new MonsterDraft();
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
