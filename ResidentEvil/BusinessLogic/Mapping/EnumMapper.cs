using ResidentEvil.Models.Enums;
using System;

namespace ResidentEvil.BusinessLogic.Mapping
{
	internal class EnumMapper
	{
		public static Direction MapInstructionToDirection(Instruction instruction)
		{
			return instruction switch
			{
				Instruction.GoLeft => Direction.Left,
				Instruction.GoRight => Direction.Right,
				Instruction.GoUp => Direction.Up,
				Instruction.GoDown=> Direction.Down,

				_ => throw new NotImplementedException($"This key({instruction}) has not yet been implemented!"),
			};
		}
	}
}
