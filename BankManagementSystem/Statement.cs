using System;
using System.Collections.Generic;
using System.Text;

/*
 * The Statement class child of Screen contains attributes that specifically relate to it's purpose.
 * It contains the amount of fields it has, title, subtitle and specific strings it will output for
 * the fields.
 */


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
