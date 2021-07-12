using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Interfaces;

namespace GradeBook.Classes
{
    public abstract class Book : IBook
    {
        public delegate void GradeAddedDelegate(object sender, GradeAddedEventArgs args);
        public event GradeAddedDelegate GradeAddedEvent;

        public List<StudentInfo> Grades { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                //Set the name variable if string is not empty - otherwise throw a null argument exception
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public Book(string name)
        {
            Name = name;
        }

        public virtual void AddGrade(StudentInfo studentInfo)
        {
            if (studentInfo.Grade <= 100 && studentInfo.Grade >= 0)
            {
                Grades.Add(studentInfo);

                if (GradeAddedEvent != null)
                {
                    GradeAddedEvent(this, new GradeAddedEventArgs(studentInfo));
                }
            }
            else
            {
                throw new ArgumentException("Invalid Grade");
            }
        }

        public abstract void DisplayStats();

        public virtual Statistics CalculateStatistics()
        {
            Statistics stats = new Statistics();
            stats.High = double.MinValue;
            stats.Low = double.MaxValue;

            foreach (StudentInfo studentInfo in Grades)
            {
                stats.High = Math.Max(studentInfo.Grade, stats.High);
                stats.Low = Math.Min(studentInfo.Grade, stats.Low);
                stats.Average += studentInfo.Grade;
                stats.Total += studentInfo.Grade;
            }

            stats.Average /= Grades.Count;
            return stats;
        }
    }
}
