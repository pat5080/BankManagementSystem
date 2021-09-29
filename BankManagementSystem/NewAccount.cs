using System;
using System.Collections.Generic;
using System.Text;

/*
 * The NewAccount class child of Screen contains attributes that specifically relate to it's purpose.
 * It contains the amount of fields it has, title, subtitle and specific strings it will output for
 * the fields.
 */

namespace BankManagementSystem
{
    class NewAccount : Screen
    {
        public NewAccount()
        {
            Fields = 5;
            Title = "CREATE A NEW ACCOUNT";
            SubTitle = "ENTER THE DETAILS";
            ScreenName = "Create new account";
            Input = new string[] { "First Name: ", "Last Name: ", "Address: ", "Phone: ", "Email: " };
        }

    }
}
