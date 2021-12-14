using System;
using System.Collections.Generic;
using System.Text;

namespace snakesnake
{
	/// <summary>
	/// класс точка для отрисовки точек
	/// </summary>
	class Point
	{
		public int x;
		public int y;
		public char sym;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="sym"></param>
		public Point(int x, int y, char sym)
		{
			this.x = x;
			this.y = y;
			this.sym = sym;
		}

		public Point(Point p)
		{
			x = p.x;
			y = p.y;
			sym = p.sym;
		}

		public void Move(int offset, Direction direction)
		{
			if (direction == Direction.RIGHT)
			{
				x = x + offset;
			}
			else if (direction == Direction.LEFT)
			{
				x = x - offset;
			}
			else if (direction == Direction.UP)
			{
				y = y - offset;
			}
			else if (direction == Direction.DOWN)
			{
				y = y + offset;
			}
		}

		//проверка пересечения координат, одной точки с другой
		public bool IsHit(Point p)
		{
			return p.x == this.x && p.y == this.y;
		}

		/// <summary>
		/// отображение точки на консоли
		/// </summary>
		public void Draw()
		{
			Console.SetCursorPosition(x, y);
			Console.Write(sym);
		}

		public void Clear()
		{
			sym = ' ';
			Draw();
		}

		//public override string ToString()
		//{
		//	return x + ", " + y + ", " + sym;
		//}
	}
}
