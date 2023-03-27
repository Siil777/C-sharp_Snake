using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class HorizontalLine:figure
    {
        
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xLeft; x < xRight; x++)
            {
                Point p = new Point(x, y, sym);
                
                pList.Add(p);

            }


        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            // и по очередно выводим на экран каждую точку 
            foreach (Point p in pList)
            {
                p.Draw();

            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
