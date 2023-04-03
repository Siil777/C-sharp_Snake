using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class Snake : figure
    {
        // Класс snake тпереь хранит направление
        Direction direction;

        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();

            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                // в первом ветке цикла хвостовая позиция сдвигация на позицию 0
                p.Move(i, direction);
                // и попадет в список
                // во второй итерации точка сдвигается на 1 
                pList.Add(p);

            }
        }
        // кусочек кода соответсвующий методу MOve для реалезации

        internal void Move()
        {
            //Метод First возврощает первый элемент списка

            Point tail = pList.First();
            // точка котрорая соответсвовала хвосту она больше не пренаджеит данной змейке
            //поэтому Remove()
            pList.Remove(tail);
            //что бы определить куда будет двигаться голова нужен специальный метод
            //Переменная head заполнится значением которое вернет функцию GetNextPoint
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
            
        }
        //функция вычисляет в какой точке оказывается змейка в следующий момент
        public Point GetNextPoint()
        {
            //текущая позиция головы до того как змейка перемистилась, через метод Last();
            Point head = pList.Last();
            // Затем создается точка которая является копией предыдущего положения головы
            Point nextPoint = new Point(head);
            //и теперь точка сдвигается по направлению direction
            //напрвление которое сохранено в переменной записаной под class Snake:Figure
            nextPoint.Move(1, direction);
            return nextPoint;

        }
   
        // создания функции если змейка сталкнулась с хваостом
        internal bool IsHitTail()
        {
            //Сначала получаем координаты точки головы
            var head = pList.Last();
            //проверка есть ли совподение между точкой головы и точками всего оставшегося
            //хвоста
            //перебераем все точки от хвоста 0-я позиция, до точки предшествующей голове pList.Count-2
            for (int i = 0; i < pList.Count - 2; i++)
            {
                //есть ли пересечения точки головы с точкой i = 0, то-есть
                // pList[i] i=0 хвост
                if (head.IsHit(pList[i]))
                    return true;


            }
            return false;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.Left;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.Right;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.Down;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.Up;
        }
        internal bool Eat(Point food)
        {

            //получаем точку соответсвующую соедующему положению головы змейки
            //если точка где змейка окажется на следующем ходу совподает по координатам с едой..
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                //меняется символ потому-что теперь это часть змейки
                food.sym = head.sym;
                // добовляем символ в список
                pList.Add(food);
                return true;

            }
                return false;

        }
    

    }
}
