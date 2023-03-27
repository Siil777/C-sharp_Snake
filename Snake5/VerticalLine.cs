using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class VerticalLine:figure
    {
        
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y < yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);

            }
        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            // и по очередно выводим на экран каждую точку 
            foreach (Point p in pList)
            {
                p.Draw();

            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
