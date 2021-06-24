using System;

namespace ResidentEvil.Interfaces
{
	internal interface IEnemy : ICharacter
	{
		event Action<IEnemy, DateTime> DeathEvent;

		void Attack(IPlayer player);

		void TakeDamage(IPlayer player);
	}
}
