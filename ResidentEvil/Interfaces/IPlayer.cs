using System;

namespace ResidentEvil.Interfaces
{
	internal interface IPlayer : ICharacter
	{
		event Action<IPlayer, IEnemy, DateTime> DeathEvent;
		event Action<IPlayer, IEnemy, DateTime> HitEvent;

		string Name { get; }

		void Attack(IEnemy enemy);
		void TakeDamage(IEnemy enemy);
	}
}
