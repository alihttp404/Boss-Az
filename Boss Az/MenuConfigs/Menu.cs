using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Boss_Az.MenuConfigs
{
    internal class Menu // - 1 for ESC
    {
        private List<string> _options;

        public ConsoleColor MenuColor { get; set; } = ConsoleColor.Red;
        public List<string> Options { get => _options; set => _options = value; }

        public Menu(List<string> options) => _options = options;

        public Menu(List<string> options, ConsoleColor color)
        {
            _options = options;
            MenuColor = color;
        }

        public void Print(ref int option)
        {
            Console.Clear();

            if (option >= _options.Count) option = 0;
            else if (option < 0) option = _options.Count - 1;

            for (int i = 0; i < _options.Count; i++)
            {
                if (option == i)
                {
                    Console.ForegroundColor = MenuColor;
                    Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + _options[i].Length / 2) + "}", _options[i]));
                    Console.ResetColor();
                }
                else Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + _options[i].Length / 2) + "}", _options[i]));
            }
        }

        public void Print(ref int option, string optionalMessage)
        {
            Console.Clear();
            Console.WriteLine(optionalMessage);

            if (option >= _options.Count) option = 0;
            else if (option < 0) option = _options.Count - 1;

            for (int i = 0; i < _options.Count; i++)
            {
                if (option == i)
                {
                    Console.ForegroundColor = MenuColor;
                    Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + _options[i].Length / 2) + "}", _options[i]));
                    Console.ResetColor();
                }
                else Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + _options[i].Length / 2) + "}", _options[i]));
            }
        }

        public int Start()
        {
            ConsoleKeyInfo key;
            int option = 0;

            while (true)
            {
                Print(ref option);
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape) return -1; // exit code
                else if (key.Key == ConsoleKey.Enter) return option;
                else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.RightArrow) option++;
                else if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.LeftArrow) option--;
            }
        }

        public int Start(string optionalMessage)
        {
            ConsoleKeyInfo key;
            int option = 0;

            while (true)
            {
                Print(ref option, optionalMessage);
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape) return -1; // exit code
                else if (key.Key == ConsoleKey.Enter) return option;
                else if (key.Key == ConsoleKey.DownArrow) option++;
                else if (key.Key == ConsoleKey.UpArrow) option--;
            }
        }

        public void ChangeColor(int colorCode)
        {
            // Black, White, Red, Green, Yellow, Blue - from enum, in order

            switch (colorCode)
            {
                case 0:
                    MenuColor = ConsoleColor.Black;
                    break;

                case 1:
                    MenuColor = ConsoleColor.White;
                    break;

                case 2:
                    MenuColor = ConsoleColor.Red;
                    break;

                case 3:
                    MenuColor = ConsoleColor.Green;
                    break;

                case 4:
                    MenuColor = ConsoleColor.Yellow;
                    break;

                case 5:
                    MenuColor = ConsoleColor.Blue;
                    break;

                default:
                    break;
            }
        }
    }
}
