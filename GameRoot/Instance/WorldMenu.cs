using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instance
{
    internal class WorldMenu
    {
        static void Main(string[] args)
        {
            bool worldExit = false;
            bool encounterExit = false;

            do
            {
                Console.WriteLine("\n\nPress E to start an encounter: ");

                ConsoleKey encounter = Console.ReadKey(true).Key;

                if (encounter == ConsoleKey.E)
                {
                    encounterExit = false;
                    Console.Clear();
                    Console.WriteLine("\nYou encountered a (Insert Monster Here)\n");
                    //worldExit = Encounter();
                    do
                    {
                        Console.WriteLine("The (Insert Monster Here) stands before you...");
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
                                Console.WriteLine("You attack the Monster and (Insert attack result here)\n");//TODO Attack function impliment
                                break;

                            case ConsoleKey.B:
                                Console.Clear();
                                Console.WriteLine("You Ran Away\n");
                                encounterExit = true;
                                worldExit = false;
                                break;

                            case ConsoleKey.C:
                                Console.Clear();
                                Console.WriteLine("Display Character info/inventory\n");//TODO Inventory/Stats impliment
                                break;

                            case ConsoleKey.D:
                                Console.Clear();
                                Console.WriteLine("Display Monster info\n");//TODO Monster info impliment
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

    }//end class
}//end namespace
