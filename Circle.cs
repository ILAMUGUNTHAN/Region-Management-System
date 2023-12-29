using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    class Circle : IRegion
    {


        public decimal radius;
        public int x;
        public int y;

        public Circle() { }
        public Circle(decimal radius)
        {
            this.radius = radius;
        }


        public byte NoOfEdges => 0;
        public int Id { get; set; }
        public string Name { get; set; }


        public decimal GetArea()
        {
            return (22 / 7) * radius * radius;
        }

        public bool Intersect(IRegion other)
        {
            if (other is Circle)
            {
                Circle otherCircle = (Circle)other;
                double distanceBetweenCenters = Math.Sqrt(Math.Pow(this.x - otherCircle.x, 2) + Math.Pow(this.y - otherCircle.y, 2));
                return distanceBetweenCenters <= (double)this.radius + (double)otherCircle.radius;
            }
            else if (other is Rectangle)
            {
                //for 1st edge
                Rectangle otherRec = (Rectangle)other;
                double distanceBetweenCenters = Math.Sqrt(Math.Pow(this.x - otherRec.x, 2) + Math.Pow(this.y - otherRec.y, 2));
                if (distanceBetweenCenters <= (double)this.radius) return true;

                //for 2nd edge
                distanceBetweenCenters = Math.Sqrt(Math.Pow(this.x - (otherRec.x + (double)otherRec.breadth), 2) + Math.Pow(this.y - otherRec.y, 2));
                if (distanceBetweenCenters <= (double)this.radius) return true;

                //for 3rd edge
                distanceBetweenCenters = Math.Sqrt(Math.Pow(this.x - (otherRec.x), 2) + Math.Pow(this.y - otherRec.y + (double)otherRec.length, 2));
                if (distanceBetweenCenters <= (double)this.radius) return true;

                //for 4th edge
                distanceBetweenCenters = Math.Sqrt(Math.Pow(this.x - (otherRec.x + (double)otherRec.breadth), 2) + Math.Pow(this.y - otherRec.y + (double)otherRec.length, 2));
                if (distanceBetweenCenters <= (double)this.radius) return true;

            }
            else if (other is Triangle)
            {
                Triangle otherTri = (Triangle)other;

                //for 1st edge
                double distanceBetweenCenters = Math.Sqrt(Math.Pow(this.x - otherTri.x, 2) + Math.Pow(this.y - otherTri.y, 2));
                if (distanceBetweenCenters <= (double)this.radius) return true;

                //for 2nd edge
                distanceBetweenCenters = Math.Sqrt(Math.Pow(this.x - (otherTri.x - (double)otherTri.width / 2), 2) + Math.Pow(this.y - (otherTri.y + (double)otherTri.height), 2));
                if (distanceBetweenCenters <= (double)this.radius) return true;

                //for 3rd edge
                distanceBetweenCenters = Math.Sqrt(Math.Pow(this.x - (otherTri.x + (double)otherTri.width / 2), 2) + Math.Pow(this.y - (otherTri.y + (double)otherTri.height), 2));
                if (distanceBetweenCenters <= (double)this.radius) return true;

            }
            return false;
        }


        public void MoveRegion(int offsetX, int offsetY)
        {
            x = x + offsetX;
            y = y + offsetY;
        }

        public bool Resize(int scaleX, int scaleY)
        {
            radius = radius + scaleX;
            return true;
        }

    }
}
