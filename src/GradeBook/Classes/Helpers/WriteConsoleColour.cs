using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Classes.Helpers
{
    //Utility class to write error and success messages to the screen with some styling attached
    public static class WriteConsoleColour
    {

        //Writes an exception to the screen with Red background and White text
        public static void WriteError(Exception ex)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

        //Writes a success message to the screen with Green background and White text
        public static void WriteCreated(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
