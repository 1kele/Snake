using System;
using System.Collections.Generic;
using System.Text;
using Snake.Enum;
using SnakeApp;
using SnakeApp.Models;

namespace Snake.Models
{
    class Line : GameObject
    {

        public Line(int x, int y, int length, char symbol, LineType lineType, ConsoleColor color):base(color)
        {
            InitPoints(x, y, length, symbol, lineType);
        }

        public void InitPoints(int x, int y, int length, char symbol, LineType lineType)
        {
            switch(lineType)
            {
                case LineType.Vertical:
                    for (int i = 0; i < length; i++)
                    {
                        points.Add(new Point(x, y++, symbol, color));
                    }
                    break;
                case LineType.Horizontal:
                    for (int i = 0; i < length; i++)
                    {
                        points.Add(new Point(x++, y, symbol, color));
                    }
                    break;
            }
        }
    }
}
