using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class figure
    {
        // protected модификатор доступа что бы переменная pList была видна у наследников
        protected List<Point> pList;
        public virtual void Draw()
        {
            // и по очередно выводим на экран каждую точку 
            foreach (Point p in pList)
            {
                p.Draw();

            }
        }
        // здесь принмается фигура
        internal bool IsHit(figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;


            }
            return false;
        }
        //здесь точка
        private bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;


            }
            return false;

        }
    }
}
