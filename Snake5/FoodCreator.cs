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
        // габариты карты и символ
        //переменные в качестве аргумента

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;

        }
        public Point CreatFood()
        {
            int x = random.Next(2, mapWidth);
            int y = random.Next(2, mapHeight);
            return new Point(x, y, sym);
        }

    }
}
