﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class Snake:figure
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
            // Method First give back the fisrt element of a list
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
            //throw new NotImplementedException();
        }
        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        // создания функции если змейка сталкнулась с хваостом
        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                // есть ли пересечение головы с точкой хваоста
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
            //если точка где окажеться змейка на следующем ходу совподает с едой то 
            //змейка ест
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                // Змейка растет,символ меняется
                food.sym = head.sym;
                pList.Add(food);
                return true;

            }
            else

                return false;

        }

    }
}