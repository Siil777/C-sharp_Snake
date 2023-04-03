using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class FoodCreator
    {

        //переменные которые хранит объект класса
        int mapWidth;
        int mapHeight;
        char sym;

        Random random = new Random();
        // Конструктор,ширина,высота и символ в качетсве еды
        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            //this это переменная непосредственно которая задана в начале классе class FoodCreator
            //без this это переменная из конструктора
            //переменные this значение по умолчнаю, без this в качестве аргумента
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;

        }
        // Через функцию CreatFood генерируем произвольные координаты в пределах карты указаных в
        // конструкторе  public FoodCreator(int mapWidth, int mapHeight, char sym)
        public Point CreatFood()
        {
            int x = random.Next(2, mapWidth);
            int y = random.Next(2, mapHeight);
            // и создаем точку с этими координатами
            return new Point(x, y, sym);
        }

    }
}
