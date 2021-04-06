using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class RTUtils
    {
        private static Random rd = new Random();
        public static Vector3 RandomInUnitSphere()
        {
            Vector3 p = new Vector3();
            do
            {
                p = 2.0 * new Vector3(rd.NextDouble(), rd.NextDouble(), rd.NextDouble()) - new Point3D(1, 1, 1);
            } while (p.SquaredLength() >= 1.0);

            return p;
        }

        public static Vector3 Reflect(Vector3 v, Vector3 n)
        {
            return v - 2 * Vector3.DotProduct(v, n) * n;
        }

        public static Color3D Color(Ray r, Hitable world, int depth)
        {
            HitRecord rec = new HitRecord();
            if(world.Hit(r,0.001,double.MaxValue,ref rec))
            {
                Ray scattered = new Ray();
                Vector3 attenuation = new Vector3();
                if(depth < 50 && rec.Material.Scatter(r,rec,ref attenuation,ref scattered))
                {
                    Color3D colorTemp = Color(scattered, world, depth + 1);
                    colorTemp.R *= attenuation.X;
                    colorTemp.G *= attenuation.Y;
                    colorTemp.B *= attenuation.Z;
                    return colorTemp;
                }
                else
                {
                    return new Color3D(0, 0, 0); 
                }

                //Vector3 target = rec.P + rec.Normal + RandomInUnitSphere();
                //Color3D colorTemp = Color(new Ray(new Point3D(rec.P.X, rec.P.Y, rec.P.Z), target - rec.P), world);
                //colorTemp.R *= 0.5;
                //colorTemp.G *= 0.5;
                //colorTemp.B *= 0.5;
                //return  colorTemp;
            }
            else
            {
                Vector3 unitDirection = Vector3.UnitVector(r.Direction);
                double t = 0.5 * (unitDirection.Y + 1.0);
                return new Color3D((1.0 - t) + t * 0.5, (1.0 - t) + t * 0.7, (1.0 - t) + t * 1);
            }
        }
    }
}
