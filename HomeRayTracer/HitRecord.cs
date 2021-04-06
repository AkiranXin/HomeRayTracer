using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class HitRecord
    {
        private double t;
        private Vector3 p;
        private Vector3 normal;
        private Material material;

        public double T { get => t; set => t = value; }
        internal Vector3 P { get => p; set => p = value; }
        internal Vector3 Normal { get => normal; set => normal = value; }
        internal Material Material { get => material; set => material = value; }
    }
}
