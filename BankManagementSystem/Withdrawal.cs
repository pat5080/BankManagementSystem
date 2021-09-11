using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class Withdrawal : Screen
    {
        public Withdrawal()
        {
            Fields = 1;
            ScreenName = "Withdrawal";
        }

        protected override void InitialiseInputArray()
        {
            Input[0] = "Username: ";
            Input[1] = "Password: ";
        }
    }
}
