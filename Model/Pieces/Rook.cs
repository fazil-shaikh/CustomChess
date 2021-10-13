using System;
using System.Collections.Generic;

namespace Model.Pieces
{
    public class Rook : BasePiece
    {

        private static Vector[] DirectionsForward = new Vector[] {
            new Vector(0, 1),
            new Vector(0, 2),
            new Vector(0, 3),
            new Vector(0, 4),
            new Vector(0, 5),
            new Vector(0, 6),
            new Vector(0, 7)
        };

        private static Vector[] DirectionsBack = new Vector[] {
            new Vector(0, -1),
            new Vector(0, -2),
            new Vector(0, -3),
            new Vector(0, -4),
            new Vector(0, -5),
            new Vector(0, -6),
            new Vector(0, -7)
        };

        private static Vector[] DirectionsRight = new Vector[]
            {
            new Vector(1, 0),
            new Vector(2, 0),
            new Vector(3, 0),
            new Vector(4, 0),
            new Vector(5, 0),
            new Vector(6, 0),
            new Vector(7, 0)
            };

        private static Vector[] DirectionsLeft = new Vector[]
        {
            new Vector(-1, 0),
            new Vector(-2, 0),
            new Vector(-3, 0),
            new Vector(-4, 0),
            new Vector(-5, 0),
            new Vector(-6, 0),
            new Vector(-7, 0)
        };

		protected override char Char => '♖';

		public override BasePiece[][,] GetMoves(BasePiece[,] board)
        {
            //New list to store potential moves
            var boards = new List<BasePiece[,]>();

            foreach (var directions in new [] { DirectionsForward, DirectionsBack, DirectionsLeft, DirectionsRight })
            {
                foreach (var direction in directions)
                {
                    var landed = Location + direction;
                    if (IsOnBoard(landed))
                    {
                        if (board[landed.X, landed.Y] == null)
                        {
							boards.Add(CloneBoardAndMove<Rook>(board, landed));
						}
                        //if there's a piece to capture add the move then break
                        else if (board[landed.X, landed.Y].Color != Color)
                        {
							boards.Add(CloneBoardAndMove<Rook>(board, landed));
							break;
                        }
                        //if we get here it there is a piece of the same color so no more moves get added
                        else break;
                    }
                    else break;
                }
            }
            return boards.ToArray();

        }
    }
}
