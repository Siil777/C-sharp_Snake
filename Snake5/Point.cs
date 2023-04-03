using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class Point
    {
        //класс тип данных такойже как целые числа или символы
        // класс в первую очередь хранит данные
        public int x;
        public int y;
        public char sym;
        //Конструктор  будет вызываться при каждом создании новой точки
        // Помогает сократить код
        public Point()
        {
            //Console.WriteLine("creat a new point");
        }
        //Новый конструкор что бы задать тип данных который будет приниматься при его вызове
        public Point(int x, int y, char sym)
        {
            //заполнить значения в переменных относящихся к данной точке
            this.x = x;
            this.y = y;
            this.sym = sym;
        }
        // Создание точки с помощью другой точки
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }
        // Move будет сдвигать точку public Point(Point p)  на расстояние offset в направление direction
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.Right)
            {
                //если направление в право то координата x увеличивается на размер смещение
                x = x + offset;
            }
            else if (direction == Direction.Left)
            {
                x = x - offset;
            }
            else if (direction == Direction.Up)
            {
                y = y - offset;
            }
            else if (direction == Direction.Down)
            {
                y = y + offset;
            }
        }
        //есть ли пересечение тикущей точки с той точкой которую передал в качетсве аргумента
        // связь с Snake class,Figure
        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
        //класс point состоит из данных и теперь еще из функции котороя управляет этими данными
        // функция для вывода точек на экран(переиспользованный функционал)
        // в качестве входных параметров координаты и символ
        //функция не знает ничего не о x2,y2 потому что они в другой соседней функции
        // Скрывает детали реализации вывода точек на экран
        //Не возврощает значения, выполняет процедуры

        public void Draw()
        {
            // sets the position of the curso
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
        //метод Clear вызывается в классе snake в функции internal void Move() стирает 
        //хвост змейки
        public void Clear()
        {
            //Символ становиться пробел
            sym = ' ';
            Draw();
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}
