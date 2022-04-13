using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Snake.Models
{
    class LeaderBoard
    {
        public List<Player> players = new List<Player>();

        public void UpdatePlayerPoints(Player player)
        {
            Player player1 = players.Where(x => player.Name == x.Name).FirstOrDefault();
            if (player1 == null)
            {
                players.Add(player);
            }
            else if (player.MaxPoint > player1.MaxPoint)
            {
                player1.MaxPoint = player.MaxPoint;
            }
        }
            public void Print()
            {
                Console.Clear();

                int num = 1;

                Console.WriteLine(Menu.GetDivider(60));

                string header = String.Format("| {0,5} | {1,10}       | {2,6}   |", "Место", "Ник", "Очки");

                Console.WriteLine(header);
                Console.WriteLine($"|{Menu.GetDivider(58)}|");

                if (players.Count == 0)
                {
                    Console.WriteLine(String.Format("|{0,30}              |", "Нет результатов"));
                    Console.WriteLine(Menu.GetDivider(46));
                }

                foreach (var player in players.OrderByDescending(x => x.Point).Take(10))
                {
                    Console.WriteLine(String.Format("| {0,3}   | {1,10}       | {2,6}   |", num++, player.Name, player.MaxPoint));
                }

                Console.WriteLine(Menu.GetDivider(60));
            }
        }
    } 
