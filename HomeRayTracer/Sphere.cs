using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Sphere : Hitable
    {
        private double radius;
        private Point3D center;
        private Material material;

        public override bool Hit(Ray r, double tMin, double tMax, ref HitRecord rec)
        {
            Vector3 oc = r.Origin - center;
            double a = Vector3.DotProduct(r.Direction, r.Direction);
            double b = Vector3.DotProduct(oc, r.Direction);
            double c = Vector3.DotProduct(oc, oc) - radius * radius;
            double discriminant = b * b - a * c;
            if(discriminant > 0)
            {
                double temp = (-b - Math.Sqrt(b * b - a * c)) / a;
                if(temp < tMax && temp > tMin)
                {
                    rec.T = temp;
                    rec.P = r.PointAtPara(rec.T);
                    rec.Normal = (rec.P - center) / radius;
                    rec.Material = material;
                    return true;
                }
                temp = temp = (-b + Math.Sqrt(b * b - a * c)) / a;
                if (temp < tMax && temp > tMin)
                {
                    rec.T = temp;
                    rec.P = r.PointAtPara(rec.T);
                    rec.Normal = (rec.P - center) / radius;
                    rec.Material = material;
                    return true;
                }
            }
            return false;
        }

        public Sphere() { }

        public Sphere(Point3D center, double radius, Material material)
        {
            this.radius = radius;
            this.center = center;
            this.material = material;
        }

        public double Radius { get => radius; set => radius = value; }
        internal Point3D Center { get => center; set => center = value; }
        internal Material Material { get => material; set => material = value; }
    }
}
