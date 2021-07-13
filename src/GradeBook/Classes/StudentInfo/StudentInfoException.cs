using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Classes
{
    //Customer StudentInfo Exception classes
    public class StudentInfoNullException : Exception
    {
        //Construct base exception class with given parameters
        public StudentInfoNullException(string name, double grade, int numOfAttempts) : base($"Your student record is missing information | Name: {name} | Grade: {grade} | NumOfAttempts: {numOfAttempts} |")
        { }
    }

    public class StudentInfoMaxNumberException : Exception
    {
        //Construct base exception class with given parameters
        public StudentInfoMaxNumberException(string type) : base($"Your {type} value exceeds the maximum of 100 or is less than 0")
        { }
    }
}
