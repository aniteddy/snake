using System;
using System.Collections.Generic;
using System.Text;

namespace snakesnake
{
    /// <summary>
    /// обработчик столкновений
    /// </summary>
    class Figure
    {
        //модификатор доступа, что бы лист был виден у наследников
        protected List<Point> pList;

        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        internal bool IsHit (Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                {
                    return true;
                }
            }
            return false;
        }

        

        private bool IsHit(Point point)
        {
            foreach(var p in pList)
            {
                if (p.IsHit(point))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
