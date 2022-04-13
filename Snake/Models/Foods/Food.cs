using System;
using System.Collections.Generic;
using System.Text;
using SnakeApp;

namespace Snake.Models
{
    class Food : Point
    {
        public int GrowUpValue { get; set; }
        public Food(int x, int y, char symbol, ConsoleColor color, int growUpValue): base(x, y, symbol, color)
        {
            GrowUpValue = growUpValue;
        }
    }
}
