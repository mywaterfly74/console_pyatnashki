using System;
using System.Linq;

namespace Pyatna
{
	public interface IPlayable
	{
		void Randomize();
		bool IsFinished();
		void Shift(int value);
		void Show();
	}
}