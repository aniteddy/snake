using System;

namespace snakesnake
{
    /// <summary>
    /// класс создания еды и её отрисовки
    /// </summary>
    class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;

        Random random = new Random();


        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidth - 3);
            int y = random.Next(2, mapHeight - 3);
            return new Point(x, y, sym);
        }
    }
}