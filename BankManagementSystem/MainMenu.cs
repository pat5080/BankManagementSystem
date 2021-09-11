using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class MainMenu : Screen
    {
        public MainMenu()
        {
            Fields = 8;
            ScreenName = "Main Menu";
        }

        protected override void InitialiseInputArray()
        {
            Input[0] = "Username: ";
            Input[1] = "Password: ";
        }
    }
}
