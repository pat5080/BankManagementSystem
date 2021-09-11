using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem
{
    class RenderScreen
    {
        private int fields;
        private String screenName;

        protected static int origRow = 0;
        protected static int origCol = 0;

        Screen myScreen;

        public RenderScreen(Screen myScreen)
        {
            this.myScreen = myScreen;
        }

        public void ScreenRenderer()
        {
            int noLines = 5 + (fields*3);
            int startRow = 2, startCol = 10;
            int formWidth = 50;

            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            for (int line = 0; line < noLines; line++)
            {
                // Print boarder
                if (line == 0 | line == 2 | line == (noLines - 1))
                {
                    for (int col = 0; col < formWidth; col++)
                    {
                        WriteAt("=", startCol + col, startRow + line);
                    }
                }
                else
                {
                    WriteAt("|", startCol, startRow + line);
                    WriteAt("|", startCol + formWidth - 1, startRow + line);
                }
            }
        }

        protected void WriteAt(string s, int col, int row)
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
    }
}
