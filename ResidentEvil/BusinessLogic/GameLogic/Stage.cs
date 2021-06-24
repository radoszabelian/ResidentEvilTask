using ResidentEvil.Interfaces;

namespace ResidentEvil.BusinessLogic.GameLogic
{
    internal class Stage: IStage
	{
		private int nextEmptyEnemyIndex = 0;

		private int enemyIndex = 0;

		public int Height { get; set; }
		public int Width { get; set; }

		public bool HasBorders { get; }

		public IPlayer Player { get; set; }
		public IEnemy[] Enemies { get; }

		public Stage(int numberOfEnemies, bool hasBorders)
		{
			Enemies = new IEnemy[numberOfEnemies];
			HasBorders = hasBorders;
		}

		public void AddEnemy(IEnemy enemy)
		{
			if (nextEmptyEnemyIndex < Enemies.Length)
			{
				Enemies[nextEmptyEnemyIndex] = enemy;
				nextEmptyEnemyIndex++;
			}
			else
			{
				throw new TooManyZombiesException("Not enough space in the zombies array!");
			}
			//todo: Add enemy to enemy array's next empty location.
			//If the array is full throw a custom made exception TooManyZombiesException and don't forget to add a message.
			//hint: Use an integer within the class to keep track of the next empty array index.
		}
	}
}
