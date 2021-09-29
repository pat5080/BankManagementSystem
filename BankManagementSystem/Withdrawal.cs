using System;
using System.Collections.Generic;
using System.Text;

/*
 * The withdrawal class child of Screen contains attributes that specifically relate to it's purpose.
 * It contains the amount of fields it has, title, subtitle and specific strings it will output for
 * the fields.
 */

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
