using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResidentEvil.Entities
{
    public sealed class Tyrant : Enemy, IBoss
    {
        private int damage;
        private bool hasRegenerated;
        private int originalHealth;

        public Tyrant(IPosition _position, int _health, int _damage) : base(_position, _health)
        {
            damage = _damage;
            hasRegenerated = false;
            originalHealth = _health;
        }

        public override int Damage => damage;

        public override char DisplayChar => 't';

        public void Regenerate()
        {
            if (!hasRegenerated)
            {
                health = originalHealth;
                hasRegenerated = true;
            }
        }
    }
}
