using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class RoomTEST
    {
        public int MapXValue { get; set; }
        public int MapYValue { get; set; }
        public int[,] Grid { get; set; }
        public int[] CurrentPos { get; set; }
        public string Description { get; set; }
        public Monster RoomMonster { get; set; }
        public int[] MonsterPos { get; set; }

        //CTOR
        public RoomTEST(int mapX, int mapY, Monster roomMonster)
        {
            MapXValue = mapX;
            MapYValue = mapY;
            Grid = new int[mapY, mapX];
            Grid[0, 0] = 1;
            Grid[mapY - 1, mapX - 1] = 3;
            RoomMonster = roomMonster;
            CurrentPos = CurrentLocation(1);
            MonsterPos = CurrentLocation(3);
            Description = RoomDetails();
        }

        public RoomTEST()
        {
            MapXValue = 5;
            MapYValue = 5;
            Grid = new int[MapYValue, MapXValue];
            Grid[0, 0] = 1;
            CurrentPos = CurrentLocation(1);
            RoomMonster = new Monster();
            Description = RoomDetails();

        }//end default CTOR

        //Methods
        public void GenerateMap()
        {
            char[] border = new char[Grid.GetLength(1) + 2];

            //Console.WriteLine(border.Length);
            for (int i = 0; i < border.Length; i++)
            {
                border[i] = '#';
            }
            foreach (char i in border)
            {
                Console.Write(i + " ");
            }
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    if (Grid[i, j] == 0)
                    {
                        Grid[i, j] = 0;
                    }
                    else if (Grid[i, j] == 1)
                    {
                        Grid[i, j] = 1;
                    }
                    else
                    {
                        Grid[i, j] = 5;
                    }
                }
            }//end for (changing the displayed values for blank space and the player)
            Console.WriteLine();
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                Console.Write("# ");
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.Write(Grid[i, j] + " ");
                    if (j == (Grid.GetLength(1) - 1))
                    {
                        Console.Write("# ");
                        Console.WriteLine();
                    }
                }
            }
            foreach (char i in border)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine(Description);
        }//end GenerateMap()

        public int[] CurrentLocation(int toFind)
        {

            #region New way notes
            /*
     Dim test As String(,) = New String(,) {{"1", "2", "3"}, {"4", "5", "6"}}

     Dim cols As Integer = test.GetUpperBound(0)
     Dim rows As Integer = test.GetUpperBound(1)

     Dim toFind As String = "4"
     Dim xIndex As Integer
     Dim yIndex As Integer

     For x As Integer = 0 To cols - 1
         For y As Integer = 0 To rows - 1
             If test(x, y) = toFind Then
                 xIndex = x
                 yIndex = y
             End If
         Next
     Next
     COME BACK HERE FOR NEW WAY!!!!!!*/
            #endregion

            int cols = Grid.GetUpperBound(0);
            int rows = Grid.GetLowerBound(1);

            int xIndex = 0;
            int yIndex = 0; ;

            for (int x = 0; x < cols - 1; cols++)
            {
                for (int y = 0; x < rows - 1; cols++)
                {
                    if (Grid[x, y] == toFind)
                    {
                        xIndex = y;
                        yIndex = x;
                    }
                }

            }
            int[] result = { yIndex, xIndex };
            return result;
            #region Old way
            /*int[] currentPos = { 0, 0 };
            int currentPosInt = 0;
            foreach (int item in map)
            {
                if (item == 0)
                {
                    currentPosInt++;
                }
                else
                {
                    break;
                }
            }

            if ((currentPosInt >= 6) && (currentPosInt < 12))
            {
                currentPos[0] = 1;
                currentPos[1] = currentPosInt - 5;
            }
            else if ((currentPosInt >= 12) && (currentPosInt < 18))
            {
                currentPos[0] = 2;
                currentPos[1] = currentPosInt - 10;
            }
            else if ((currentPosInt >= 18) && (currentPosInt < 24))
            {
                currentPos[0] = 3;
                currentPos[1] = currentPosInt - 15;
            }
            else if ((currentPosInt >= 24) && (currentPosInt < 30))
            {
                currentPos[0] = 4;
                currentPos[1] = currentPosInt - 20;
            }
            else if (currentPosInt == 36)
            {
                currentPos[0] = 5;
                currentPos[1] = 5;
            }
            else
            {
                currentPos[0] = 0;
                currentPos[1] = currentPosInt;
            } */
            #endregion
        }//end CurrentLocation()
        public string RoomDetails()
        {
            Random rand = new Random();
            string[] size = { "small", "medium", "large" };
            string[] vibe = { "foul", "musty", "dark", };
            string[] vibe2 = { "gloomy", "uncomfortable", "dismal" };
            string adjSize = size[rand.Next(3)];
            string adj1 = vibe[rand.Next(3)];
            string adj2 = vibe2[rand.Next(3)];
            return $"You find yourself in a {adjSize}, {adj1}, {adj2} room. " +
                $"You see a {RoomMonster.Name} waiting to attack!";
        }



        public override string ToString()
        {
            return Description;
        }

        public int[] FindMove(ConsoleKey dir)
        {
            int xCord = CurrentPos[1];
            int yCord = CurrentPos[0];
            Console.WriteLine($"The X coord looking to be changed is: {xCord}");
            Console.WriteLine($"The Y coord looking to be changed is: {yCord}");

            int[] answer = { yCord, xCord };
            if (dir == ConsoleKey.W)
            {
                if (yCord == 0)
                {
                    answer = new int[] { yCord, xCord };
                }
                else
                {
                    answer = new int[] { (yCord - 1), xCord };
                }
            }
            else if (dir == ConsoleKey.D)
            {
                if (xCord == MapXValue - 1)
                {
                    answer = new int[] { yCord, xCord };
                }
                else
                {
                    answer = new int[] { yCord, (xCord + 1) };
                }
            }
            else if (dir == ConsoleKey.S)
            {
                if (yCord == MapYValue - 1)
                {
                    answer = new int[] { yCord, xCord };
                }
                else
                {
                    answer = new int[] { (yCord + 1), xCord };
                }
            }
            else if (dir == ConsoleKey.A)
            {
                if (xCord == 0)
                {
                    answer = new int[] { yCord, xCord };
                }
                else
                {
                    answer = new int[] { yCord, (xCord - 1) };
                }
            }
            else
            {
                return answer;
            }

            return answer;
        }//userMove ends


        public void UserMove()
        {
            bool moving = true;

            do
            {
                Console.WriteLine("Use W A S D to move your character...\n" +
                      "Press ESCAPE to quit.");
                ConsoleKey input = Console.ReadKey().Key;
                while ((input != ConsoleKey.W) && (input != ConsoleKey.D) && !(input == ConsoleKey.S) && (input != ConsoleKey.A)
                    && (input != ConsoleKey.Escape))
                {
                    Console.Write("try again");
                }
                if (input == ConsoleKey.Escape)
                {
                    moving = false;
                }
                else
                {
                    int[] newCoords = FindMove(input);
                    Grid[CurrentPos[0], CurrentPos[1]] = 0;
                    Grid[newCoords[0], newCoords[1]] = 1;
                    CurrentPos = CurrentLocation(1);

                }
                if (CurrentPos == MonsterPos)
                {
                    moving = false;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    GenerateMap();
                }
            } while (moving);

        }



    }
}

