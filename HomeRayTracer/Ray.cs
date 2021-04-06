using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Ray
    {
        private Point3D origin;
        private Vector3 direction;

        public Ray() { }

        public Ray(Point3D origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        internal Point3D Origin { get => origin; set => origin = value; }
        internal Vector3 Direction { get => direction; set => direction = value; }

        public Vector3 PointAtPara(double t)
        {
            return origin + new Point3D(t * direction.X, t * direction.Y, t * direction.Z);
        }


    }
}
