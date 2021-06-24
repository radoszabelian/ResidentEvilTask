using Colorful;
using ResidentEvil.BusinessLogic.Help;
using ResidentEvil.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ColorConsole = Colorful.Console;

namespace ResidentEvil.BusinessLogic.Console
{
	internal partial class ColorfulConsoleDrawer : IConsoleDrawer
	{
		private char[][] _representation;
		private StyleSheet _sheet;
		private int newLinePosition;
		private GameplayArea innerArea;

		public ColorfulConsoleDrawer(IStage stage)
		{
			InitArea(stage);
			InitArray(stage.Width, stage.Height);
			InitWalls();
			InitStyleSheet(stage.Player, stage.Enemies);
		}

		private void InitArea(IStage stage)
		{
			var gameCharacters = stage.Enemies
									  .Cast<ICharacter>()
									  .Append(stage.Player)
									  .ToArray();

			innerArea = new GameplayArea(gameCharacters, stage.Player.DisplayChar)
			{
				FirstX = stage.HasBorders ? 1 : 0,
				FirstY = stage.HasBorders ? 1 : 0,
				LastX = stage.Width - (stage.HasBorders ? 2 : 1),
				LastY = stage.Height - (stage.HasBorders ? 2 : 1),
				CanWrap = !stage.HasBorders,
			};
		}

		private void InitArray(int width, int height)
		{
			_representation = new char[height][];

			for (int i = 0; i < _representation.Length; i++)
				_representation[i] = new char[width];
		}

		private void InitWalls()
		{
			for (int i = 0; i < _representation.Length; i++)
			{
				_representation[i][0] = '*';
				_representation[i][^1] = '*';
			}
			for (int j = 0; j < _representation[0].Length; j++)
			{
				_representation[0][j] = '*';
				_representation[^1][j] = '*';
			}
		}

		private void InitStyleSheet(IPlayer player,
									IEnumerable<IEnemy> enemies)
		{
			_sheet = new StyleSheet(Color.White);

			var enemyColors = enemies.Select(e => new
			{
				Color = e is IBoss ? Color.DarkRed : Color.LightCoral,
				e.DisplayChar
			}).Distinct();

			foreach (var enemy in enemyColors)
			{
				_sheet.AddStyle($"{enemy.DisplayChar}", enemy.Color);
			}

			_sheet.AddStyle($"[{player.DisplayChar}]", Color.RoyalBlue);
			_sheet.AddStyle($"[=<>]", Color.Silver);
		}

		public void DrawStage(IDisplayable player, ICharacter[] enemies)
		{
			ColorConsole.CursorLeft = 0;
			ColorConsole.CursorTop = 0;

			ClearRepresentation();
			RemoveDeadEnemies();
			UpdateRepresentation();
			WriteOut();

			if (newLinePosition == 0)
				newLinePosition = ColorConsole.CursorTop;

			ColorConsole.CursorLeft = 0;
			ColorConsole.CursorTop = newLinePosition;
		}

		private void ClearRepresentation()
		{
			for (int i = innerArea.FirstY; i <= innerArea.LastY; i++)
				for (int j = innerArea.FirstX; j <= innerArea.LastX; j++)
					_representation[i][j] = ' ';
		}

		private void RemoveDeadEnemies()
		{
			var deadEnemies = new List<ICharacter>();

			foreach (var character in innerArea.GameCharacters)
			{
				if (Helper.IsAlive(character))
					continue;

				deadEnemies.Add(character);
			}

			innerArea.RemoveCharacters(deadEnemies);
		}

		private void UpdateRepresentation()
		{
			foreach (var character in innerArea.GameCharacters)
			{
				var (x, y) = (character.Position.X, character.Position.Y);
				_representation[y][x] = character.DisplayChar;

				if (character.DisplayChar == innerArea.PlayerChar)
				{
					_representation[y][Wrap(x - 2)] = '<';
					_representation[y][Wrap(x - 1)] = '=';
					_representation[y][Wrap(x + 1)] = '=';
					_representation[y][Wrap(x + 2)] = '>';
				}
			}
		}

		private void WriteOut()
		{
			for (int i = 0; i < _representation.Length; i++)
			{
				ColorConsole.WriteLineStyled(_representation[i], _sheet);
			}
		}

		private int Wrap(int x) => Helper.CorrectPosition(x, innerArea.LastX + 1);

		public void CursorToLineStart() => ColorConsole.CursorLeft = 0;

		public void UpdateCursorPosition() => newLinePosition = ColorConsole.CursorTop;
	}
}
