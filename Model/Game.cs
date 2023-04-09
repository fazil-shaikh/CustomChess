using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
	public class Game
	{
		public Stack<BasePiece[,]> History = new Stack<BasePiece[,]>();
		public Queue<BasePlayer> Players = new Queue<BasePlayer>();
		public BasePiece[,] CurrentBoard => History.Peek();
		public BasePiece[,] PreviousBoard()
		{
			if (History.Count < 2) return null;
			var current = History.Pop();
			var previous = History.Peek();
			History.Push(current);
			return previous;
		}

		public void TakeATurn()
		{
			var moves = GetMoves();
			var player = GetNextPlayer();
			int moveIndex = player.ChooseMove(moves);
			History.Push(moves[moveIndex]);
		}

		public Color Turn => Players.Peek().Color;
		private BasePlayer GetNextPlayer()
		{
			var nextPlayer = Players.Dequeue();
			Players.Enqueue(nextPlayer);
			return nextPlayer;
		}

		private BasePiece[][,] GetMoves()
		{
			List<BasePiece[,]> options = new List<BasePiece[,]>();
			var currentBoard = History.Peek();

			foreach (var piece in currentBoard)
			{
				if (piece?.Color == Turn)
				{
					options.AddRange(piece.GetMoves(currentBoard));
				}
			}

			return options.ToArray();
		}

		// null means game isn't over.
		// 0 is black win, 1 is white win, .5 is draw
		public double? ChechWinner()
		{
			if (History.Count > 2000) return .5;

			foreach (BasePiece p in CurrentBoard)
			{
				if (p?.Color == Turn) return null;
			}

			return (int)Turn;
		}
	}
}
