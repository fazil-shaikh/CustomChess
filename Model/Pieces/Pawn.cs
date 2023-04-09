using System;
using System.Collections.Generic;

namespace Model.Pieces
{
	public class Pawn : BasePiece // Aka nobbly one down front
	{
		protected override char Char => '♙';

		private Vector Front => new Vector(Color == Color.White ? 1 :-1, 0);

		public override BasePiece[][,] GetMoves(BasePiece[,] board)
		{
			var boards = new List<BasePiece[,]>();
			// First move, can go two (bot not capture, nor jump)
			var forward = Location + Front;
			var forwardTwo = forward + Front;

			if (!HasMoved
				&& board[forward.X, forward.Y] == null
				&& board[forwardTwo.X, forwardTwo.Y] == null)
			{
				boards.Add(CloneBoardAndMove<Pawn>(board, forwardTwo));
			}
			// Can move one forward (but not capture)
			if (IsOnBoard(forward) && board[forward.X, forward.Y] == null)
			{
				if (!IsOnBoard(forwardTwo))// if at the end (promote)
				{
					boards.Add(CloneBoardAndMove<Knight>(board, forward));
					boards.Add(CloneBoardAndMove<Rook>(board, forward));
					boards.Add(CloneBoardAndMove<King>(board, forward));
					boards.Add(CloneBoardAndMove<Bishop>(board, forward));
				}
				else
				{
					boards.Add(CloneBoardAndMove<Pawn>(board, forward));
				}
			}

			// Capture diagonally one space left or right
			var forwardLeft = Location + Front + new Vector(0, -1);
			if (IsOnBoard(forwardLeft)
				&& board[forwardLeft.X, forwardLeft.Y] != null
				&& board[forwardLeft.X, forwardLeft.Y].Color != Color)
			{
				boards.Add(CloneBoardAndMove<Pawn>(board, forwardLeft));
			}
			var forwardRight = Location + Front + new Vector(0, 1);
			if (IsOnBoard(forwardRight)
				&& board[forwardRight.X, forwardRight.Y] != null
				&& board[forwardRight.X, forwardRight.Y].Color != Color)
			{
				boards.Add(CloneBoardAndMove<Pawn>(board, forwardRight));
			}

			return boards.ToArray();
		}
	}
}
