using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook.Classes
{
    public class FileBook : Book
    {
        public FileBook(string name) : base(name)
        {
            Grades = new List<StudentInfo>();
            GradeAddedEvent += OnGradeAdded;
        }

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

        public override Statistics CalculateStatistics()
        {
            return base.CalculateStatistics();
        }

        public void OnGradeAdded(object sender, GradeAddedEventArgs e)
        {
            //Writes grade to file
            StreamWriter writer = File.AppendText($"{Name}.txt");
            writer.WriteLine($"Student Name: {e.Name} | Student Grade: {e.Grade} | Number of Attempts: {e.NumOfAttempts}");
            writer.Close();
        }
    }
}