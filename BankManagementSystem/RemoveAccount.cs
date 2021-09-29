using System;
using System.Collections.Generic;
using System.Text;

/*
 * The RemoveAccount class child of Screen contains attributes that specifically relate to it's purpose.
 * It contains the amount of fields it has, title, subtitle and specific strings it will output for
 * the fields.
 */

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
