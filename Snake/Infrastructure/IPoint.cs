using System;
using System.Collections.Generic;
using System.Text;
using SnakeApp.Enum;

namespace SnakeApp.Infrastructure
{
    interface IPoint : IDrawable, IDeleteble,ICloneable
    {
        int X { get; set; }
        int Y { get; set; }
        ConsoleColor Color { get; set; }
        char Symbol { get; set; }
        void Move(MoveDirection moveDirection ,int count);
        bool IsHit(IPoint point);
    }
}
