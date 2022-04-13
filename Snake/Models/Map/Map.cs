using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Infrastructure;
using Snake.Models.Foods;
using SnakeApp.Models;

namespace Snake.Models
{
    class Map : IMap
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<GameObject> Walls { get; set; }
        public Food food { get; set; }
        public FoodGenerator foodGenerator;

        public Map(int x, int y, string name, int height, int wigth, List<GameObject> walls)
        {
            foodGenerator = new FoodGenerator(this);
            X = x;
            Y = y;
            Name = name;
            Height = height;
            Width = wigth;
            Walls = walls;
        }

        public void Draw()
        {
            foreach (var wall in Walls)
            {
                wall.Draw();
            }
        }
        public bool IsHit(GameObject gameObject)
        {
            return Walls.Any(x => gameObject.IsHit(x));
        }

        public void GenerateFood()
        {
            food = foodGenerator.Generat();
            food.Draw();
        }
    }
}
