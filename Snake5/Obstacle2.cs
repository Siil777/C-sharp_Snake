using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake5
{
    class Obstacle2
    {
        List<figure> wallist;
        public Obstacle2(int mapWidth, int mapHeight)
        {
            wallist = new List<figure>();
            HorizontalObstacleLine centerLine = new HorizontalObstacleLine(5, mapWidth + 5, mapHeight -1, '#');
            wallist.Add(centerLine);

        }
        internal bool IsHit(figure Figure)
        {
            foreach (var wal in wallist)
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
            foreach (var wal in wallist)
            {
                wal.Draw();
            }
        }
     


    }
}
