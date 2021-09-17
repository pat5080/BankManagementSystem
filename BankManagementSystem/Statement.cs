using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class Statement : Screen
    {
        public Statement()
        {
            Fields = 1;
            ScreenName = "Account Statement";
            Title = "STATEMENT";
            SubTitle = "ENTER THE DETAILS";
            Input = new string[] { "Account Number: "};
        }

    }
}
