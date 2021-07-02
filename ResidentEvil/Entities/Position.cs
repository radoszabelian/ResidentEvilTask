using ResidentEvil.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResidentEvil.Entities
{
    public struct Position : IPosition
    {
        int x;
        int y;

        public Position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public int X
        {
            get => x;
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get => y;
            set {
                y = value;
            }
        }
    }
}
