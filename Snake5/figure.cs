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
        //отсюда вызываем реализацию метода IsHit для Walls
        internal bool IsHit(figure figure)
        {
            //Проверка пересечения точек, перебераем все точки в figure
            foreach (var p in pList)
            {
                //спраштваем figure которую мы передали в качестве аргумента если пересекается 
                //ли с какой либо точкой
                //IsHit в качестве аргумента (p) вызываем private bool IsHit(Point point)
                if (figure.IsHit(p))
                    return true;


            }
            return false;
        }
        //здесь точка
        //одна из особенностей полиморфизма две функции IsHit, но принимают разные
        // аргументы
        //Здесь принимаем точку
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
