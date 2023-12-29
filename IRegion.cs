using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    interface IRegion
    {
        string Name
        {
            get;
        }
        byte NoOfEdges
        {
            get;
        }
        int Id
        {
            get;
        }

        decimal GetArea();
        void MoveRegion(int offsetX, int offsetY);
        bool Resize(int ScaleX, int ScaleY);
        bool Intersect(IRegion i);

    }
}
