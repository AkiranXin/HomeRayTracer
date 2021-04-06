using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Camera
    {
        private Point3D lowerLeftCorner;
        private Vector3 horizontal;
        private Vector3 vertical;
        private Point3D origin;

        public Ray GetRay(double u, double v)
        {
            return new Ray(origin, lowerLeftCorner + u * horizontal + v * vertical - origin);
        }

        public Camera()
        {
             lowerLeftCorner = new Point3D(-2, -1, -1);
             horizontal = new Vector3(4, 0, 0);
             vertical = new Vector3(0, 2, 0);
             origin = new Point3D(0, 0, 0);
        }

        internal Point3D LowerLeftCorner { get => lowerLeftCorner; set => lowerLeftCorner = value; }
        internal Vector3 Horizontal { get => horizontal; set => horizontal = value; }
        internal Vector3 Vertical { get => vertical; set => vertical = value; }
        internal Point3D Origin { get => origin; set => origin = value; }
    }
}
