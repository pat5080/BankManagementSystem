using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.IO;
using System.Runtime.InteropServices;

namespace BankManagementSystem
{
    class RenderScreen
    {
        private static int origRow = 0;
        private static int origCol = 0;

        private int Fields;
        private String Title;
        private String SubTitle;

        Screen myScreen;

        public RenderScreen(Screen myScreen)
        {
            this.myScreen = myScreen;

            Fields = myScreen.Fields;
            Title = myScreen.Title;
            SubTitle = myScreen.SubTitle;
        }

        public void ScreenRenderer()
        {
            int noLines = 5 + (Fields*3);
            int startRow = 2, startCol = 10;
            int formWidth = 50;

            int LoginCursorX = Console.CursorTop;
            int LoginCursorY = Console.CursorLeft;

            int PwdCursorX = Console.CursorTop;
            int PwdCursorY = Console.CursorLeft;

            String inputUserName;
            String password;

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
                    String title = myScreen.Title;
                    int startCol1 = ((startCol + formWidth) / 2) - title.Length/2;
                    WriteWord(title, startCol/2 + startCol1, startRow + line);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 3)
                {
                    WriteAt('|', startCol, startRow + line);
                    String subtitle = myScreen.SubTitle;
                    int startCol1 = ((startCol + formWidth) / 2) - subtitle.Length / 2;
                    WriteWord(subtitle, startCol / 2 + startCol1, startRow + line);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 5 && myScreen.ScreenName == "Login Menu")
                {
                    WriteAt('|', startCol, startRow + line);
                    string field1 = myScreen.Input[0];
                    int startCol1 = ((startCol + formWidth) / 2) - field1.Length / 2;
                    WriteWord(field1, startCol / 2 + startCol1/2, startRow + line);
                    LoginCursorX = Console.CursorTop;
                    LoginCursorY = Console.CursorLeft;
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 6 && myScreen.ScreenName == "Login Menu")
                {
                    WriteAt('|', startCol, startRow + line);
                    String field2 = myScreen.Input[1];
                    int startCol1 = ((startCol + formWidth) / 2) - field2.Length / 2;
                    WriteWord(field2, startCol / 2 + startCol1/2, startRow + line);
                    PwdCursorX = Console.CursorTop;
                    PwdCursorY = Console.CursorLeft;
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else
                {
                    WriteAt('|', startCol, startRow + line);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
            }

            ConsoleKeyInfo keyInfo;
            SecureString pass = new SecureString();

            Console.SetCursorPosition(LoginCursorY, LoginCursorX);
            inputUserName = Console.ReadLine();

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
            if(VerifyLogin(inputUserName, password1))
            {
                Console.WriteLine("Valid credentials!...   Please enter");
            }
            else
            {
                Console.WriteLine("Invalid credentials!");
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
            
            Console.WriteLine(user);
            Console.WriteLine(pass);
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader("login.txt");
            String userRead;
            String passRead;

            while ((line = file.ReadLine()) != null)
            {
                int index = line.IndexOf('|');

                userRead = line.Substring(0, index);
                passRead = line.Substring(index + 1);

                Console.WriteLine(userRead);
                Console.WriteLine(passRead);

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

    }
}
