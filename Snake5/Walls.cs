using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class Walls
    {
        List<figure> wallList;


        public Walls(int mapWidth, int mapHeight)
        {
           
            wallList = new List<figure>();

            HorizontalLine topLine = new HorizontalLine(0, mapWidth - 2, 0, '%');
            HorizontalLine bottomline = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '%');
           

            VerticalLine leftline = new VerticalLine(0, mapHeight - 1, 0, '%');
            VerticalLine rightline = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '%');

            wallList.Add(topLine);
            wallList.Add(bottomline);

            wallList.Add(leftline);
            wallList.Add(rightline);

        }
        internal bool IsHit(figure Figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(Figure))
                {
                    return true;

                }

            }
            return false;
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();

            }
        }


    }
}
