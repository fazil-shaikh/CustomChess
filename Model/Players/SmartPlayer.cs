using System;

namespace Model
{
	// this player is too overpowered for the poor base player
	// can also go against itself 
	public class SmartPlayer : BasePlayer 
	{
		private static readonly Random R = new Random();

		public override int ChooseMove(BasePiece[][,] options)
		{
			int bestIndex = 0;
			bool capture = false;

			double bestScore = ScoreMove(options[0]); // number of empty spots

			for (int i = 1; i < options.Length; i++)
			{
				double score = ScoreMove(options[i]); // number of empty spots

			 // if this option has more empty spots than it's a better option
				if (score > bestScore) 
				{
					bestIndex = i;
					bestScore = score;
					capture = true;
				}
			}
			// if there are no capture moves just do a random move
			return capture ? bestIndex : R.Next(0, options.Length);
		}
		/* the idea here is that more nulls on the board indicate a capture  
		 * because when a piece is captured it results in an extra space on the board
		 * so the moves that capture will have more nulls on board 
		 * than the moves that don't capture
		 */
		protected override double ScoreMove(BasePiece[,] option)
		{
			double count = 0;

			foreach (var location in option)
			{
				if (location == null)
				{
					count++;
				}
			}

			return count;
		}
		//--------------------------------

		/* possible improvements:
		 * - defend itself against captures instead of focusing on attacking
		 * I tried to implement this but I couldn't figure it out
		 */
		/*
		 // number of black pieces
	   protected double NumBlackPieces(BasePiece[,] option)
	   {
		   double count = 0;

		   foreach (var location in option)
		   {
			   if (location.Color == Color.White)
			   {
				   count++;
			   }
		   }
		   return count;
	   }

	   // number of white pieces
	   protected double NumWhitePieces(BasePiece[,] option)
	   {
		   double count = 0;

		   foreach (var location in option)
		   {
			   if (location.Color == Color.White)
			   {
				   count++;
			   }
		   }
		   return count;
	   }
		   virtual protected string GetPlayerName()
			   {
				   Console.WriteLine("Player Name: ");
				   return Console.ReadLine();
			   }

		*/
	}
}
