using System;
using System.Collections.Generic;
using System.Text;

/*
 * The Deposit class child of Screen contains attributes that specifically relate to it's purpose.
 * It contains the amount of fields it has, title, subtitle and specific strings it will output for
 * the fields.
 */

namespace BankManagementSystem
{
    class Deposit : Screen
    {
        public Deposit()
        {
            Fields = 2;
            ScreenName = "Deposit";
            Title = "DEPOSIT";
            SubTitle = "ENTER THE DETAILS";
            Input = new string[] { "Account Number: ", "Amount: $" };
        }

    }
}
