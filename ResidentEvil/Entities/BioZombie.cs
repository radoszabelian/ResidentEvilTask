using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResidentEvil.Entities
{
    public class BioZombie : Enemy
    {
        protected float radiation;

        public BioZombie(IPosition _position, int _health, float _radiation) : base(_position, _health)
        {
            radiation = _radiation;
        }

        public float Radiation
        {
            get
            {
                return radiation;
            }
            set
            {
                if (value >= 0 && value <= 2)
                {
                    radiation = value;
                }
            }
        }

        public override int Damage
        {
            get
            {
                return (int) Math.Round(radiation * 10, 1);
            }
        }

        public override char DisplayChar
        {
            get;
        } = 'b';

    }
}
