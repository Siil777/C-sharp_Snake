using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class HorizontalObstacleLine:figure
    {
        public HorizontalObstacleLine(int xLeft,int xRight, int y, char sym) 
        {
            pList=new List<Point>();
            for (int x = xLeft; x < xRight; x++)
            {
                Point p = new Point(x, y, sym);
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
