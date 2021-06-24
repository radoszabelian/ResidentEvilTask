using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResidentEvil.Entities
{
    public class RunningZombie : Enemy
    {
        private int stamina;

        public RunningZombie(IPosition _position, int _health, int _stamina) : base(_position, _health)
        {
            stamina = _stamina;
        }

        private int Stamina
        {
            get
            {
                return stamina;
            }

            set
            {
                if (value >= 0 && value <= 2)
                {
                    stamina = value;
                }
            }
        }

        public override int Damage
        {
            get
            {
                return Stamina + 5;
            }
        }

        public override char DisplayChar => 'r';
    }
}
