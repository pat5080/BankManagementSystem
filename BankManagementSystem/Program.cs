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
            int option = 0;
            Login login1 = new Login();
            RenderScreen render = new RenderScreen(login1);
            render.ScreenRenderer();
            Console.ReadKey();
            Console.Clear();
            bool exit = false;

            while(!exit)
            {
                MainMenu menu = new MainMenu();
                RenderScreen render1 = new RenderScreen(menu);
                render1.ScreenRenderer();
                option = render1.option;

                switch (option)
                {
                    case 1:
                        NewAccount newaccount = new NewAccount();
                        RenderScreen render2 = new RenderScreen(newaccount);
                        render2.ScreenRenderer();
                        break;
                    case 2:
                        AccountSearch search = new AccountSearch();
                        RenderScreen render3 = new RenderScreen(search);
                        render3.ScreenRenderer();
                        break;
                    case 3:
                        Deposit deposit = new Deposit();
                        RenderScreen render4 = new RenderScreen(deposit);
                        render4.ScreenRenderer();
                        break;
                    case 4:
                        Withdrawal withdraw = new Withdrawal();
                        RenderScreen render5 = new RenderScreen(withdraw);
                        render5.ScreenRenderer();
                        break;
                    case 5:
                        Statement statement = new Statement();
                        RenderScreen render6 = new RenderScreen(statement);
                        render6.ScreenRenderer();
                        break;
                    case 6:
                        RemoveAccount remove = new RemoveAccount();
                        RenderScreen render7 = new RenderScreen(remove);
                        render7.ScreenRenderer();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Default statement");
                        break;
                }
            }
        }
    }
}
