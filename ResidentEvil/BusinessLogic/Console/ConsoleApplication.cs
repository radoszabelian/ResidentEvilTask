using ResidentEvil.BusinessLogic.FileHandling;
using ResidentEvil.BusinessLogic.GameLogic;
using ResidentEvil.Interfaces;
using ResidentEvil.Models.Enums;
using System;
using System.Drawing;
using ColorConsole = Colorful.Console;

namespace ResidentEvil.BusinessLogic.Console
{
	internal class ConsoleApplication : IApplication
	{
		private readonly IConsoleDrawer _drawer;
		private readonly ConsoleKeyReader _reader;
		
		private readonly Game _game;

		private bool quitRequested = false;

		public ConsoleApplication(string fileName, IFactory factory)
		{
			var reader = new FileReader(fileName, factory);
			var stage = reader.DeserializeStage();

			_game = new Game(stage);

			_drawer = new ColorfulConsoleDrawer(stage);
			_reader = new ConsoleKeyReader();
		}

		public void Run()
		{
			while (!quitRequested && !_game.IsOver())
			{
				ResetCursor();
				Draw();
				StartRound();
			}

			EndGame();
		}

		private void Draw()
		{
			_drawer.DrawStage(_game.Player, _game.Enemies);
		}

		private void StartRound()
		{
			var instruction = _reader.WaitForPlayer();
			_drawer.CursorToLineStart();

			quitRequested = instruction == Instruction.Quit;
			if (quitRequested)
				return;

			_game.Play(instruction);
		}

		private void ResetCursor()
		{
			_drawer.UpdateCursorPosition();
		}

		private void CheckWin()
		{
			if (quitRequested)
				return;

			if (!_game.IsWin())
				return;

			ColorConsole.WriteLine("");
			ColorConsole.WriteWithGradient("Congrats you won!", Color.Yellow, Color.Fuchsia, 60);
			ColorConsole.WriteLine("");

		}

		private void EndGame()
		{
			Draw();
			CheckWin();

			ColorConsole.ResetColor();
			WaitForEnter();
		}

		private void WaitForEnter()
		{
			ColorConsole.WriteLine("\n\n");
			ColorConsole.WriteLine("Press Enter to close the application!");

			ConsoleKeyInfo keyInfo;

			do
			{
				keyInfo = System.Console.ReadKey();
			} while (keyInfo.Key != ConsoleKey.Enter);
		}
	}
}
