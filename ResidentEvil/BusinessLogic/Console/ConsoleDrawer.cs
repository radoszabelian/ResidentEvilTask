using ResidentEvil.BusinessLogic.Help;
using ResidentEvil.Interfaces;
using System;

namespace ResidentEvil.BusinessLogic.Console
{
	internal class ConsoleDrawer : IConsoleDrawer
	{
		private (char character, ConsoleColor color)[,] stageArray;
		private int newLinePosition;

		private readonly IStageApperance _stageApperance;

		private int Width => _stageApperance.Width;
		private bool HasBorders => _stageApperance.HasBorders;

		public ConsoleDrawer(IStageApperance stageApperance)
		{
			stageArray = new (char, ConsoleColor)[stageApperance.Height, stageApperance.Width];

			_stageApperance = stageApperance;

			if (HasBorders)
				InitWalls();
		}

		private void InitWalls()
		{
			for (int i = 0; i < stageArray.GetLength(0); i++)
			{
				stageArray[i, 0] = ('*', ConsoleColor.White);
				stageArray[i, stageArray.GetLength(1) - 1] = ('*', ConsoleColor.White);
			}
			for (int j = 0; j < stageArray.GetLength(1); j++)
			{
				stageArray[0, j] = ('*', ConsoleColor.White); ;
				stageArray[stageArray.GetLength(0) - 1, j] = ('*', ConsoleColor.White);
			}
		}

		public void DrawStage(IDisplayable player,
							  ICharacter[] enemies)
		{
			System.Console.CursorLeft = 0;
			System.Console.CursorTop = 0;

			AddCharactersToStage(player, enemies);
			WriteToConsole();
			Clear();

			if (newLinePosition == 0)
				newLinePosition = System.Console.CursorTop;

			System.Console.CursorLeft = 0;
			System.Console.CursorTop = newLinePosition;
		}

		public void UpdateCursorPosition() => newLinePosition = System.Console.CursorTop;

		public void CursorToLineStart() => System.Console.CursorLeft = 0;

		private void AddCharactersToStage(IDisplayable player, ICharacter[] enemies)
		{
			foreach (var enemy in enemies)
			{
				var position = enemy.Position;
				var color = Helper.IsAlive(enemy) ? ConsoleColor.Red : ConsoleColor.Gray;

				stageArray[position.Y, position.X] = (enemy.DisplayChar, color);
			}

			var playerPosition = player.Position;
			stageArray[playerPosition.Y, playerPosition.X] = (player.DisplayChar, ConsoleColor.Blue);
			stageArray[playerPosition.Y, CorrectX(playerPosition.X - 2)] = ('<', ConsoleColor.DarkYellow);
			stageArray[playerPosition.Y, CorrectX(playerPosition.X - 1)] = ('=', ConsoleColor.DarkYellow);
			stageArray[playerPosition.Y, CorrectX(playerPosition.X + 2)] = ('>', ConsoleColor.DarkYellow);
			stageArray[playerPosition.Y, CorrectX(playerPosition.X + 1)] = ('=', ConsoleColor.DarkYellow);
		}

		private void WriteToConsole()
		{
			for (int i = 0; i < stageArray.GetLength(0); i++)
			{
				for (int j = 0; j < stageArray.GetLength(1); j++)
				{
					var (character, color) = stageArray[i, j];
					System.Console.ForegroundColor = color;

					System.Console.Write(character);

				}
				System.Console.WriteLine();
			}
		}

		private void Clear()
		{
			for (int i = 0; i < stageArray.GetLength(0); i++)
			{
				for (int j = 0; j < stageArray.GetLength(1); j++)
				{
					if (HasBorders)
					{
						if (i == 0 || i == stageArray.GetLength(0) - 1
							|| j == 0 || j == stageArray.GetLength(1) - 1)
						{
							stageArray[i, j] = ('*', ConsoleColor.White);
							continue;
						}
					}

					stageArray[i, j] = (' ', ConsoleColor.White);
				}
			}
		}

		private int CorrectX(int number)
			=> Helper.CorrectPosition(number, Width);
	}
}
