using System;
using System.Collections.Generic;

namespace Model
{
	public abstract class BasePiece
	{
		public bool HasMoved;
		public Color Color;
		public Vector Location;

		public abstract BasePiece[][,] GetMoves(BasePiece[,] board);
		private const char ToBlackChar = (char)('♚' - '♔');
		protected abstract char Char { get; } // ♔♕♖♗♘♙ KQRBNP

		public char AsColoredChar()
		{
			return (char)(Char + (int)Color * ToBlackChar);
		}

		protected bool IsOnBoard(Vector landed)
		{
			return landed.X >= 0 && landed.X <= 7 && landed.Y >= 0 && landed.Y <= 7;
		}

		protected BasePiece[,] Clone(BasePiece[,] board)
		{
			return (BasePiece[,])board.Clone(); // Shallow Copy
		}

		protected BasePiece[,] CloneBoardAndMove<T>(BasePiece[,] board, Vector landingSpot)
			where T : BasePiece, new()
		{
			var newBoard = Clone(board);
			//remove from where it was
			newBoard[Location.X, Location.Y] = null;
			//put in new place
			newBoard[landingSpot.X, landingSpot.Y] =
				new T() { Color = Color, HasMoved = true, Location = landingSpot };
			return newBoard;
		}
	}
}
