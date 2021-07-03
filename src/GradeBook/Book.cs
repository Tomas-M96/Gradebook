using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private string name;

        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public event GradeAddedDelegate GradeAddedEvent;

        public string Name
        {
            get 
            {
                return name;
            }
            set 
            {
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

        public Book(string _name)
        {
            grades = new List<double>();
            name = _name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                case 'a':
                    grades.Add(90);
                    break;
                case 'B':
                case 'b':
                    grades.Add(80);
                    break;
                case 'C':
                case 'c':
                    grades.Add(70);
                    break;
                case 'D':
                case 'd':
                    grades.Add(60);
                    break;
                default:
                    break;
            }
        }

        public void AddGrade(double _grade)
        {
            if (_grade <= 100 && _grade >= 0)
            {
                grades.Add(_grade);
                if (GradeAddedEvent != null)
                {
                    GradeAddedEvent(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(_grade)}");
            }
        }

        public void DisplayStats()
        {
            Statistics stats = CalculateStats();
            Console.WriteLine($"Hello!");
            Console.WriteLine($"The average result is {stats.Average}, and the total of all is {stats.Total}");
            Console.WriteLine($"The highest grade is {stats.High}, and the lowest grade is {stats.Low}");
        }

        public Statistics CalculateStats()
        {
            Statistics stats = new Statistics();
            stats.High = double.MinValue;
            stats.Low = double.MaxValue;

            int index = 0;


            //FOR LOOP
            for (int i = 0; i < grades.Count; i++)
            {
                stats.High = Math.Max(grades[i], stats.High);
                stats.Low = Math.Min(grades[i], stats.Low);
                stats.Average += grades[i];
                stats.Total += grades[i];
            }

            //WHILE LOOP
            /*
            while (index < grades.Count)
            {
                stats.High = Math.Max(grades[index], stats.High);
                stats.Low = Math.Min(grades[index], stats.Low);
                stats.Average += grades[index];
                stats.Total += grades[index];
                index++;
            }
            */


            //DO WHILE LOOP
            /*
            if (grades.Count != 0)
            {
                do
                {
                    stats.High = Math.Max(grades[index], stats.High);
                    stats.Low = Math.Min(grades[index], stats.Low);
                    stats.Average += grades[index];
                    stats.Total += grades[index];
                    index++;
                } while (index < grades.Count);
            }
            */

            //FOREACH LOOP 
            /*
            foreach(double grade in grades)
            {
                stats.High = Math.Max(grade, stats.High);
                stats.Low = Math.Min(grade, stats.Low);
                stats.Average += grade;
                stats.Total += grade;
            } 
            */

            stats.Average /= grades.Count;

            switch (stats.Average)
            {
                case var d when d >= 90.0:
                    stats.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    stats.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    stats.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    stats.Letter = 'D';
                    break;
                default:
                    stats.Letter = 'F';
                    break;
            }

            return stats;
        }
    }
}