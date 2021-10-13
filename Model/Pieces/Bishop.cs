using System;
using System.Collections.Generic;

namespace Model.Pieces
{
    public class Bishop : BasePiece
    {
        private Vector[] directions = { new Vector(1, 1),
            new Vector(-1, 1),
            new Vector(1, -1),
            new Vector(-1, -1)
        };

        protected override char Char => '♗';

        public override BasePiece[][,] GetMoves(BasePiece[,] board)
        {
            var boards = new List<BasePiece[,]>();

			Action<Vector> continueDirection = d =>
			{
				bool captured = false;
                var looking = Location + d;
				while (IsOnBoard(looking) && board[looking.X, looking.Y]?.Color != Color && !captured)
				{
					captured = board[looking.X, looking.Y] != null;
					boards.Add(CloneBoardAndMove<Bishop>(board, looking));
                    looking += d;
				}
			};

            foreach(Vector d in directions)
            {
                continueDirection(d);
            }

			return boards.ToArray(); 
        }
    }
}