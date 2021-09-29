using System;
using System.Collections.Generic;
using System.Text;

/*
 * The Login class child of Screen contains attributes that specifically relate to it's purpose.
 * It contains the amount of fields it has, title, subtitle and specific strings it will output for
 * the fields.
 */

namespace BankManagementSystem
{
    class Login : Screen
    {
        public Login()
        {
            Fields = 2;
            ScreenName = "Login Menu";
            Title = "WELCOME TO SIMPLE BANKING SYSTEM";
            SubTitle = "LOGIN TO START";
            Input = new string[] { "Username: ", "Password: " };
    }
    }
}
