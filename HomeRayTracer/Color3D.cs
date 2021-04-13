using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class Color3D
    {
        private double r;
        private double g;
        private double b;

        public Color3D() { }

        public Color3D(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }



        public double R { get => r; set => r = value; }
        public double G { get => g; set => g = value; }
        public double B { get => b; set => b = value; }
    }
}
