using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Point3D
    {
        private double x;
        private double y;
        private double z;

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public static Vector3 operator- (Point3D a, Point3D b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator+ (Point3D a, Point3D b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
    }
}
