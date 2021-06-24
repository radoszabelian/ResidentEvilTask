using ResidentEvil.BusinessLogic.Help;
using ResidentEvil.Interfaces;

namespace ResidentEvil.BusinessLogic.GameLogic.Attack
{
	internal class AttackHandler
	{
		public void Attack(IPlayer player, IEnemy[] enemies)
		{
			AttackEnemies(player, enemies);
			AttackPlayer(enemies, player);
		}

		private void AttackEnemies(IPlayer player, IEnemy[] enemies)
		{
			foreach (var enemy in enemies)
			{
				var (enemyX, enemyY)  = (enemy.Position.X, enemy.Position.Y);
				var (playerX, playerY)  = (player.Position.X, player.Position.Y);

				if (enemyY != playerY)
					continue;

				if (Helper.Distance(playerX, enemyX)  <= 2)
				{
					player.Attack(enemy);
				}
			}
		}

		private void AttackPlayer(IEnemy[] enemies, IPlayer player)
		{
			foreach (var enemy in enemies)
			{
				if (!Helper.IsAlive(enemy))
					continue;

				if (IsInRange(enemy.Position, player.Position))
				{
					enemy.Attack(player);
				}
			}
		}

		private bool IsInRange(IPosition pos1, IPosition pos2)
			=> Helper.IsBetween(pos2.X - 1, pos2.X + 1, pos1.X)
			&& Helper.IsBetween(pos2.Y - 1, pos2.Y + 1, pos1.Y);
	}
}
