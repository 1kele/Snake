using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Snake.Enum;
using Snake.Infrastructure;
using Snake.Models;
using Snake.Models.Foods;
using SnakeApp.Enum;

namespace SnakeApp.Models
{
    class Game
    {
        public DateStorage dateStorage;
        public LeaderBoard leaderBoard;
        private Snake _snake;
        public IMap _map;
        private Menu _menu;
        private Hud _hud;
        public static Player player = new Player("AWQ");
         public Game()
        {
            dateStorage = new DateStorage(@"C: \Users\Мария\source\repos\Snake\Snake\Saves");
            _menu = new Menu();
            _hud = new Hud(this);
            leaderBoard = dateStorage.Load();
        }
        public void Play()
        {
            InitGame();
            while(true)
            {
                if (_map.IsHit(_snake) || _snake.IsHitTail())
                {
                    leaderBoard.UpdatePlayerPoints(player);
                    Console.Clear();
                    return;
                }
                if (_snake.EatFood(_map.food))
                {
                    _map.GenerateFood();
                    player.Point++;
                    _hud.DrawPoints();
                    if (player.MaxPoint <= player.Point)
                    {
                        player.MaxPoint = player.Point;
                    }
                }
                _snake.Move();
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    _snake.HandleKey(Console.ReadKey().Key);
                }
            }
        }
        public void InitGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(111, 43);

            InitMap();
            InitSnake();
            InitHud();
        }
        public void InitSnake()
        {
            Point tail = new Point(15, 15, '*', ConsoleColor.Red);
            _snake = new Snake(tail, 5, MoveDirection.right);
            _snake.Draw();
        }

        public void InitMap()
        {
            player.Point = 0;
            MapGenerator generator = new MapGenerator();
            _map = generator.Generate(MapType.Box, 10, 6, 30, 90);
            _map.Draw();
        }
        public void InitHud()
        {
            _hud.Draw();
        }

        public void Start()
        {
            while (true)
            {
                _menu.DrawMenu();
                _menu.SkanMenuItem(this);
            }
        }

        public void Save()
        {
            dateStorage.Save(leaderBoard);
        }
    }
}
