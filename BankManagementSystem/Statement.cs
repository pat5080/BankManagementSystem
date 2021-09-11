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
        }

        protected override void InitialiseInputArray()
        {
            Input[0] = "Username: ";
            Input[1] = "Password: ";
        }
    }
}
