using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidAStar
{
    public class Position
    {
        public float X;
        public float Y;

        public float Distance(Position other)
        {
            return (float)Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));
        }

        public Position(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
