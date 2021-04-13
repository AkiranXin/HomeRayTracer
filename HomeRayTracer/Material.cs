using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Material
    {
        public virtual bool Scatter(Ray rIn, HitRecord rec, ref Vector3 attenuation, ref Ray scattered)
        {
            return false;
        }
    }
}
