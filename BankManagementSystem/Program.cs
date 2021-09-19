using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ConsoleColor;
using System.Drawing;

namespace BankManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Login login1 = new Login();
            RenderScreen render = new RenderScreen(login1);
            render.ScreenRenderer();
            Console.ReadKey();
            Console.Clear();
            MainMenu menu = new MainMenu();
            RenderScreen render1 = new RenderScreen(menu);
            render1.ScreenRenderer();
        }
    }
}
