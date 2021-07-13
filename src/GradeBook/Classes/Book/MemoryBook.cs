using System;
using System.Collections.Generic;

namespace GradeBook.Classes
{   
    //MemoryBook class
    //Inherits from Book, therefore implements IBook
    public class MemoryBook : Book
    {
        //Constructor
        public MemoryBook(string name) : base(name)
        {
            Grades = new List<StudentInfo>();
        }

        public override void AddGrade(StudentInfo grade)
        {
            base.AddGrade(grade);
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
    }
}