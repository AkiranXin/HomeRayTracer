using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class RTUtils
    {
        public static Random rd = new Random();
        public static Vector3 RandomInUnitSphere()
        {
            Vector3 p = new Vector3();
            do
            {
                p = 2.0 * new Vector3(rd.NextDouble(), rd.NextDouble(), rd.NextDouble()) - new Point3D(1, 1, 1);
            } while (p.SquaredLength() >= 1.0);

            return p;
        }

        public static HitableList RandomScene()
        {
            Dielectrics dielectrics = new Dielectrics(1.5);
            List<Hitable> list = new List<Hitable>();
            Vector3 pp = new Vector3(0, -1000, 0);
            Vector3 center;
            list.Add(new Sphere(new Point3D(pp.X,pp.Y,pp.Z), 1000, new Lambertian(new Vector3(0.5, 0.5, 0.5))));
            for (int a = 0; a < 11; a++)
            {
                for (int b = 5; b < 11; b++)
                {
                    double chooseMat = rd.NextDouble();
                    center = new Vector3(a + 0.9 * rd.NextDouble(), 0.2, 0.9 * rd.NextDouble());
                    if ((center - new Vector3(4, 0.2, 0)).Length() > 0.9)
                    {
                        if (chooseMat < 0.8)
                        {
                            list.Add(new Sphere(new Point3D(center.X, center.Y, center.Z), 0.2, new Lambertian(new Vector3(rd.NextDouble() * rd.NextDouble(), rd.NextDouble() * rd.NextDouble(), rd.NextDouble() * rd.NextDouble()))));
                        }
                        else if (chooseMat < 0.95)
                        {
                            list.Add(new Sphere(new Point3D(center.X, center.Y, center.Z), 0.2, new Metal(new Vector3(0.5 * (1 + rd.NextDouble()), 0.5 * (1 + rd.NextDouble()), 0.5 * (1 + rd.NextDouble())), 0.5 * (1 + rd.NextDouble()))));
                        }
                        else
                        {
                            list.Add(new Sphere(new Point3D(center.X, center.Y, center.Z), 0.2, new Dielectrics(1.5)));
                        }
                    }
                }
            }
            //Vector3 center = new Vector3(1 + 0.9 * rd.NextDouble(), 0.2, 0.9 * rd.NextDouble());
            //list.Add(new Sphere(new Point3D(center.X, center.Y, center.Z), 0.2, new Lambertian(new Vector3(rd.NextDouble() * rd.NextDouble(), rd.NextDouble() * rd.NextDouble(), rd.NextDouble() * rd.NextDouble()))));
            //list.Add(new Sphere(new Point3D(center.X, center.Y, center.Z), 0.2, new Metal(new Vector3(0.5 * (1 + rd.NextDouble()), 0.5 * (1 + rd.NextDouble()), 0.5 * (1 + rd.NextDouble())), 0.5 * (1 + rd.NextDouble()))));
            //list.Add(new Sphere(new Point3D(center.X, center.Y, center.Z), 0.2, new Dielectrics(1.5)));
            Point3D pp1 = new Point3D(0, 1, 0);
            Point3D pp2 = new Point3D(-4, 1, 0);
            Point3D pp3 = new Point3D(4, 1, 0);
            list.Add(new Sphere(new Point3D(pp1.X, pp1.Y, pp1.Z), 1.0, new Dielectrics(1.5)));
            list.Add(new Sphere(new Point3D(pp2.X, pp2.Y, pp2.Z), 1.0, new Lambertian(new Vector3(0.4, 0.2, 0.1))));
            list.Add(new Sphere(new Point3D(pp3.X, pp3.Y, pp3.Z), 1.0, new Metal(new Vector3(0.7, 0.6, 0.5), 0)));
            return new HitableList(list,list.Count);
        }

        public  static double Schlick(double cosine, double refIdx)
        {
            double r0 = (1 - refIdx) / (1 + refIdx);
            r0 = r0 * r0;
            return r0 + (1 - r0) * Math.Pow((1 - cosine), 5);
        }

        public static bool Refract(Vector3 v, Vector3 n, double niOverNt, ref Vector3 refracted)
        {
            Vector3 uv = Vector3.UnitVector(v);
            double dt = Vector3.DotProduct(uv, n);
            double discriminant = 1.0 - niOverNt * niOverNt * (1 - dt * dt);
            if(discriminant > 0)
            {
                refracted = niOverNt * (uv - n * dt) - n * Math.Sqrt(discriminant);
                return true;
            }
            else
            {
                return false;
            }
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
