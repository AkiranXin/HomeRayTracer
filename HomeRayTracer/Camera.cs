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

        public Camera(Point3D lookfrom, Point3D lookat, Vector3 vup, double vfov, double aspect)
        {
            Vector3 u = new Vector3();
            Vector3 v = new Vector3();
            Vector3 w = new Vector3();
            double thete = vfov * Math.PI / 180;
            double halfHeight = Math.Tan(thete / 2);
            double halfWidth = aspect * halfHeight;
            origin = lookfrom;
            w = Vector3.UnitVector(lookfrom - lookat);
            u = Vector3.UnitVector(Vector3.CrossProduct(vup, w));
            v = Vector3.CrossProduct(w, u);
            Vector3 lowerLeftCornerTemp = origin - halfWidth * u - halfHeight * v - w;
            lowerLeftCorner = new Point3D(lowerLeftCornerTemp.X, lowerLeftCornerTemp.Y, lowerLeftCornerTemp.Z);
            horizontal = 2 * halfWidth * u;
            vertical = 2 * halfHeight * v;

        }

        internal Point3D LowerLeftCorner { get => lowerLeftCorner; set => lowerLeftCorner = value; }
        internal Vector3 Horizontal { get => horizontal; set => horizontal = value; }
        internal Vector3 Vertical { get => vertical; set => vertical = value; }
        internal Point3D Origin { get => origin; set => origin = value; }
    }
}
