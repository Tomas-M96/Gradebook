using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Classes.Helpers
{
    public static class WriteConsoleColour
    {

        public static void WriteError(Exception ex)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

        public static void WriteCreated(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
