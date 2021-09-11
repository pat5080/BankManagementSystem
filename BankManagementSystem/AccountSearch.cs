using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class AccountSearch : Screen
    {
        public AccountSearch()
        {
            Fields = 1;
            ScreenName = "Search for account";
        }
        protected override void InitialiseInputArray()
        {
            Input[0] = "Username: ";
            Input[1] = "Password: ";
        }

    }
}
