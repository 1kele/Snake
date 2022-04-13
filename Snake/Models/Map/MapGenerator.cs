using System;
using System.Collections.Generic;
using System.Text;
using Snake.Enum;
using Snake.Infrastructure;
using SnakeApp.Infrastructure;
using SnakeApp.Models;

namespace Snake.Models
{
    class MapGenerator
    {
        public IMap Generate(MapType mapType, int x, int y, int Height, int Width)
        {
            IMap map = null;
            switch (mapType)
            {
                case MapType.Box:
                    map = GenerateBox(Height, Width, x, y);
                    break;
            }
            map.GenerateFood();
            return map;
        }

        private IMap GenerateBox(int Height, int Width, int x, int y)
        {
            Line leftWall = new Line(x, y, Height, '#', LineType.Vertical, ConsoleColor.Blue);
            Line rightWall = new Line(x + Width, y + 1, Height, '#', LineType.Vertical, ConsoleColor.Blue);
            Line upWall = new Line(x, y, Width, '#', LineType.Horizontal, ConsoleColor.Blue);
            Line downWall = new Line(x, y + Height, Width, '#', LineType.Horizontal, ConsoleColor.Blue);
            List<GameObject> walls = new List<GameObject>() {leftWall, rightWall, upWall, downWall};
            return new Map(x, y, "BOX", Height, Width, walls);
        }
    }
}
