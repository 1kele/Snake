using System;
using System.Collections.Generic;
using System.Text;
using Snake.Models;
using SnakeApp.Infrastructure;
using SnakeApp.Models;

namespace Snake.Infrastructure
{
    interface IMap : IDrawable
    {
        int X { get; set; }
        int Y { get; set; }
        string Name { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        public Food food { get; set; }
        List<GameObject> Walls { get; set; }
        bool IsHit(GameObject gameObject);
        public void GenerateFood();
    }
}