/*public void GenerateMap(int[,] map) //int[,] currentPos)
{

    char[] border = new char[map.GetLength(1) + 2];

    //Console.WriteLine(border.Length);
    for (int i = 0; i < border.Length; i++)
    {
        border[i] = '#';
    }
    foreach (char i in border)
    {
        //i = '#';
        Console.Write(i + " "); 
    }
    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int j = 0; j < map.GetLength(1); j++)
        {
            if (map[i,j] == 0)
            {
                map[i, j] = 0;
            }
            else
            {
                map[i, j] = 1;
            }
        }
    }
    Console.WriteLine();
    for (int i = 0; i < map.GetLength(0); i++)
    {
        Console.Write("# ");
        for (int j = 0; j < map.GetLength(1); j++)
        {
            Console.Write(map[i, j] + " ");
            if (j == (map.GetLength(1) - 1))
            {
                Console.Write("# ");
                Console.WriteLine();
            }
        }
    }
    foreach (char i in border)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine();
}//end GenerateMape()*/
/*public int[] CurrentLocation(int[,] map)
 {
     int[] currentPos = {0,0};
     int currentPosInt = 0;
     foreach (int item in map)
     {
         if (item == 0)
         {
             currentPosInt++;
         }
         else
         {
             break;
         }
     }

     if ((currentPosInt >= 6) && (currentPosInt < 12))
     {
         currentPos[0] = 1;
         currentPos[1] = currentPosInt - 5;
     }
     else if ((currentPosInt >= 12) && (currentPosInt < 18))
     {
         currentPos[0] = 2;
         currentPos[1] = currentPosInt - 10;
     }
     else if ((currentPosInt >= 18) && (currentPosInt < 24))
     {
         currentPos[0] = 3;
         currentPos[1] = currentPosInt - 15;
     }
     else if ((currentPosInt >= 24) && (currentPosInt < 30))
     {
         currentPos[0] = 4;
         currentPos[1] = currentPosInt - 20;
     }
     else if (currentPosInt == 36)
     {
         currentPos[0] = 5;
         currentPos[1] = 5;
     }
     else
     {
         currentPos[0] = 0;
         currentPos[1] = currentPosInt;
     }



     return currentPos;
 }//end CurrentLocation()*/
