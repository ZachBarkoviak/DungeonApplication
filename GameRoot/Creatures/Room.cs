using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Instance
{
    public class Room
    {


        //Fields (private datatype _camelCase;)

        //Props (public datatype PascalCaseOfCamelCase)
        public int RoomID { get; set; }
        public bool IsTrapped { get; set; }
        public bool HasChest { get; set; }
        public Monster RoomMonster { get; set; }
        public string Description { get; set; }


        //Constructors (public class(props)) (ctor + tab + tab for default)
        public Room(int roomID)
        {
            RoomID = roomID;
            IsTrapped = (new Random().Next(2) == 1 ? true : false);
            HasChest = (new Random().Next(2) == 1 ? true : false);
            RoomMonster = Monster.GetMonster();
            Description = GetRoom();
            if (roomID == 6)
            {
                RoomMonster = Monster.GetBoss();
            }
        }

        public Room()
        {
            
        }

        //Methods
        public override string ToString()
        {
            return Description;
        }

        private string GetRoom()
        {
            string result = "";
            if (RoomID != 6)
            {
                Random rand = new Random();
                string[] size = { "small", "medium", "large" };
                string[] vibe = { "foul", "musty", "dark", };
                string[] vibe2 = { "gloomy", "uncomfortable", "dismal" };
                string adjSize = size[rand.Next(3)];
                string adj1 = vibe[rand.Next(3)];
                string adj2 = vibe2[rand.Next(3)];
                result = $"You find yourself in a {adjSize}, {adj1}, {adj2} room. You see a {RoomMonster.Name} in the corner";
            }
            else
            {
                result = "Before you stands (insert cool boss description here)";
            }
            return result;
        }



    }//end class
}//end namespace

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