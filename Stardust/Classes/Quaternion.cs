using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.Classes
{
    public class Quaternion
    {
        public float x { get; set; }

        public float y { get; set; }

        public float z { get; set; }

        public float w { get; set; }

        public Quaternion(float X, float Y, float Z, float W)
        {
            x = X;
            y = Y;
            z = Z;
            w = W;
        }
    }
}
