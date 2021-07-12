using System;
using System.Collections.Generic;
using GradeBook.Classes;
using GradeBook.Classes.Helpers;
using GradeBook.Interfaces;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book;
            Console.WriteLine("Welcome to the Gradebook!");
            Console.WriteLine("--------------------------------------------------------");
            do
            {
                Console.WriteLine("Please pick the type of Gradebook you want to use:");
                Console.WriteLine("1. Write to File");
                Console.WriteLine("2. Write to Memory");
                string input = Console.ReadLine();

                try
                {
                    if (input == "1")
                    {
                        book = CreateBook(true);
                        WriteConsoleColour.WriteCreated("Write to File Book Created");
                        InputGrades(book);
                        break;
                    }
                    else if (input == "2")
                    {
                        book = CreateBook(false);
                        WriteConsoleColour.WriteCreated("Write to Memory Book Created");
                        InputGrades(book);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input - Please select 1 or 2");
                    }
                }
                catch (ArgumentException ex)
                {
                    WriteConsoleColour.WriteError(ex);
                }
            } while (true);

            Console.WriteLine("\n");
            Console.WriteLine($"--------------Gradebook {book.Name} Statistics--------------");
            book.DisplayStats();
        }

        //REMEMBER as you are want to access this method from a static method then this method also needs to be static

        //Function to create a book object
        private static Book CreateBook(bool isFileBook)
        {
            do
            {
                Console.ResetColor();
                Console.WriteLine("Please enter the name of your book:");
                string input = Console.ReadLine();
                Book book;
                try
                {
                    if (isFileBook)
                        book = new FileBook(input);
                    else
                        //Creating an instance of book
                        book = new MemoryBook(input);

                    //Subscribing to an event
                    book.GradeAddedEvent += OnGradeAdded;

                    if (book.Name != null)
                        return book;
                }
                catch (ArgumentNullException ex)
                {
                    WriteConsoleColour.WriteError(ex);
                }
            } while (true);
        }

        //Function to handle entering grades into the book
        private static void InputGrades(IBook book)
        {
            bool isLoopFinished = false;
            string name = "";
            double grade = 0;
            int numOfAttempts = 0;

            while (!isLoopFinished)
            {
                Console.WriteLine("Type 'Done' when you are finished adding grades.");

                //Populate the name field
                PopulateName(ref isLoopFinished, ref name);

                //Populate the grade field
                PopulateGrade(ref isLoopFinished, ref grade);

                //Populate the numOfAttempts field
                PopulateNumOfAttempts(ref isLoopFinished, ref numOfAttempts);

                //Create the StudentInfo instance and add it to the book
                AddStudentInfo(name, grade, numOfAttempts, book);
            }
        }

        //Function to populate the name field
        private static void PopulateName(ref bool isLoopFinished, ref string name)
        {
            string input;

            while (!isLoopFinished)
            {
                //Loop name
                Console.WriteLine("Please enter a student name:");
                input = Console.ReadLine();

                if (input == "done" || input == "Done")
                {
                    isLoopFinished = true;
                    break;
                }

                try
                {
                    if (input == "")
                    {
                        throw new ArgumentNullException();
                    }
                    else
                    {
                        name = input;
                        break;
                    }
                }
                catch (ArgumentNullException ex)
                {
                    WriteConsoleColour.WriteError(ex);
                }
            }
        }

        //Function to populate the grade field
        private static void PopulateGrade(ref bool isLoopFinished, ref double grade)
        {
            string input;

            while (!isLoopFinished)
            {
                //loop grade
                Console.WriteLine("Please enter a grade:");
                input = Console.ReadLine();

                if (input == "done" || input == "Done")
                {
                    isLoopFinished = true;
                    break;
                }

                try
                {
                    grade = double.Parse(input);

                    if (grade > 100 || grade < 0)
                        throw new ArgumentOutOfRangeException();

                    break;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    WriteConsoleColour.WriteError(ex);
                }
                catch (FormatException ex)
                {
                    WriteConsoleColour.WriteError(ex);
                }
            }
        }

        //Function to populate the numOfAttempts field
        private static void PopulateNumOfAttempts(ref bool isLoopFinished, ref int numOfAttempts)
        {
            string input;

            while (!isLoopFinished)
            {
                //loop numOfAttempts
                Console.WriteLine("How many attempts did the student take:");
                input = Console.ReadLine();


                if (input == "done" || input == "Done")
                {
                    isLoopFinished = true;
                    break;
                }

                try
                {
                    numOfAttempts = int.Parse(input);

                    if (numOfAttempts > 100 || numOfAttempts < 0)
                        throw new ArgumentOutOfRangeException();

                    break;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    WriteConsoleColour.WriteError(ex);
                }
                catch (FormatException ex)
                {
                    WriteConsoleColour.WriteError(ex);
                }
            }
        }

        //Function to create the StudentInfo instance and save to the book
        private static void AddStudentInfo(string name, double grade, int numOfAttempts, IBook book)
        {
            try
            {
                StudentInfo studentInfo = new StudentInfo(name, grade, numOfAttempts);
                book.AddGrade(studentInfo);
            }
            catch (ArgumentException ex)
            {
                WriteConsoleColour.WriteError(ex);
            }
            catch (StudentInfoNullException ex)
            {
                WriteConsoleColour.WriteError(ex);
            }
            catch (StudentInfoMaxNumberException ex)
            {
                WriteConsoleColour.WriteError(ex);
            }
        }

        //Function to be called via event when a grade has been added
        private static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }

}
