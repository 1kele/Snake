using System;
using System.Collections.Generic;
using System.Text;
using Snake.Enum;
using SnakeApp.Models;

namespace Snake.Models
{
    class Hud
    {
        private Game _game;
        public Hud(Game game)
        {
            _game = game;
        }
        private int height = 42;
        private int width = 110;

        private Line VerticalLinePoints { get; set; }
        private Line HorizontalLinePoints { get; set; }

        public void Draw()
        {
            var upWall = new Line(0, 0, width + 1, '-', LineType.Horizontal, ConsoleColor.Yellow);
            var downWall = new Line(0, height, width + 1, '-', LineType.Horizontal, ConsoleColor.Yellow);

            var leftWall = new Line(0, 1, height - 1, '|', LineType.Vertical, ConsoleColor.Yellow);
            var rightWall = new Line(width, 1, height - 1, '|', LineType.Vertical, ConsoleColor.Yellow);

            upWall.Draw();
            downWall.Draw();
            leftWall.Draw();
            rightWall.Draw();

            DrawMap();
            DrawNick();
            DrawPoints();
        }
        private void DrawNick()
        {
            var upWall = new Line(1, 4, Game.player.Name.Length + 10, '-', LineType.Horizontal, ConsoleColor.Yellow);
            var leftWall = new Line(Game.player.Name.Length + 10, 1, 3, '|', LineType.Vertical, ConsoleColor.Yellow);

            upWall.Draw();
            leftWall.Draw();

            Console.SetCursorPosition(3, 2);
            Console.Write($"НИК: {Game.player.Name}");
        }

        public void DrawPoints()
        {
            if (VerticalLinePoints != null)
            {
                VerticalLinePoints.Delete();
            }

            HorizontalLinePoints = new Line(1, height - 4, Game.player.Point.ToString().Length + 10, '-', LineType.Horizontal, ConsoleColor.Yellow);
            VerticalLinePoints = new Line(Game.player.Point.ToString().Length + 10, height - 3, 3, '|', LineType.Vertical, ConsoleColor.Yellow);

            HorizontalLinePoints.Draw();
            VerticalLinePoints.Draw();

            Console.SetCursorPosition(3, height - 2);
            Console.Write($"ОЧКИ: {Game.player.Point}");
        }

        private void DrawMap()
        {
            var upWall = new Line(width - 12 - _game._map.Name.Length, 4, _game._map.Name.Length + 12, '-', LineType.Horizontal, ConsoleColor.Yellow);
            var leftWall = new Line(width - 12 - _game._map.Name.Length, 1, 3, '|', LineType.Vertical, ConsoleColor.Yellow);

            upWall.Draw();
            leftWall.Draw();

            Console.SetCursorPosition(width - 11 - _game._map.Name.Length + 2, 2);
            Console.Write($"КАРТА: {_game._map.Name}");
        }
    }
}

