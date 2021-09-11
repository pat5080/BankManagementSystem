using System;
using System.Collections.Generic;
using System.Text;

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
        }

        protected override void InitialiseInputArray()
        {
            Input[0] = "Username: ";
            Input[1] = "Password: ";
        }
    }
}
