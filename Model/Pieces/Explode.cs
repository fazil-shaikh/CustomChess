using System;
using System.Collections.Generic;

namespace Model.Pieces
{
	public class Explode : BasePiece 
		// a character that the snowman piece morphs into after a capture
		// explosion happens after one move
	{
		protected override char Char => '⚠'; // run

		public override BasePiece[][,] GetMoves(BasePiece[,] board)
		{
			// make an array size 8
			var boards = new List<BasePiece[,]>();
			var newBoard = explode(board, Location.X, Location.Y);

			// add the board after the explosion
			boards.Add(newBoard);
			return boards.ToArray();
		}

		// explodes every piece in the 1x1 radius of the snowman
		private BasePiece[,] explode(BasePiece[,] board, int x, int y)
		{
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					if (IsOnBoard(new Vector(i + x, j + y)))
					{
						board[i + x, j + y] = null;
					}

				}
			}
			return board;
		}
	}
}
