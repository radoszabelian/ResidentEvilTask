using ResidentEvil.Interfaces;
using System;

namespace ResidentEvil.BusinessLogic.Help
{
	internal static class Helper
	{
		public static bool IsAlive(ICharacter character) => character.Health > 0;

		public static bool IsOutOfBoundary(int min, int max, int number)
			=> number <= min || number >= max;

		public static bool IsBetween(int min, int max, int number)
			=> number >= min && number <= max;

		public static bool IsBetween(float min, float max, float number)
			=> number >= min && number <= max;

		public static int Distance(int point1, int point2)
			=> Math.Abs(point1 - point2);

		public static IPosition CorrectPosition(IPosition position, int width, int height)
		{
			position.X = CorrectPosition(position.X, width);
			position.Y = CorrectPosition(position.Y, height);

			return position;
		}

		public static int CorrectPosition(int number, int max)
		{
			var newNumber = number;
			while (IsLower(newNumber, 0))
			{
				newNumber = max + (newNumber % max);
			}

			newNumber %= max;

			return newNumber;
		}

		private static bool IsLower(int number, int min) => number < min;
	}
}
