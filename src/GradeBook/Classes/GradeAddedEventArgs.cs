using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.Classes
{
    //Custom EventArgs type for the GradeAddedEvent
    //Inherits from the base class EventArgs
    public class GradeAddedEventArgs : EventArgs
    {
        public string Name { get; set; }
        public double Grade { get; set; }
        public int NumOfAttempts { get; set; }

        public GradeAddedEventArgs(StudentInfo studentInfo)
        {
            Name = studentInfo.Name;
            Grade = studentInfo.Grade;
            NumOfAttempts = studentInfo.NumOfAttempts;
        }
    }
}
