using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.IO;
using System.Runtime.InteropServices;

namespace BankManagementSystem
{
    /* 
     This class contains all functionality related to printing the screens and accessing information in order
    for it to be printed to the screen. Foe example when a new account is created or an account is found it uses
    an object of the class Account to pull out information in regards to the balance, name etc. This class has 
    a constructor for a Screen object which pulls out information in regards to that specific screen (number of fields etc)
    and based on this information it renders the different fields and gets user input. This classes also contains many small
    private 'helper' methods that are called to print small blocks of text.
     */
    class RenderScreen
    {
        private static int origRow = 0;
        private static int origCol = 0;

        private int Fields;
        public int option;

        Screen myScreen;

        public RenderScreen(Screen myScreen)
        {
            this.myScreen = myScreen;

            Fields = myScreen.Fields;
        }

        /* This ScreenRenderer below is the main function that handles rendering the screen view. Based on user input it decides
         how and what to render.*/

        public void ScreenRenderer()
        {
            int noLines = 8 + Fields;
            int startRow = 2, startCol = 10;
            int formWidth = 50;

            int LoginCursorX = Console.CursorTop;
            int LoginCursorY = Console.CursorLeft;

            int PwdCursorX = Console.CursorTop;
            int PwdCursorY = Console.CursorLeft;

            int MenuCursorX = Console.CursorTop;
            int MenuCursorY = Console.CursorLeft;

            int FNCursorX = Console.CursorTop;
            int FNCursorY = Console.CursorLeft;

            int LNCursorX = Console.CursorTop;
            int LNCursorY = Console.CursorLeft;

            int AdCursorX = Console.CursorTop;
            int AdCursorY = Console.CursorLeft;

            int PhCursorX = Console.CursorTop;
            int PhCursorY = Console.CursorLeft;

            int EmCursorX = Console.CursorTop;
            int EmCursorY = Console.CursorLeft;

            int SearchCursorX = Console.CursorTop;
            int SearchCursorY = Console.CursorLeft;

            int DepoCursorX = Console.CursorTop;
            int DepoCursorY = Console.CursorLeft;

            int WithCursorX = Console.CursorTop;
            int WithCursorY = Console.CursorLeft;

            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            for (int line = 0; line < noLines; line++)
            {
                if (line == 0 | line == 2 | line == (noLines - 1))
                {
                    for (int col = 0; col < formWidth; col++)
                    {
                        WriteAt('=', startCol + col, startRow + line);
                    }
                }
                else if (line == 1)
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderTitle(startCol, startRow, formWidth, line);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 3)
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderSubTitle(startCol, startRow, formWidth, line);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 5)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Login Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref LoginCursorX, ref LoginCursorY, 0);
                    }
                    else if (myScreen.ScreenName == "Main Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, 0);
                    }
                    else if (myScreen.ScreenName == "Create new account")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref FNCursorX, ref FNCursorY, 0);
                    }
                    else if (myScreen.ScreenName == "Search for account" || myScreen.ScreenName == "Deposit" || myScreen.ScreenName == "Withdrawal" || myScreen.ScreenName == "Account Statement" || myScreen.ScreenName == "Delete and remove account")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref SearchCursorX, ref SearchCursorY, 0);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 6)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Login Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref PwdCursorX, ref PwdCursorY, 1);
                    }
                    else if (myScreen.ScreenName == "Main Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, 1);
                    }
                    else if (myScreen.ScreenName == "Create new account")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref LNCursorX, ref LNCursorY, 1);
                    }
                    else if (myScreen.ScreenName == "Deposit")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref DepoCursorX, ref DepoCursorY, 1);
                    }
                    else if (myScreen.ScreenName == "Withdrawal")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref WithCursorX, ref WithCursorY, 1);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 7)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Main Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, 2);
                    }
                    else if (myScreen.ScreenName == "Create new account")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref AdCursorX, ref AdCursorY, 2);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 8)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Main Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, 3);
                    }
                    else if (myScreen.ScreenName == "Create new account")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref PhCursorX, ref PhCursorY, 3);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 9)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Main Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, 4);
                    }
                    else if (myScreen.ScreenName == "Create new account")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref EmCursorX, ref EmCursorY, 4);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 10)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Main Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, 5);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 11)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Main Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, 6);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 12)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Main Menu")
                    {
                        RenderSubTitle(startCol, startRow, formWidth, line);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 13)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Main Menu")
                    {
                        RenderField(startCol, startRow, formWidth, line, ref MenuCursorX, ref MenuCursorY, 7);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else
                {
                    WriteAt('|', startCol, startRow + line);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
            }

            if (myScreen.ScreenName == "Login Menu")
            {
                string validCred = "Valid credentials!... Press Enter";

                int row = noLines + 3;

                bool validate = validateLogin(LoginCursorY, LoginCursorX, PwdCursorY, PwdCursorX);

                while (!validate)
                {
                    string invalidCred = "Invalid credentials!";
                    WriteWord(invalidCred, 10, 14);
                    Console.ReadKey();
                    validate = validateLogin(LoginCursorY, LoginCursorX, PwdCursorY, PwdCursorX);
                }

                WriteWord(validCred, startCol, row);
            }
            else if (myScreen.ScreenName == "Main Menu")
            {
                Console.SetCursorPosition(MenuCursorY, MenuCursorX);
                string menuChoice = Console.ReadLine();
                int choice;
                bool success = int.TryParse(menuChoice, out choice);
                if (success)
                {
                    option = choice;
                }
                else
                {
                    option = 0;
                }
            }
            else if (myScreen.ScreenName == "Create new account")
            {
                Console.SetCursorPosition(FNCursorY, FNCursorX);
                string firstName = Console.ReadLine();

                Console.SetCursorPosition(LNCursorY, LNCursorX);
                string lastName = Console.ReadLine();

                Console.SetCursorPosition(AdCursorY, AdCursorX);
                string address = Console.ReadLine();

                Console.SetCursorPosition(PhCursorY, PhCursorX);
                string phoneNo = Console.ReadLine();
                int number;
                bool success = int.TryParse(phoneNo, out number);

                while(!success || phoneNo.Length > 10)
                {             
                    Console.SetCursorPosition(PhCursorY, PhCursorX);
                    Console.Write(new String(' ', phoneNo.Length));
                    Console.SetCursorPosition(PhCursorY, PhCursorX);
                    phoneNo = Console.ReadLine();
                    success = int.TryParse(phoneNo, out number);
                }

                Console.SetCursorPosition(EmCursorY, EmCursorX);
                string email = Console.ReadLine();
                bool validEmail = EmailCheck(email);

                while(!validEmail)
                {
                    Console.SetCursorPosition(EmCursorY, EmCursorX);
                    Console.Write(new String(' ', email.Length));
                    Console.SetCursorPosition(EmCursorY, EmCursorX);
                    email = Console.ReadLine();
                    validEmail = EmailCheck(email);
                }


                Account account = new Account(firstName, lastName, address, number, email);

                int accountNo = account.CreateAccount();

                WriteWord("Account created! Details will be provided via email.", 10, 15);
                WriteWord("Your account number is: " + accountNo, 10, 16);

                Console.ReadKey();
            }
            else if (myScreen.ScreenName == "Search for account")
            {
                Account account = new Account();

                string response = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);


                // Create a function for printing the rest of the functionality

                if (response == "File not found")
                {
                    notFound(11); // Types out account not found
                    string check = "Check another account (y/n)?";
                    WriteWord(check, 10, 12);
                    int RCursorX1 = Console.CursorTop;
                    int RCursorY1 = Console.CursorLeft;
                    Console.SetCursorPosition(RCursorY1, RCursorX1);
                    string answer = Console.ReadLine();
                    string account1;

                    if (answer == "y")
                    {
                        
                        account1 = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);
                        

                        if (account1 != "File not found")
                        {
                            validAccount(account);
                        }
                        else
                        {
                            notFound(13);
                        }
                        Console.ReadKey();
                    }
                }
                else
                {
                    validAccount(account);
                    Console.ReadKey();
                }
            }
            else if (myScreen.ScreenName == "Deposit")
            {
                Account account = new Account();
                string response = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);

                if (response == "File not found")
                {
                    notFound(12); // Types out account not found
                    string check = "Check another account (y/n)?";
                    WriteWord(check, 10, 13);
                    int RCursorX1 = Console.CursorTop;
                    int RCursorY1 = Console.CursorLeft;
                    Console.SetCursorPosition(RCursorY1, RCursorX1);
                    string answer = Console.ReadLine();
                    string account1;

                    if (answer == "y")
                    {
                        int RetryCursorX1 = Console.CursorTop;
                        int RetryCursorY1 = Console.CursorLeft;
                        account1 = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);

                        if (account1 != "File not found")
                        {
                            Found(12);
                            account.DepositAccount(ref DepoCursorX, ref DepoCursorY);
                            DepositSuccess(14);
                        }
                        else
                        {
                            notFound(14);
                        }
                    }
                }
                else
                {
                    Found(12);
                    account.DepositAccount(ref DepoCursorX, ref DepoCursorY);
                    DepositSuccess(13);
                }
            }
            else if (myScreen.ScreenName == "Withdrawal")
            {
                Account account = new Account();
                string response = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);

                if (response == "File not found")
                {
                    notFound(12); // Types out account not found
                    string check = "Check another account (y/n)?";
                    WriteWord(check, 10, 13);
                    int RCursorX1 = Console.CursorTop;
                    int RCursorY1 = Console.CursorLeft;
                    Console.SetCursorPosition(RCursorY1, RCursorX1);
                    string answer = Console.ReadLine();
                    string account1;

                    if (answer == "y")
                    {
                        int RetryCursorX1 = Console.CursorTop;
                        int RetryCursorY1 = Console.CursorLeft;
                        account1 = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);

                        if (account1 != "File not found")
                        {
                            Found(12);
                            account.WithdrawAccount(ref WithCursorX, ref WithCursorY);
                            WithdrawSuccess(13);
                        }
                        else
                        {
                            notFound(13);
                        }
                    }
                }
                else
                {
                    Found(12);
                    account.WithdrawAccount(ref WithCursorX, ref WithCursorY);
                    WithdrawSuccess(13);
                }
            }
            else if (myScreen.ScreenName == "Account Statement")
            {
                Account account = new Account();

                string response = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);


                // Create a function for printing the rest of the functionality

                if (response == "File not found")
                {
                    notFound(11); // Types out account not found
                    string check = "Check another account (y/n)?";
                    WriteWord(check, 10, 12);
                    int RCursorX1 = Console.CursorTop;
                    int RCursorY1 = Console.CursorLeft;
                    Console.SetCursorPosition(RCursorY1, RCursorX1);
                    string answer = Console.ReadLine();
                    string account1;

                    if (answer == "y")
                    {

                        account1 = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);


                        if (account1 != "File not found")
                        {
                            validAccount(account);
                        }
                        else
                        {
                            notFound(13);
                        }
                        Console.ReadKey();
                    }
                }
                else
                {
                    validAccount(account);
                    Console.ReadKey();
                }
            }
            else if (myScreen.ScreenName == "Delete and remove account")
            {
                Account account = new Account();

                string response = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);

                // Create a function for printing the rest of the functionality

                if (response == "File not found")
                {
                    notFound(11); // Types out account not found
                    string check = "Check another account (y/n)?";
                    WriteWord(check, 10, 12);
                    int RCursorX1 = Console.CursorTop;
                    int RCursorY1 = Console.CursorLeft;
                    Console.SetCursorPosition(RCursorY1, RCursorX1);
                    string answer = Console.ReadLine();
                    string account1;

                    if (answer == "y")
                    {

                        account1 = account.SearchAccount(ref SearchCursorX, ref SearchCursorY);


                        if (account1 != "File not found")
                        {
                            validAccount(account);
                        }
                        else
                        {
                            notFound(13);
                        }
                        Console.ReadKey();
                    }
                }
                else
                {
                    validAccount(account);
                    Console.ReadKey();
                }
            }
        }
    

        protected void WriteAt(char s, int col, int row)
        {
            try
            {
                Console.SetCursorPosition(origCol + col, origRow + row);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        protected void WriteWord(string s, int startCol, int row)
        {
            for(int i = 0; i < s.Length; i++)
            {
                char letter = s[i];
                WriteAt(letter, startCol+i, row);
            }
        }

        private bool VerifyLogin(string user, string pass)
        {
            string line;
            bool valid = false;
            
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("login.txt");
            String userRead;
            String passRead;

            while ((line = file.ReadLine()) != null)
            {
                int index = line.IndexOf('|');

                userRead = line.Substring(0, index);
                passRead = line.Substring(index + 1);

                if (user.Equals(userRead) && pass.Equals(passRead))
                {
                    valid = true;
                }
            }

            file.Close();

            return valid;
        }

        private string ConvertToString(SecureString password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("null password");
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        private bool validateLogin(int LoginCursorY, int LoginCursorX, int PwdCursorY, int PwdCursorX)
        {
            ConsoleKeyInfo keyInfo;
            SecureString pass = new SecureString();

            Console.SetCursorPosition(LoginCursorY, LoginCursorX);
            Console.Write(new String(' ', 25));
            Console.SetCursorPosition(LoginCursorY, LoginCursorX);
            string inputUserName = Console.ReadLine();

            Console.SetCursorPosition(PwdCursorY, PwdCursorX);
            Console.Write(new String(' ', 25));
            Console.SetCursorPosition(PwdCursorY, PwdCursorX);

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }

            }
            while (keyInfo.Key != ConsoleKey.Enter);

            string password1 = ConvertToString(pass);

            // Write a function to check whether the login details exist in login.txt

            if (VerifyLogin(inputUserName, password1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RenderField(int startCol, int startRow, int formWidth, int line, ref int CursorX, ref int CursorY, int fieldno)
        {
            string field = myScreen.Input[fieldno];
            int startCol1 = ((startCol + formWidth) / 2);
            WriteWord(field, startCol / 2 + startCol1 / 2, startRow + line);
            CursorX = Console.CursorTop;

            CursorY = Console.CursorLeft;
        }

        private void RenderField(int startCol, int startRow, int formWidth, int line, ref int CursorX, ref int CursorY, string field)
        {
            int startCol1 = ((startCol + formWidth) / 2);
            WriteWord(field, startCol / 2 + startCol1 / 2, startRow + line);
            CursorX = Console.CursorTop;
            CursorY = Console.CursorLeft;
        }

        private void RenderField(int startCol, int startRow, int formWidth, int line, int fieldno)
        {
            string field = myScreen.Input[fieldno];
            int startCol1 = ((startCol + formWidth) / 2);
            WriteWord(field, startCol / 2 + startCol1 / 2, startRow + line);
        }

        private void RenderField(int startCol, int startRow, int formWidth, int line, string field)
        {
            int startCol1 = ((startCol + formWidth) / 2);
            WriteWord(field, startCol / 2 + startCol1 / 2, startRow + line);
        }

        private void RenderTitle(int startCol, int startRow, int formWidth, int line)
        {
            String title = myScreen.Title;
            int startCol1 = ((startCol + formWidth) / 2) - title.Length / 2;
            WriteWord(title, startCol / 2 + startCol1, startRow + line);
        }

        private void RenderTitleAccount(int startCol, int startRow, int formWidth, int line)
        {
            String title = "ACCOUNT DETAILS";
            int startCol1 = ((startCol + formWidth) / 2) - title.Length / 2;
            WriteWord(title, startCol / 2 + startCol1, startRow + line);
        }

        private void RenderStateAccount(int startCol, int startRow, int formWidth, int line)
        {
            String title = "ACCOUNT STATEMENT";
            int startCol1 = ((startCol + formWidth) / 2) - title.Length / 2;
            WriteWord(title, startCol / 2 + startCol1, startRow + line);
        }

        private void RenderSubTitle(int startCol, int startRow, int formWidth, int line)
        {
            String subtitle = myScreen.SubTitle;
            int startCol1 = ((startCol + formWidth) / 2) - subtitle.Length / 2;
            WriteWord(subtitle, startCol / 2 + startCol1, startRow + line);
        }

        private void notFound(int row)
        {
            string notFound = "Account not found!";
            WriteWord(notFound, 10, row);
        }

        private void Found(int row)
        {
            string notFound = "Account found! Enter the amount...";
            WriteWord(notFound, 10, row);
        }

        private bool EmailCheck(string email)
        {
            char at = '@';
            string google = "gmail.com";
            string microsoft = "outlook.com";
            string uts = "uts.edu.au";
            
            if(email.Contains(at) && (email.Contains(google) || email.Contains(microsoft) || email.Contains(uts)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DepositSuccess(int row)
        {
            string success = "Deposit successful";
            WriteWord(success, 10, row);
        }

        private void WithdrawSuccess(int row)
        {
            string success = "Withdrawal successful";
            WriteWord(success, 10, row);
        }

        private void validAccount(Account account)
        {
            string found = "Account found!";
            WriteWord(found, 10, 12);
            string number = "Account No: ";
            string funds = "Account Balance: $";
            string Fname = "First name: ";
            string Lname = "Last name: ";
            string addressT = "Address: ";
            string phoneF = "Phone: ";
            string eMail = "Email: ";

            int EmCursorX = Console.CursorTop;
            int EmCursorY = Console.CursorLeft;

            int noLines = 11;
            int startRow = 13, startCol = 10;
            int formWidth = 50;

            for (int line = 0; line < noLines; line++)
            {
                if (line == 0 | line == 2 | line == (noLines - 1))
                {
                    for (int col = 0; col < formWidth; col++)
                    {
                        WriteAt('=', startCol + col, startRow + line);
                    }
                }
                else if (line == 1)
                {
                    WriteAt('|', startCol, startRow + line);
                    if (myScreen.ScreenName == "Create new account" || myScreen.ScreenName == "Delete and remove account")
                    {
                        RenderTitleAccount(startCol, startRow, formWidth, line);
                    }
                    else if (myScreen.ScreenName == "Account Statement")
                    {
                        RenderStateAccount(startCol, startRow, formWidth, line);
                    }
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 3)
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderField(startCol, startRow, formWidth, line, number + Convert.ToString(account.AccountNo));
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 4)
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderField(startCol, startRow, formWidth, line, funds + Convert.ToString(account.Balance));
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 5)
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderField(startCol, startRow, formWidth, line, Fname +  account.FirstName);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 6)
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderField(startCol, startRow, formWidth, line, Lname + account.LastName);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 7)
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderField(startCol, startRow, formWidth, line, addressT + account.Address);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 8)
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderField(startCol, startRow, formWidth, line, phoneF + account.Phone);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 9)
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderField(startCol, startRow, formWidth, line, eMail + account.Email);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
            }
            if (myScreen.ScreenName == "Account Statement")
            {
                RenderField(startCol, startRow, formWidth, 12, ref EmCursorX, ref EmCursorY, "Email statement: (y/n)? ");
                Console.SetCursorPosition(EmCursorY, EmCursorX);
                string answer = Console.ReadLine();

                if(answer == "y")
                {
                    account.EmailDetails(account.AccountNo);
                    WriteWord("Email sent successfully!", startCol, 27);
                }
            }
            if (myScreen.ScreenName == "Delete and remove account")
            {
                RenderField(startCol, startRow, formWidth, 12, ref EmCursorX, ref EmCursorY, "Delete (y/n)? ");
                Console.SetCursorPosition(EmCursorY, EmCursorX);
                string answer = Console.ReadLine();

                if (answer == "y")
                {
                    account.DeleteAccount(account.AccountNo);
                    WriteWord("Account Deleted!...", startCol, 27);
                }
            }
        }
    }
}
