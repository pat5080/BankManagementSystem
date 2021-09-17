using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class RemoveAccount : Screen
    {
        public RemoveAccount()
        {
            Fields = 1;
            ScreenName = "Delete and remove account";
            Title = "DELETE AN ACCOUNT";
            SubTitle = "ENTER THE DETAILS";
            Input = new string[] { "Account Number: " };
        }

    }
}
