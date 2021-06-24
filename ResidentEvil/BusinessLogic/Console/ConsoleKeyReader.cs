using ResidentEvil.Models.Enums;
using System;
using System.Linq;

namespace ResidentEvil.BusinessLogic.Console
{
	internal class ConsoleKeyReader
	{
		private readonly ConsoleKey[] _acceptedKeys =
			{
			 ConsoleKey.LeftArrow,
			 ConsoleKey.RightArrow,
			 ConsoleKey.UpArrow,
			 ConsoleKey.DownArrow,
			 ConsoleKey.W,
			 ConsoleKey.A,
			 ConsoleKey.S,
			 ConsoleKey.D,
			 //ConsoleKey.Spacebar,
			 ConsoleKey.Escape,
			};

		public Instruction WaitForPlayer()
		{
			ConsoleKeyInfo pressedKey;

			do
			{
				pressedKey = System.Console.ReadKey();
			} while (!IsValidKey(pressedKey.Key));

			return GetInstruction(pressedKey.Key);
		}

		private bool IsValidKey(ConsoleKey key) => _acceptedKeys.Contains(key);

		private Instruction GetInstruction(ConsoleKey key)
		{
			return key switch
			{
				ConsoleKey.LeftArrow => Instruction.GoLeft,
				ConsoleKey.A => Instruction.GoLeft,

				ConsoleKey.RightArrow =>Instruction.GoRight,
				ConsoleKey.D =>Instruction.GoRight,

				ConsoleKey.UpArrow => Instruction.GoUp,
				ConsoleKey.W => Instruction.GoUp,

				ConsoleKey.DownArrow => Instruction.GoDown,
				ConsoleKey.S => Instruction.GoDown,

				//ConsoleKey.Spacebar => Instruction.Shoot,
				
				ConsoleKey.Escape => Instruction.Quit,

				_ => throw new NotImplementedException($"This key({key}) has not yet been implemented!"),
			};
		}
	}
}
