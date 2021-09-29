using System;
using System.Collections.Generic;
using System.Text;

/*
 * This screen class is a superclass to many subclasses that inherit from it.
 * Screen is an abstract idea that is defined by its subclasses that specify
 * a specific screen type ie. 'login screen' or 'account search screen'.
 */


namespace BankManagementSystem
{
       class Screen
    {
        public int Fields;
        public String ScreenName;
        public String Title;
        public String SubTitle;
        public string[] Input;
    }
}
