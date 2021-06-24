using ResidentEvil.Interfaces;
using System;

namespace ResidentEvil.Entities
{
    public sealed class Nemesis : Enemy, IBoss
    {
        private int damage;

        public Nemesis(IPosition _position, int _health, int _damage) : base(_position, _health)
        {
            damage = _damage;
        }

        public override int Damage => damage;

        public override char DisplayChar => 'n';

        public void Regenerate()
        {
            health++;
        }
    }
}
