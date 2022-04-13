using System;
using System.Collections.Generic;
using System.Text;
using Snake.Infrastructure;

namespace Snake.Models.Foods
{
    class FoodGenerator
    {

        private Random random = new Random();
        private IMap Map { get; set; }
        public FoodGenerator(IMap map)
        {
            Map = map;
        }

        public Food Generat()
        {
            int x = random.Next(Map.X + 2, (Map.Width + Map.X) - 2);
            int y = random.Next(Map.Y + 2, (Map.Height + Map.Y) - 2);
            return new Food(x, y, 'O', ConsoleColor.DarkGreen, 1);
        }
    }
}
