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
            Title = "WELCOME TO SIMPLE BANKING SYSTEM";
            SubTitle = "Enter your choice (1-7):";
            ScreenName = "Main Menu";
            Input = new string[] { "1. Create a new account", "2. Search for an account",
            "3. Deposit", "4. Withdraw", "5. A/C statement", "Delete account", "Exit", "Enter your choice (1-7): "};
        }

    }
}
