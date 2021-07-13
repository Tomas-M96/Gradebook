using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Classes
{
    //StudentInfo class
    public class StudentInfo
    {
        public string Name { get; set; }
        public double Grade { get; set; }
        public int NumOfAttempts { get; set; }

        public StudentInfo(string name, double grade, int numOfAttempts)
        {
            //If any of the parameters are empty then throw a null exception
            if (name == null || grade == 0 || numOfAttempts == 0)

                //Custom StudentInfo Null Exception
                throw new StudentInfoNullException(name, grade, numOfAttempts);

            //If the grade is out of bounds throw an exception
            if (grade > 100)
                //Custom StudentInfo Max Number Exception
                throw new StudentInfoMaxNumberException("Grade");
            
            //If the numOfAttempts is out of bounds throw an exception
            if (numOfAttempts > 100)
                throw new StudentInfoMaxNumberException("NumOfAttempts");

            //Assign the parameters if no exceptions are thrown
            Name = name;
            Grade = grade;
            NumOfAttempts = numOfAttempts;
        }
    }
}
