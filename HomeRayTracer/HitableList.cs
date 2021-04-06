using System;
using System.Collections.Generic;
using System.Text;

namespace HomeRayTracer
{
    class HitableList : Hitable
    {
        private List<Hitable> list;
        private int listSize;

        public override bool Hit(Ray r, double tMin, double tMax, ref HitRecord rec)
        {
            HitRecord tempRec = new HitRecord();
            bool hitAnything = false;
            double closestSoFar = tMax;
            for(int i = 0; i < listSize; i++)
            {
                if(list[i].Hit(r, tMin, closestSoFar, ref tempRec))
                {
                    hitAnything = true;
                    closestSoFar = tempRec.T;
                    rec = tempRec;
                }
            }
            return hitAnything;
        }

        public HitableList() { }

        public HitableList(List<Hitable> list, int listSize)
        {
            this.list = list;
            this.listSize = listSize;
        }

        public int ListSize { get => listSize; set => listSize = value; }
        internal List<Hitable> List { get => list; set => list = value; }
    }
}
