using System;
using System.Collections.Generic;
using System.Threading;

namespace snakesnake
{
	class Program
	{

		static void Main(string[] args)
		{
			//Таймер
			// Create a Timer object that knows to call our TimerCallback
			// method once every 2000 milliseconds.
			Timer t = new Timer(TimerCallback, null, 0, 2000);
			// Wait for the user to hit <Enter>
			WriteText("Время: " + Convert.ToString(eatcount), Width, 2);

			//счётчик еды
			int eatcount = 0;
			//установить размер окна
			int Width = 80;
			int Height = 25;
            Walls walls = new Walls(Width, Height);
			walls.Draw();

			// Отрисовка точек	(применяется инкапсуляция)
			// (свойство системы, позволяющее объединить данные и методы, работающие с ними, в классе и скрыть детали реализации от пользователя)		
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			//создание еды
			FoodCreator foodCreator = new FoodCreator(Width, Height, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			//если змека ударилась о стену или о свой хвост, то игра закончена
			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();
					eatcount++;
					//Console.SetCursorPosition(Width, 2);
					WriteText("Счёт: " + Convert.ToString(eatcount), Width, 2);
					
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				//считывание стрелок, двеижение змеи
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			WriteGameOver();
			Console.ReadLine();
		}

		private static void TimerCallback(Object o)
		{
			// Display the date/time when this method got called.
			Console.WriteLine("In TimerCallback: " + DateTime.Now);
			// Force a garbage collection to occur for this demo.
			GC.Collect();
		}

		static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			WriteText("============================", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

	}
}