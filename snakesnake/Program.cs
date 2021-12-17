using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace snakesnake
{
	class Program
	{

		static void Main(string[] args)
		{
			Console.WriteLine("Введите имя пользователя");
			string UserName = Console.ReadLine();
			Console.Clear();
			//Словарь с результатами игроков
			//Dictionary<string, int> users = new Dictionary<string, int>();
			//счётчик еды
			int eatcount = 0;
			//установить размер окна
			int Width = 80;
			int Height = 25;
            Walls walls = new Walls(Width, Height);
			walls.Draw();

			//Таймер
			Stopwatch clock = new Stopwatch();


			// Отрисовка точек	(применяется инкапсуляция)
			// (свойство системы, позволяющее объединить данные и методы, работающие с ними, в классе и скрыть детали реализации от пользователя)		
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			//создание еды
			FoodCreator foodCreator = new FoodCreator(Width, Height, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();
			Point secondfood = foodCreator.CreateFood();
			secondfood.Draw();

			//если змека ударилась о стену или о свой хвост, то игра закончена
			while (true)
			{
				clock.Start();

				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();
					eatcount++;
					WriteText("Счёт: " + Convert.ToString(eatcount), Width, 2);
				}
				if (snake.Eat(secondfood))
				{
					secondfood = foodCreator.CreateFood();
					secondfood.Draw();
					eatcount++;
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

				//подсчёт и вывод времени
				clock.Stop();
				TimeSpan ts = clock.Elapsed;
				string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
				WriteText("Время: " + Convert.ToString(elapsedTime), Width, 3);
				
			}

			SetNewRecord(UserName, eatcount);
			WriteGameOver();
			PrintResult();
			Console.ReadLine();
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

		static void PrintResult()
        {
			int xOffset = 30;
			int yOffset = 12;
			string FileName = @"records.txt";
			List<string> fileContent = File.ReadAllLines(FileName).ToList();
            int LineCount;
            if (fileContent.Count > 10)
			{
				LineCount = 10;
            }
            else
            {
				LineCount = fileContent.Count;

			}

			for (int i = 0; i < LineCount; i++)
			{
				WriteText(fileContent[i], xOffset, yOffset++);
			}
		}


		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

		/// <summary>
		/// запись в блокнот рекордов, перезаписывает рекорд 
		/// если имя совпадает и этот рекорд больше предыдущего
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="eatcount"></param>
		static void SetNewRecord(string UserName, int eatcount)
		{
			string FileName = @"records.txt";
			List<string> fileContent = File.ReadAllLines(FileName).ToList();
			
			string record;
			int j=44444;
			for (int i = 0; i < fileContent.Count; i++)
			{
				string num = fileContent[i].Split(' ')[1];
				if (Convert.ToInt64(num) < eatcount)
				{
					j = 44444;
					record = $"{UserName} {eatcount}";
					fileContent.Insert(i, record);
					File.WriteAllLines(FileName, fileContent);
					break;
				}
				else 
                {
					j = i+1;
				}

			}

			if (j != 44444)
			{
				record = $"{UserName} {eatcount}";
				fileContent.Insert(j, record);
				File.WriteAllLines(FileName, fileContent);
            }
			
		}
	}
}