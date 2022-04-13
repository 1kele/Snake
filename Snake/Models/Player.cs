using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    class Player
    {
        public string Name { get; set; }
        public int Point { get; set; }
        public int MaxPoint { get; set; }
        public DateTime DateTime { get; set; }
        public Player(string name)
        {
            Name = name;
        }
    }
}
