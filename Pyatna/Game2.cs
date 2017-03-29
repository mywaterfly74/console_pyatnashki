using System;
using System.Linq;
using System.Security.Cryptography;

namespace Pyatna
{
    public class Game2 : Game, IPlayable
    {
        public Game2(params int[] num) : base(num)
        {
        }
        public virtual void Randomize()
        {
            int size = Convert.ToInt32(Math.Sqrt(Numbers.Length));
                for (int ii = 0; ii < size; ii++)
                    for (int i = 0; i < size; i++)
                    {
            			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
    					byte[] buffer = new byte[4];

    					rng.GetBytes(buffer);
    					int result = BitConverter.ToInt32(buffer, 0);
    					int randomNumber1 = new Random(result).Next(0, size-1);
    					int randomNumber2 = new Random(result).Next(0, size-1);
                        int swapNumberA = Numbers[i, ii];
                        int swapNumberB = Numbers[randomNumber2, randomNumber1];
                        Numbers[i, ii] = swapNumberB;
                        Numbers[randomNumber1, randomNumber2] = swapNumberA;
                    }
            int sum = 0;
            for (int i = 0; i < size; i++)
            	for (int ii = 0; ii < size; ii++)
            		for (int a = 0; a < size; a++)
            			for (int b = 0; b < size; b++)
            				if ((Numbers[i, ii] > Numbers[a, b]) && (i*size+ii < a*size+b))
            					sum = sum+1;
            if ((sum%2==1) && size !=2)//если "пятнашки" 2х2, то менять нельзя
            {
            	int num1 = Numbers[0,0];
            	int num2 = Numbers[0,1];
            	Numbers[0,0] = num2;
            	Numbers[0,1] = num1;            	
            }
            if (IsFinished())
            	Randomize();
        }

        public bool IsFinished()
        {
            int size = Convert.ToInt32(Math.Sqrt(Numbers.Length));
            for (int i = 0; i < size; i++)
            {
                for (int ii = 0; ii < size; ii++)
                {
                	if (((i != size - 1) || (ii != size - 1)) && (Numbers[i, ii] != i*size+(ii+1)) || (Numbers[size - 1, size - 1] != 0))
                        return false;
                }
            }
            return true;
        }
    }
}
	

