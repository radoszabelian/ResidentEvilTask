using ResidentEvil.BusinessLogic.Help;
using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResidentEvil.Entities
{
    public sealed class Player : IPlayer
    {
        string name;
        int damage;
        int health;
        IPosition position;

        public Player(string _name, int _health, int _damage, IPosition _position)
        {
            name = _name;
            damage = _damage;
            health = _health;
            position = _position;
        }

        public string Name => name;

        public int Health => health;

        public int Damage => damage;

        public char DisplayChar => 'P';

        public IPosition Position => position;

        public event Action<IPlayer, IEnemy, DateTime> DeathEvent;
        public event Action<IPlayer, IEnemy, DateTime> HitEvent;

        public void Attack(IEnemy enemy)
        {
            if (Helper.IsAlive(enemy))
            {
                enemy.TakeDamage(this);
            }
        }

        public void TakeDamage(IEnemy enemy)
        {
            if (Helper.IsAlive(enemy))
            {
                health = Health - enemy.Damage < 0 ? 0 : Health - enemy.Damage;

                HitEvent?.Invoke(this, enemy, DateTime.Now);

                if (Health == 0)
                {
                    DeathEvent(this, enemy, DateTime.Now);    
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Health}";
        }
    }
}
