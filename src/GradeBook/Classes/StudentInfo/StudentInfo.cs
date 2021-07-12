using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Classes
{
    public class StudentInfo
    {
        public string Name { get; set; }
        public double Grade { get; set; }
        public int NumOfAttempts { get; set; }

        public StudentInfo(string name, double grade, int numOfAttempts)
        {
            if (name == null || grade == 0 || numOfAttempts == 0)
                throw new StudentInfoNullException(name, grade, numOfAttempts);

            if (grade > 100)
                throw new StudentInfoMaxNumberException("Grade");
            else if (numOfAttempts > 100)
                throw new StudentInfoMaxNumberException("NumOfAttempts");

            Name = name;
            Grade = grade;
            NumOfAttempts = numOfAttempts;
        }
    }
}
