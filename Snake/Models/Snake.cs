using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SnakeApp.Enum;
using SnakeApp.Infrastructure;
using Snake.Models.Foods;
using Snake.Models;

namespace SnakeApp.Models
{
    class Snake : GameObject
    {
        private IPoint _head;
        private IPoint _tail;

        private MoveDirection _moveDirection;

        public Snake(IPoint tail, int length, MoveDirection moveDirection): base(ConsoleColor.Red)
        {
            _tail = tail;
            _moveDirection = moveDirection;
            Init(length);
        }
        public void HandleKey(ConsoleKey Key)
        {
            switch(Key)
            {
                case ConsoleKey.UpArrow:
                    if (_moveDirection != MoveDirection.down)
                    {
                        _moveDirection = MoveDirection.up;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (_moveDirection != MoveDirection.right)
                    {
                        _moveDirection = MoveDirection.left;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (_moveDirection != MoveDirection.up)
                    {
                        _moveDirection = MoveDirection.down;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (_moveDirection != MoveDirection.left)
                    {
                        _moveDirection = MoveDirection.right;
                    }
                    break;
            }
        }
        public void Init(int length)
        {
            points.Add(_tail);
            for (int i = 1; i < length; i++)
            {
                IPoint point = (IPoint)points.Last().Clone();
                point.Move(_moveDirection, 1);
                points.Add(point);
            }
            _head = points.Last();
        }

        public void Move()
        {
            DeleteTail();
            AddHeat();
            _head.Draw();
        }

        private void DeleteTail()
        {
            points.Remove(_tail);
            _tail.Delete();
            _tail = points[0];
        }
        private void AddHeat()
        {
            _head = (IPoint)_head.Clone();
            _head.Move(_moveDirection, 1);
            points.Add(_head);
        }

        public bool IsHitTail()
        {
            return IsHit(GetNextHead());
        }

        public IPoint GetNextHead()
        {
            IPoint nextHead = (IPoint)_head.Clone();
            nextHead.Move(_moveDirection, 1);
            return nextHead;
        }

        public bool EatFood(Food food)
        {
            IPoint nextHead = (IPoint)_head.Clone();
            if (nextHead.IsHit(food))
            {
                food.Symbol = nextHead.Symbol;
                food.Color = nextHead.Color;
                points.Add(food);
                return true;
            }
            return false;
        }
    }
}
