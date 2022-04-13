using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeApp.Infrastructure;

namespace SnakeApp.Models
{
    abstract class GameObject
    {
        public List<IPoint> points = new List<IPoint>();

        public ConsoleColor color;

        public GameObject(ConsoleColor color)
        {
            this.color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (var point in points)
            {
                point.Draw();
            }
            Console.ResetColor();
        }

        public void Delete()
        {
            foreach (var point in points)
            {
                point.Delete();
            }
        }
        public bool IsHit(GameObject gameObject)
        {
            return points.Any(x => gameObject.IsHit(x)); 
        }
        public bool IsHit(IPoint point)
        {
            return points.Any(x => x.IsHit(point));
        }
    }
}
