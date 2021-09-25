using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class Withdrawal : Screen
    {
        public Withdrawal()
        {
            Fields = 2;
            ScreenName = "Withdrawal";
            Title = "WITHDRAW";
            SubTitle = "ENTER THE DETAILS";
            Input = new string[] { "Account Number: ", "Amount: $" };
        }

    }
}
