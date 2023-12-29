using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    class Rectangle : IRegion
    {
       
        public decimal length;
        public decimal breadth;
        public int x;
        public int y;

        public Rectangle() { }
        public Rectangle(decimal length, decimal breadth)
        {
            this.length = length;
            this.breadth = breadth;
        }

        public byte NoOfEdges => 4;
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal GetArea()
        {
            return length * breadth;
        }

        public bool Intersect(IRegion other)
        {
            if (other is Rectangle)
            {
                Rectangle otherRectangle = (Rectangle)other;
                return this.x < otherRectangle.x + otherRectangle.length &&
                       this.x + this.length > otherRectangle.x &&
                       this.y < otherRectangle.y + otherRectangle.breadth &&
                       this.y + this.breadth > otherRectangle.y;
            }
            else if (other is Circle)
            {
                // Implement logic for intersection with other shapes if needed
                return false;
            }
            else if (other is Triangle)
            {

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

            length = length + scaleX;
            breadth = breadth + scaleY;
            return true;
        }

    }
}
