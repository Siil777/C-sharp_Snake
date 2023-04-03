using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class VerticalObstacleLine:figure
    {
        public VerticalObstacleLine(int yUp,int yDown, int x, char sym)
        {
            pList=new List<Point>();
            for (int y = yUp; y < yDown; y++)
            {
                Point p=new Point(x,y,sym);
                pList.Add(p);

            }

        }

        public override void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();

            }
        }
    }
}
