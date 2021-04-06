using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Metal : Material
    {
        private Vector3 albedo; //漫反射率
        private double fuzz; //模糊参数

        public Metal(Vector3 albedo, double fuzz)
        {
            this.albedo = albedo;
            this.fuzz = fuzz;
        }

        public double Fuzz { get => fuzz; set => fuzz = value; }
        internal Vector3 Albedo { get => albedo; set => albedo = value; }

        public override bool Scatter(Ray rIn, HitRecord rec, ref Vector3 attenuation, ref Ray scattered)
        {
            Vector3 reflected =
                RTUtils.Reflect(Vector3.UnitVector(rIn.Direction), rec.Normal);
            scattered = new Ray(new Point3D(rec.P.X, rec.P.Y, rec.P.Z), reflected + fuzz * RTUtils.RandomInUnitSphere());
            attenuation = albedo;
            return (Vector3.DotProduct(scattered.Direction, rec.Normal) > 0);
        }
    }
}
