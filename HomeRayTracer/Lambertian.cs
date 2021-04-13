using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Lambertian : Material
    {
        private Vector3 albedo;//漫反射系数

        public override bool Scatter(Ray rIn, HitRecord rec, ref Vector3 attenuation, ref Ray scattered)
        {
            Vector3 target = rec.P + rec.Normal + RTUtils.RandomInUnitSphere();
            scattered = new Ray(new Point3D(rec.P.X, rec.P.Y, rec.P.Z), target - rec.P);
            attenuation = albedo;
            return true;
        }


        public Lambertian(Vector3 albedo)
        {
            this.albedo = albedo;
        }

        internal Vector3 Albedo { get => albedo; set => albedo = value; }
    }
}
