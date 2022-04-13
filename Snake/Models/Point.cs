using System;
using System.Collections.Generic;
using System.Text;
using SnakeApp.Enum;
using SnakeApp.Infrastructure;

namespace SnakeApp
{
    class Point : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public Point(int x, int y, char symbol, ConsoleColor color)
        {
            X = x;
            Y = y;
            Symbol = symbol;
            Color = color;
        }

        public void Move(MoveDirection direction, int cout)
        {
            switch(direction)
            {
                case MoveDirection.up:
                    Y -= cout;
                    break;

                case MoveDirection.right:
                    X += cout;
                    break;

                case MoveDirection.down:
                    Y += cout;
                    break;

                case MoveDirection.left:
                    X -= cout;
                    break;
            }
        }
        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
            Console.ResetColor();
        }
        public void Delete()
        {
            Symbol = ' ';
            Draw();
        }
        public object Clone()
        {
            return new Point(X, Y, Symbol, Color);
        }

        public bool IsHit(IPoint point)
        {
            return point.X == X && point.Y == Y;
        }
    }
}
