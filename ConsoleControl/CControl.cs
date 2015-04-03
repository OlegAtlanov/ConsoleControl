using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleControl
{
    public static class CControl
    {
        static CControl()
        {
            Thread thread = new Thread(Start);
            thread.Start();
        }

        public static CMenu CurrentMenu { get; set; }

        public static void Show(this CMenu menu)
        {
            menu.Show();
            CurrentMenu = menu;
        }

        private static void Start()
        {
            while (true)
            {
                if (CurrentMenu == null)
                {
                    Thread.Sleep(500);
                    continue;
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        CurrentMenu.Up();
                        break;
                    case ConsoleKey.DownArrow:
                        CurrentMenu.Down();
                        break;
                    case ConsoleKey.Enter:
                        Action action = CurrentMenu.Run;
                        CurrentMenu = null;
                        Console.Clear();
                        action.Invoke();
                        continue;
                    default:
                        break;
                }
                CurrentMenu.Show();
            }
        }
    }
}
