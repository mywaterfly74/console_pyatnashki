using System;
using System.Linq;

namespace Pyatna
{
	class Program
	{
		public static void Main(string[] args)
		{
			IPlayable game = new Game3(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,0);
			ConsoleGameUI CG = new ConsoleGameUI (game);
			CG.StartGame ();
		}
	}
}