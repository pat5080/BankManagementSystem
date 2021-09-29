using System;
using System.Collections.Generic;
using System.Text;

/*
 * The MainMenu class child of Screen contains attributes that specifically relate to it's purpose.
 * It contains the amount of fields it has, title, subtitle and specific strings it will output for
 * the fields.
 */

namespace BankManagementSystem
{
    class MainMenu : Screen
    {
        public MainMenu()
        {
            Fields = 8;
            Title = "WELCOME TO SIMPLE BANKING SYSTEM";
            SubTitle = " ";
            ScreenName = "Main Menu";
            Input = new string[] { "1. Create a new account", "2. Search for an account",
            "3. Deposit", "4. Withdraw", "5. A/C statement", "6. Delete account", "7. Exit", "Enter your choice (1-7): "};
        }

    }
}
