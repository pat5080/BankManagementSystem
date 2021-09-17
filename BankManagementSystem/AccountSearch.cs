﻿using System;
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
            Title = "SEARCH AN ACCOUNT";
            SubTitle = "ENTER THE DETAILS";
            Input = new string[] { "Account Number: " };
        }

    }
}
