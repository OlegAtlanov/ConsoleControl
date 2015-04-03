using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleControl;

namespace ConsoleControlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new CMenu();
            var innerMenu = new CMenu()
            {
                {"1111"},
                {"2222"},
                {"3333"},
                {"back", mainMenu}
            };
            
            mainMenu.Add("First", () => Console.WriteLine(Console.ReadLine()));
            mainMenu.Add("Second", innerMenu);
            mainMenu.Add("Third", () => { });
            CControl.Show(mainMenu);
        }
    }
}
