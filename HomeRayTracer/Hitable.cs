using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Hitable
    {
        public virtual bool Hit(Ray r, double tMin, double tMax, ref HitRecord rec)
        {
            return false;
        }
    }
}
