using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class Obstacles
    {
        List<figure> wallList;

        public Obstacles(int mapWidth, int mapHeight)
        {
            wallList = new List<figure>();

            //int centerX = mapWidth / 2; // Get the x-coordinate of the center of the screen
            //int centerY = mapHeight / 2; // Get the y-coordinate of the center of the screen

            // Create a vertical line at the center of the screen
            VerticalObstacleLine centerLine = new VerticalObstacleLine(10, mapWidth - 5, mapHeight + 5, '#');
            
           
            wallList.Add(centerLine);
        }
        internal bool IsHit(figure Figure)
        {
            foreach (var wal in wallList)
            {
                if (wal.IsHit(Figure))
                {
                    return true;

                }

            }
            return false;
        }
        public void Draw()
        {
            Console.ForegroundColor=ConsoleColor.Red;
            foreach (var wal in wallList)
            {
                wal.Draw();

            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
