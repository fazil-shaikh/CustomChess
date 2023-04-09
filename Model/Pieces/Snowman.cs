using System;
using System.Collections.Generic;

namespace Model.Pieces
{
	public class Snowman : BasePiece 
		// snow man is a nice guy, but when he is forced to capture a piece by the player, 
		// he becomes heartbroken and explodes from guilt
	{
		protected override char Char => '☃';

		private static Vector[] Directions = new Vector[] {
			new Vector(0, 1), // up
			new Vector(0, -1), // down
			new Vector(1, 0), // right
			new Vector(-1, 0), // left
		};

		public override BasePiece[][,] GetMoves(BasePiece[,] board)
		{
			// make an array size 8
			var boards = new List<BasePiece[,]>();
			// move the snowman
			foreach (var direction in Directions)
			{
				var landed = Location + direction;
				if (IsOnBoard(landed))
				{
					if (board[landed.X, landed.Y] == null)
					{
						boards.Add(CloneBoardAndMove<Snowman>(board, landed));
					}
					//if there's a piece to capture add the move then explode
					else if (board[landed.X, landed.Y].Color != Color)
					{
						boards.Add(CloneBoardAndMove<Explode>(board, landed));
					}
				}
			}
			return boards.ToArray();
		}
	}
}
