using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeRayTracer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;

        private void button1_Click(object sender, EventArgs e)
        {
            int nx = 1080;
            int ny = 1080;
            int ns = 10;
            bmp = new Bitmap(nx, ny);

            Random rd = new Random();

            List<Hitable> list = new List<Hitable>();
            list.Add(new Sphere(new Point3D(0, 0, -1), 0.5, new Lambertian(new Vector3(0.8, 0.3, 0.3))));
            list.Add(new Sphere(new Point3D(0, -100.5, -1), 100, new Lambertian(new Vector3(0.8,0.8,0.0))));
            list.Add(new Sphere(new Point3D(1, 0, -1), 0.5, new Metal(new Vector3(0.8, 0.6, 0.2),0.3)));
            list.Add(new Sphere(new Point3D(-1, 0, -1), 0.5, new Metal(new Vector3(0.8, 0.8, 0.8),1)));
            HitableList world = new HitableList(list, 4);
            Camera cam = new Camera();

            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < ny; j++)
                {

                    Color3D col = new Color3D();
                    for(int s = 0; s < ns; s++)
                    {
                        double u = (double)(i+rd.NextDouble()) / (double)nx;
                        double v = (double)(j+rd.NextDouble()) / (double)ny;
                        Ray r = cam.GetRay(u, v);
                        Color3D colTemp = RTUtils.Color(r, world, 0);
                        col.R += colTemp.R;
                        col.G += colTemp.G;
                        col.B += colTemp.B;
                    }
                    col.R /= ns;
                    col.G /= ns;
                    col.B /= ns;

                    col = new Color3D(Math.Sqrt(col.R), Math.Sqrt(col.G), Math.Sqrt(col.B));

                    int ir = (int)(255.99 * col.R);
                    int ig = (int)(255.99 * col.G);
                    int ib = (int)(255.99 * col.B);
                    bmp.SetPixel(i, ny - j - 1, Color.FromArgb(ir, ig, ib));
                }
            }
            pictureBox1.BackgroundImage = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmp.Save("1.png");
        }
    }
}
