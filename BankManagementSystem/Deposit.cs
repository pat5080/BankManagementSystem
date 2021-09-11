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
        }

        protected override void InitialiseInputArray()
        {
            Input[0] = "Username: ";
            Input[1] = "Password: ";
        }
    }
}
