using Model;
using System;

namespace ChessConsoleApp
{
	public static class Render
	{
		public static void ToConsole(this BasePiece[,] board, BasePiece[,] lastBoard = null)
		{
			for (int x = 0; x < 8; x++)
			{
				for (int y = 0; y < 8; y++)
				{
					var piece = board[x, y];
					Console.BackgroundColor = (x + y) % 2 == 1 ? ConsoleColor.DarkGray : ConsoleColor.Gray;
					if (lastBoard != null && lastBoard[x, y] != board[x, y])
					{
						Console.BackgroundColor = ConsoleColor.Cyan;
						// warn the player by highlighting red to indicate explosion
						if(piece?.GetType().Name.CompareTo("Explode") == 0)
						{
							Console.BackgroundColor = ConsoleColor.Red;
						}
					}

					if (piece != null)
					{
						Console.ForegroundColor = piece.Color == Color.White ? ConsoleColor.White : ConsoleColor.Black;
						var isSnowman = piece.GetType().Name.CompareTo("Snowman") == 0;
						var isExplode = piece.GetType().Name.CompareTo("Explode") == 0;
						// use the same character for both white and black sides
						if (!isSnowman && !isExplode)
						{
							Console.Write(piece.AsColoredChar());
						}
						else
						{
							if (isSnowman) Console.Write("☃"); //snowman
							if (isExplode) Console.Write("⚠"); //snowman explodes
						}
						Console.Write(" ");
					}
					else
					{
						Console.Write("  ");
					}
				}
				Console.WriteLine();
			}

			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
		}
	}
}
