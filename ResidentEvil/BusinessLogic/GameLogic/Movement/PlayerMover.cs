using ResidentEvil.Models.Enums;

namespace ResidentEvil.BusinessLogic.GameLogic.Movement
{
	internal class PlayerMover
	{
		public (int x, int y) MovePlayer(Direction direction)
		{
			var vector = (X: 0, Y: 0);

			switch (direction)
			{
				case Direction.Left:
					vector.X -= 1;
					break;
				case Direction.Right:
					vector.X += 1;
					break;
				case Direction.Up:
					vector.Y -= 1;
					break;
				case Direction.Down:
					vector.Y += 1;
					break;
				default:
					break;
			}

			return vector;
		}

	}
}
