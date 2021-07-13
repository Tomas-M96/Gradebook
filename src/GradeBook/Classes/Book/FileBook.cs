using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook.Classes
{
    //FileBook class
    //Inherits from Book, therefore implements IBook
    public class FileBook : Book
    {
        //Constructor
        public FileBook(string name) : base(name)
        {
            //Creates the List
            Grades = new List<StudentInfo>();
            
            //Subscribes to the GradeAddedEvent
            GradeAddedEvent += OnGradeAdded;

            //Add File Headers
            //Opens the file and writes the headers to it
            //If the file doesn't exist then it will be created
            StreamWriter writer = File.AppendText($"{Name}.csv");
            writer.WriteLine($"Student Name, Grade, Number Of Attempts");
            writer.Close();
        }

        //Overrides the AddGrade method but uses the base implementation
        public override void AddGrade(StudentInfo studentInfo)
        {
            base.AddGrade(studentInfo);
        }

        public override void DisplayStats()
        {
            Statistics stats = CalculateStatistics();
            Console.WriteLine($"Hello!");
            Console.WriteLine($"The average result is {stats.Average}, and the total of all is {stats.Total}");
            Console.WriteLine($"The highest grade is {stats.High}, and the lowest grade is {stats.Low}");
        }

        //Overrides the CalculateStatistics method but uses the base implementation
        public override Statistics CalculateStatistics()
        {
            return base.CalculateStatistics();
        }

        //Function that is called when the GradeAddedEvent is triggered
        //Opens the file for editting and adds the StudentInfo instance
        //Uses custom EventArgs type
        public void OnGradeAdded(object sender, GradeAddedEventArgs e)
        {
            //Writes grade to file
            StreamWriter writer = File.AppendText($"{Name}.csv");
            writer.WriteLine($"{e.Name}, {e.Grade}, {e.NumOfAttempts}");
            writer.Close();
        }
    }
}