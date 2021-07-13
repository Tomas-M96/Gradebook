using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Classes;

namespace GradeBook.Interfaces
{
    //Interface for IBook
    public interface IBook
    {
        List<StudentInfo> Grades { get; set; }
        void AddGrade(StudentInfo studentInfo);
        Statistics CalculateStatistics();
        string Name { get; }
    }
}
