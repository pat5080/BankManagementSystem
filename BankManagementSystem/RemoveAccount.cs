using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class RemoveAccount : Screen
    {
        public RemoveAccount()
        {
            Fields = 1;
            ScreenName = "Delete and remove account";

        }

        protected override void InitialiseInputArray()
        {
            Input[0] = "Username: ";
            Input[1] = "Password: ";
        }
    }
}
