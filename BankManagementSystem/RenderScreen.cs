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
                else if (line == 5 && myScreen.ScreenName == "Login Menu")
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderField(startCol, startRow, formWidth, line, ref LoginCursorX, ref LoginCursorY, 0);
                    WriteAt('|', startCol + formWidth - 1, startRow + line);
                }
                else if (line == 6 && myScreen.ScreenName == "Login Menu")
                {
                    WriteAt('|', startCol, startRow + line);
                    RenderField(startCol, startRow, formWidth, line, ref PwdCursorX, ref PwdCursorY, 1);
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
            string inputUserName = Console.ReadLine();

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
            int startCol1 = ((startCol + formWidth) / 2) - field.Length / 2;
            WriteWord(field, startCol / 2 + startCol1 / 2, startRow + line);
            CursorX = Console.CursorTop;
            CursorY = Console.CursorLeft;
        }

        private void RenderTitle(int startCol, int startRow, int formWidth, int line)
        {
            String title = myScreen.Title;
            int startCol1 = ((startCol + formWidth) / 2) - title.Length / 2;
            WriteWord(title, startCol / 2 + startCol1, startRow + line);
        }

        private void RenderSubTitle(int startCol, int startRow, int formWidth, int line)
        {
            String subtitle = myScreen.SubTitle;
            int startCol1 = ((startCol + formWidth) / 2) - subtitle.Length / 2;
            WriteWord(subtitle, startCol / 2 + startCol1, startRow + line);
        }

    }
}
