using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    abstract class Screen
    {
        public int Fields;
        public String ScreenName;
        public String Title;
        public String SubTitle;
        public String[] Input;

        protected abstract void InitialiseInputArray();
    }
}
