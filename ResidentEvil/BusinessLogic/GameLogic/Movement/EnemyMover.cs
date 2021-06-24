using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;

namespace ResidentEvil.BusinessLogic.GameLogic.Movement
{
	internal class EnemyMover
	{
		private static readonly Random Rnd = new Random();
		private const int BossWaitTime = 2;

		private readonly Dictionary<IBoss, int> bossDictionary = new Dictionary<IBoss, int>();

		public (int x, int y) MoveEnemy(IEnemy enemy, IPosition playerPosition)
		{
			if (enemy is IBoss boss)
			{
				return MoveBoss(boss, playerPosition);
			}

			return MoveRandom();
		}

		private (int x, int y) MoveBoss(IBoss boss, IPosition playerPosition)
		{
			if (!CanBossMove(boss))
				return (0, 0);

			var deltaX = playerPosition.X - boss.Position.X;
			var deltaY = playerPosition.Y - boss.Position.Y;

			var vector = (X: Normalize(deltaX), Y: Normalize(deltaY));
			
			return vector;


			static int Normalize(int number)
			{
				if (number == 0)
					return 0;

				return number / Math.Abs(number);
			}
		}

		private bool CanBossMove(IBoss boss)
		{
			if (!bossDictionary.ContainsKey(boss))
				bossDictionary.Add(boss, BossWaitTime + 1);

			bossDictionary[boss]--;
			var waitTime = bossDictionary[boss];

			if (waitTime != 0)
				return false;

			bossDictionary[boss] = BossWaitTime + Rnd.Next(1, 4);
			return true;
		}

		private (int x, int y) MoveRandom()
		{
			var x = Rnd.Next(-1, 2);
			var y = Rnd.Next(-1, 2);

			return (x, y);
		}
	}
}
