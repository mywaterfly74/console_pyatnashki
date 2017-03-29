using System;
using System.Linq;
using System.Collections.Generic;

namespace Pyatna
{
	public class Game3 : Game2, IPlayable
	{
		public Game3(params int[] num) : base (num)
		{
		}
		public List<int> History = new List<int>();
        public List<int> BackHistory = new List<int>();
        public override void Randomize()
        {
        	base.Randomize ();
			History.Clear ();
			BackHistory.Clear ();
        }
		public override void Shift(int value)
        {
			base.Shift(value);
			History.Add(value);
            BackHistory.Clear();
        }
        public void Undo()
        {
            if (History.Count == 0)
                throw new InvalidOperationException("History is empty");
            BackHistory.Add(History[History.Count-1]);
            base.Shift(History[History.Count - 1]);
            History.RemoveAt(History.Count - 1);
        }
        public void Redo()
        {
            if (BackHistory.Count == 0)
                throw new InvalidOperationException("Back history is empty");
            base.Shift(BackHistory[BackHistory.Count - 1]);
            History.Add(BackHistory[BackHistory.Count - 1]);
            BackHistory.RemoveAt(BackHistory.Count - 1);
        }

	}
}
