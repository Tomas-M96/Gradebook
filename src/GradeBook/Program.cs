using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book;
            Console.WriteLine("Welcome to the Gradebook!");

            do
            {
                Console.WriteLine("Please enter the name of your book:");
                string input = Console.ReadLine();
                try
                {
                    book = new Book(input);
                    Console.WriteLine("Book Created");

                    if (book.Name != null)
                        break;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);

            do
            {
                Console.WriteLine("Type 'Done' when you are finished adding grades.");
                Console.WriteLine("Please enter a grade:");

                string input = Console.ReadLine();
                double grade;

                try
                {
                    grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception)
                {
                    Console.WriteLine("You did not enter a number");
                }

                if (input == "done" || input == "Done")
                    break;


            } while (true);

            book.DisplayStats();
        }
    }

}
