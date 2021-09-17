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
            Title = "CREATE A NEW ACCOUNT";
            SubTitle = "ENTER THE DETAILS";
            ScreenName = "Create new account";
            Input = new string[] { "First Name: ", "Last Name: ", "Address: ", "Phone: ", "Email: " };
        }

    }
}
