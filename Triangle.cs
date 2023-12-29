using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    class Triangle : IRegion
    {
   
        public decimal width;
        public decimal height;
        public int x;
        public int y;

        public Triangle() { }
        public Triangle(decimal width, decimal height)
        {
            this.width = width;
            this.height = height;
        }

        public byte NoOfEdges => 3;
        public int Id { get; set; }
        public string Name { get; set; }

        

        public decimal GetArea()
        {
            return (0.5m) * width * height;
        }
        //to implement intersect logic 
        public bool Intersect(IRegion other)
        {
            if (other is Triangle)
            {
                Triangle otherTriangle = (Triangle)other;


                return false;
            }
            else if (other is Circle)
            {
            }
            else if (other is Rectangle)
            {

            }
            return false;
        }

        public void MoveRegion(int offsetX, int offsetY)
        {
            x = x + offsetX;
            y = y + offsetY;
        }

        public bool Resize(int ScaleX, int ScaleY)
        {
            width = width + ScaleX;
            height = height + ScaleY;
            return true;
        }
    }
}
