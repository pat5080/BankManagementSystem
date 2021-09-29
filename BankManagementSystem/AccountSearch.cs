using System;
using System.Collections.Generic;
using System.Text;

/*
 * The AccountSearch class child of Screen contains attributes that specifically relate to it's purpose.
 * It contains the amount of fields it has, title, subtitle and specific strings it will output for
 * the fields.
 */

namespace BankManagementSystem
{
    class AccountSearch : Screen
    {
        public AccountSearch()
        {
            Fields = 1;
            ScreenName = "Search for account";
            Title = "SEARCH AN ACCOUNT";
            SubTitle = "ENTER THE DETAILS";
            Input = new string[] { "Account Number: " };
        }

    }
}
