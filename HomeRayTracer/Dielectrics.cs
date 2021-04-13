using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Dielectrics : Material
    {
        private double refIdx; // 相对折射率
        public Dielectrics(double refIdx)
        {
            this.refIdx = refIdx;
        }

        public override bool Scatter(Ray rIn, HitRecord rec, ref Vector3 attenuation, ref Ray scattered)
        {
            Vector3 outwardNormal = new Vector3();
            Vector3 reflected = RTUtils.Reflect(rIn.Direction, rec.Normal);
            double niOverNt;
            attenuation = new Vector3(1, 1, 1); //衰减率
            Vector3 refracted = new Vector3();
            double reflect_prob;
            double cosine;
            if(Vector3.DotProduct(rIn.Direction,rec.Normal) > 0)
            {
                outwardNormal = rec.Normal * -1;
                niOverNt = refIdx;
                cosine = refIdx * Vector3.DotProduct(rIn.Direction, rec.Normal) / rIn.Direction.Length();
            }
            else
            {
                outwardNormal = rec.Normal;
                niOverNt = 1.0 / refIdx;
                cosine = -Vector3.DotProduct(rIn.Direction, rec.Normal) / rIn.Direction.Length();
            }

            if(RTUtils.Refract(rIn.Direction, outwardNormal, niOverNt, ref refracted))
            {
                reflect_prob = RTUtils.Schlick(cosine, refIdx);
            }
            else
            {
                scattered = new Ray(new Point3D(rec.P.X, rec.P.Y, rec.P.Z), reflected);
                reflect_prob = 1.0;
            }
            if(RTUtils.rd.NextDouble() < reflect_prob)
            {
                scattered = new Ray(new Point3D(rec.P.X, rec.P.Y, rec.P.Z), reflected);
            }
            else
            {
                scattered = new Ray(new Point3D(rec.P.X, rec.P.Y, rec.P.Z), refracted);
            }
            return true;
        }

        public double RefIdx { get => refIdx; set => refIdx = value; }
    }
}
