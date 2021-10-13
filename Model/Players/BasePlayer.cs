using System;

namespace Model
{
	public class BasePlayer
	{
		private static readonly Random R = new Random();

		public string Name;
		public Color Color;

		virtual public int ChooseMove(BasePiece[][,] options)
		{
			int bestIndex = 0;
			double bestScore = ScoreMove(options[0]);

			for (int i = 1; i < options.Length; i++)
			{
				double score = ScoreMove(options[i]);
				if (score > bestScore)
				{
					bestIndex = i;
					bestScore = score;
				}
			}
			return bestIndex;
		}

		virtual protected double ScoreMove(BasePiece[,] options)
		{
			return R.NextDouble() - .5;
		}
	}
}
