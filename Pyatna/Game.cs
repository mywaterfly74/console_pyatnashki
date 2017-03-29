using System;
using System.Linq;
using System.IO;

namespace Pyatna
{

    public class Game
    {
        public int[,] Numbers;
        public Game(params int[] num)
        {
            double sizeDouble = Math.Sqrt(num.Length);
            bool zeroExist = false;
            for(int i = 0; i < num.Length; i++) 
                if(num[i] == 0) 
                    zeroExist = true; 
            if (sizeDouble%1!=0 || zeroExist == false)
                throw new Exception("No zero or wrong number of numbers");
            int size = Convert.ToInt32(sizeDouble);
            Numbers = new int[size, size];
            for (int x = 0; x < size; x++) 
				for (int y = 0; y < size; y++) 
					Numbers[y, x] = num[y*size + x];

        }

        public void Show()
        {
        	for(int i = 0; i < Math.Sqrt(Numbers.Length-1); i++)
        		for(int j = 0; j < Math.Sqrt(Numbers.Length-1); j++)
        			if(j != Convert.ToInt32(Math.Sqrt(Numbers.Length))-1)
        				Console.Write(Numbers[i,j] + "	");        				
        			else 
        				{
        					Console.WriteLine(Numbers[i,j] + "	\n	\n");
        				}
        }

        public void Index(int x, int y)
        {
            int index = Numbers[x-1, y-1];
            Console.WriteLine(index);
        }
        public int this[int x, int y]
        {
           	get
            {
                return Numbers[y, x];
            }
        }
        public Tuple<int, int> GetLocation(int value) 
        {
            int length = Numbers.Length;
            double gameLength = Math.Sqrt(length);
            int gameSize = Convert.ToInt32(gameLength);
            bool correct = false;
            int x = -1;
            int y = -1;
            for (int i = 0; i < gameLength; i++)
            for (int ii = 0; ii < gameLength; ii++)
                if (Numbers[i, ii] == value)
                {
            		x = ii;
            		y = i;
            		correct = true;
                }            	
            if (correct == false)
            	throw new ArgumentException("No free space");            	
            return Tuple.Create<int, int>(x, y);
        }
        public virtual void Shift(int value)
        {
        	Tuple<int,int> tupleVal = GetLocation(value);
        	int xVal = tupleVal.Item1;
        	int yVal = tupleVal.Item2;
        	Tuple<int,int> tuple0 = GetLocation(0);
        	int x0 = tuple0.Item1;
        	int y0 = tuple0.Item2;
        	if (((x0+1 == xVal) && (y0 == yVal)) || ((x0-1 == xVal) && (y0 == yVal)) || ((y0+1 == yVal) && (x0 == xVal)) || ((y0-1 == yVal) && (x0 == xVal)))
            	{
            		Numbers[y0, x0] = value;
            		Numbers[yVal, xVal] = 0;
            	}
            	else throw new ArgumentException("No free space");
        }

        
        public static Game FromCSV(string file) 
		{ 
			string[] strings = File.ReadAllLines(file); 
			string bigString = ("");
			int[] massive;
			for (int i = 0; i < strings.Length-1; i++)
				bigString = (bigString + strings[i]+",");
			bigString = bigString + strings[strings.Length-1];
			string[] subString = bigString.Split(',');
			massive = new int[subString.Length];
			for (int i = 0; i < subString.Length; i++)
				massive[i] = Convert.ToInt32(subString[i]); 
			return new Game(massive);
		}  
    }
}