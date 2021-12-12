using System;
using System.Collections.Generic;
using System.Text;

namespace snakesnake
{
    /// <summary>
    /// горизонтальные линии, наследуется от фигуры
    /// 
    //наследование это свойство системы,
    //позволяющее писать новый класс на основе существующего
    //частично или польностью замещающийся функционально
    /// </summary>
    class HorizontalLine : Figure
    {
        
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            //конструктор, метод, который вызывается при создании линий
            pList = new List<Point>();
            //создание точек с нужными координатами и дабавление в список точек
            for (int x=xLeft; x<=xRight;x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
            
        }


    }
}
