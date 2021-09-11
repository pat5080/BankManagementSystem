using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class NewAccount : Screen
    {
        public NewAccount()
        {
            Fields = 5;
            ScreenName = "Create new account";
        }

        protected override void InitialiseInputArray()
        {
            Input[0] = "Username: ";
            Input[1] = "Password: ";
        }
    }
}
