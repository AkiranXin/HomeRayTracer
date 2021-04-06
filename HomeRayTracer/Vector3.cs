using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Vector3
    {
        private double x;
        private double y;
        private double z;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public Vector3() { }
        public Vector3(double x, double y, double z) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public static Vector3 operator+(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator+(Point3D a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        
        public static Vector3 operator+(Vector3 a, Point3D b)
        {
            return new Vector3(a.x + b.X, a.y + b.Y, a.z + b.Z);
        }

        public static Vector3 operator-(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator-(Vector3 b)
        {
            return new Vector3(-b.x, -b.y, -b.z);
        }

        public static Vector3 operator-(Point3D a, Vector3 b)
        {
            return new Vector3(a.X - b.x, a.Y - b.y, a.Z - b.z);
        }

        public static Vector3 operator -(Vector3 a, Point3D b)
        {
            return new Vector3(a.x - b.X, a.y - b.Y, a.z - b.Z);
        }

        public static Vector3 operator *(Vector3 a, double b)
        {
            return new Vector3(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector3 operator *(double a, Vector3 b)
        {
            return new Vector3(a * b.x, a * b.y, a * b.z);
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X * b.x, a.Y * b.y, a.Z * b.z);
        }

        public static Vector3 operator /(Vector3 a, double b)
        {
            return new Vector3(a.X / b, a.Y / b, a.Z / b);
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public double SquaredLength()
        {
            return x * x + y * y + z * z;
        }

        public void MakeUnitVector()
        {
            double k = 1 / Length();
            x *= k;
            y *= k;
            z *= k;
        }

        public static double DotProduct(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vector3 CrossProduct(Vector3 a, Vector3 b)
        {
            return new Vector3(a.Y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }

        public static Vector3 UnitVector(Vector3 v)
        {
            return v / v.Length();
        }
    }
}
