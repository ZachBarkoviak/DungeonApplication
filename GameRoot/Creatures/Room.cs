using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instance
{
    public class Room
    {
        public void GenerateMap(int[,] map) //int[,] currentPos)
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
        }//end GenerateMape()
        public int[] CurrentLocation(int[,] map)
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
        }//end CurrentLocation()

        //Fields (private datatype _camelCase;)
        private string _description;
        private int[,] _dimensions;
 
        //Props (public datatype PascalCaseOfCamelCase)


        //Constructors (public class(props)) (ctor + tab + tab for default)


        //Methods

    }//end class
}//end namespace
