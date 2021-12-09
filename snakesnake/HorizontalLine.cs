using System;
using System.Collections.Generic;
using System.Text;

namespace snakesnake
{
    /// <summary>
    /// горизонтальные линии
    /// </summary>
    class HorizontalLine : Figure
    {
        
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x=xLeft; x<=xRight;x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
            
        }


    }
}
