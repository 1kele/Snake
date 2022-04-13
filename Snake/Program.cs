using System;
using System.Collections.Generic;
using System.Threading;
using SnakeApp.Enum;
using SnakeApp.Infrastructure;
using SnakeApp.Models;

namespace SnakeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
