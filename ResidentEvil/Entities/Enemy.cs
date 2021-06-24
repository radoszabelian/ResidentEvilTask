using ResidentEvil.BusinessLogic.Help;
using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResidentEvil.Entities
{
    public abstract class Enemy : IEnemy
    {
        protected IPosition position;
        protected int health;

        public Enemy(IPosition _position, int _health)
        {
            position = _position;
            health = _health;
        }

        public IPosition Position
        {
            get
            {
                return position;
            }
        }

        public virtual int Health
        {
            get
            {
                return health;
            }
        }

        public abstract int Damage { get; }

        public abstract char DisplayChar { get; }

        public event Action<IEnemy, DateTime> DeathEvent;

        public virtual void Attack(IPlayer player)
        {
            player.TakeDamage(this);
        }

        public virtual void TakeDamage(IPlayer player)
        {
            if (Helper.IsAlive(player))
            {
                health = health - player.Damage < 0 ? 0 : health - player.Damage;

                if (health == 0)
                {
                    DeathEvent(this, DateTime.Now);
                }
            }
        }

        public override string ToString()
        {
            return $"{GetType()} - health: ({Health}), damage: ({Damage})";
        }
    }
}
