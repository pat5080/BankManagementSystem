using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class Deposit : Screen
    {
        public Deposit()
        {
            Fields = 1;
            ScreenName = "Deposit";
            Title = "DEPOSIT";
            SubTitle = "ENTER THE DETAILS";
            Input = new string[] { "Account Number: ", "Amount: $" };
        }

    }
}
