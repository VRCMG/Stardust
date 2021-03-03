using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.Classes
{
    public class Vector3
    {
        public float x { get; set; }

        public float y { get; set; }

        public float z { get; set; }

        public Vector3(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}
