using System;
using System.Collections.Generic;
using System.Text;
using Snake.Enum;
using SnakeApp.Models;

namespace Snake.Models
{
    class Menu
    {
        public static Player player = new Player("AWQ");

        private int width = 60;
        private int height = 28;
        public int buttonWidth = 50;
        public int buttonHeight = 2;
        public int startButtonY = 7;
        public void DrawMenu()
        {
            Console.Clear();

            CreateMenuTemplate();

            CreateButton(1, "1. ИГРАТЬ");
            CreateButton(2, "2. Смена ника");
            CreateButton(3, "3. Выбор карт");
            CreateButton(4, "4. Таблица рейтинга");
            CreateButton(5, "5. ВЫХОД");

            Console.SetCursorPosition(5, 25);
            Console.WriteLine($"НИК: {Game.player.Name}");

            Console.SetCursorPosition(5, 27);
            Console.WriteLine($"Ваш результат: {Game.player.Point}");

            Console.SetCursorPosition(5, 29);
            Console.WriteLine($"Ваш лучший результат: {Game.player.MaxPoint}");
        }

        private void CreateMenuTemplate()
        {
            Console.CursorVisible = false;

            Console.SetWindowSize(61, 35);
            Line leftWall = new Line(0, 1, height + 2, '|', LineType.Vertical, ConsoleColor.Cyan);
            Line rightWall = new Line(width, 1, height + 2, '|', LineType.Vertical, ConsoleColor.Cyan);

            Line upWall = new Line(0, 0, width + 1, '-', LineType.Horizontal, ConsoleColor.Cyan);
            Line downWall = new Line(0, height + 3, width + 1, '-', LineType.Horizontal, ConsoleColor.Cyan);

            leftWall.Draw();
            rightWall.Draw();
            upWall.Draw();
            downWall.Draw();

            Line titleDivider = new Line(1, 3, width - 1, '-', LineType.Horizontal, ConsoleColor.Cyan);
            titleDivider.Draw();

            Console.SetCursorPosition(26, 1);
            Console.Write("ЗМЕЙКА");

            Console.SetCursorPosition(23, 2);
            Console.Write("ГЛАВНОЕ МЕНЮ");
        }

        public void CreateButton(int number, string text)
        {
            int x = 5;
            number = number * 2;
            int y = (buttonHeight * number - 1) + startButtonY;
            Line leftWall = new Line(x, y - 4, buttonHeight - 1, '|', LineType.Vertical, ConsoleColor.Magenta);
            Line rightWall = new Line(x + buttonWidth, y - 4, buttonHeight - 1, '|', LineType.Vertical, ConsoleColor.Magenta);

            Line upWall = new Line(x, y - 5, buttonWidth + 1, '-', LineType.Horizontal, ConsoleColor.Magenta);
            Line downWall = new Line(x, y - buttonHeight - 1, buttonWidth + 1, '-', LineType.Horizontal, ConsoleColor.Magenta);

            leftWall.Draw();
            rightWall.Draw();
            upWall.Draw();
            downWall.Draw();

            Console.SetCursorPosition(25, number * 2 + 2);
            Console.WriteLine(text);
        }

        public void SkanMenuItem(Game game)
        {
            Console.SetCursorPosition(0, 32);
            Console.Write("Введите пункт меню: ");

            int menuItem = int.Parse(Console.ReadLine());

            switch (menuItem)
            {
                case 1:
                    game.Play();
                    break;
                case 2:
                    ChangeName();
                    break;
                case 3:
                    return;
                case 4:
                    ShowLeaderBoard(game);
                    break;
                case 5:
                    game.Save();
                    Environment.Exit(0);
                    return;
            }


        }

        public void ChangeName()
        {
            Console.WriteLine($"Введите ник: ");
            string newName = Console.ReadLine();

            Game.player = new Player(newName);
            Console.WriteLine("Ник успешно сменен!!!");
            return;
        }

        public void ShowLeaderBoard(Game game)
        {
            game.leaderBoard.Print();
            Console.WriteLine("Введите любую клавишу!!!");
            Console.ReadKey();
        }
        public static string GetDivider(int num)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < num; i++)
            {
                stringBuilder.Append('-');
            }

            return stringBuilder.ToString();
        }
    }
}
