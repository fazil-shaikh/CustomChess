using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public class Vector
	{
		public Vector(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X;
		public int Y;

		public static Vector operator +(Vector a, Vector b)
		{
			return new Vector(a.X + b.X, a.Y + b.Y);
		}

		// This is worse!
		//public Piece this[Piece[,] board]
		//{
		//	get { return board[X,Y]; }
		//}
	}
}
