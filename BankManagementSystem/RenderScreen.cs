using System;
using System.Collections.Generic;
using System.Text;

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
            Console.SetCursorPosition(LoginCursorY, LoginCursorX);
            inputUserName = Console.ReadLine();
            Console.SetCursorPosition(PwdCursorY, PwdCursorX);
            password = Console.ReadLine();


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
    }
}
