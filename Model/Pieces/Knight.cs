using System;
using System.Collections.Generic;

namespace Model.Pieces
{
	public class Knight : BasePiece // Aka Horsey, can jump, captures where it lands
	{
		protected override char Char => '♘';

		private static Vector[] Directions = new Vector[] {
			new Vector(-2, -1),
			new Vector(-2, 1),
			new Vector(2, -1),
			new Vector(2, 1),
			new Vector(-1, 2),
			new Vector(-1, -2),
			new Vector(1, 2),
			new Vector(1, -2)
		};

		public override BasePiece[][,] GetMoves(BasePiece[,] board)
		{
			// make an array size 8
			var boards = new List<BasePiece[,]>();

			// add things to it
			foreach (var direction in Directions)
			{
				var landed = Location + direction;

				if (IsOnBoard(landed)
					&& board[landed.X, landed.Y]?.Color != Color) {
					boards.Add(CloneBoardAndMove<Knight>(board, landed));
				}
			}

			return boards.ToArray();
		}
	}
}
