using ResidentEvil.BusinessLogic.Help;
using ResidentEvil.Interfaces;
using ResidentEvil.Models.Enums;

namespace ResidentEvil.BusinessLogic.GameLogic.Movement
{
	internal class MovementHandler
	{
		private readonly EnemyMover _enemyMover = new EnemyMover();
		private readonly PlayerMover _playerMover = new PlayerMover();

		private readonly IStageApperance _stageApperance;

		private int Width => _stageApperance.Width;
		private int Height => _stageApperance.Height;
		private bool HasBorders => _stageApperance.HasBorders;

		public MovementHandler(IStageApperance stageApperance)
		{
			_stageApperance = stageApperance;
		}

		public void MovePlayer(IPlayer player, Direction moveDirection)
		{
			var (x, y) = _playerMover.MovePlayer(moveDirection);

			var newX = player.Position.X + x;
			var newY = player.Position.Y + y;
			if (!IsValidPosition(newX, newY, distanceX: 3))
				return;

			player.Position.X += x;
			player.Position.Y += y;

			if (!HasBorders)
			{
				CorrectPosition(player);
			}
		}

		public void MoveEnemies(IEnemy[] enemies, IPosition playerPosition)
		{
			foreach (var enemy in enemies)
			{
				if (!Helper.IsAlive(enemy))
					continue;

				var (x, y) = _enemyMover.MoveEnemy(enemy, playerPosition);
				var newX = enemy.Position.X + x;
				var newY = enemy.Position.Y + y;

				if (!IsValidPosition(newX, newY))
					continue;

				enemy.Position.X += x;
				enemy.Position.Y += y;

				if (!HasBorders)
				{
					CorrectPosition(enemy);
				}
			}
		}

		private bool IsValidPosition(int x, int y, int distanceX = 1, int distanceY = 1)
			=> !HasBorders
			|| !IsOutOfBoundary(x, y, distanceX, distanceY);

		private bool IsOutOfBoundary(int x, int y, int distanceX = 1, int distanceY = 1)
			=> Helper.IsOutOfBoundary(-1 + distanceX, Width - distanceX, x)
			|| Helper.IsOutOfBoundary(-1 + distanceY, Height - distanceY, y);

		private void CorrectPosition(IDisplayable character)
		{
			var newPos = Helper.CorrectPosition(character.Position, Width, Height);

			character.Position.X = newPos.X;
			character.Position.Y = newPos.Y;
		}
	}
}
