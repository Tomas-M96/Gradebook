using System;
using Xunit;
using GradeBook;
using GradeBook.Classes;
using GradeBook.Interfaces;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookTests_AddRecordFileBook()
        {
            //Arrange
            IBook book = new FileBook("Grades");
            StudentInfo studentInfo = new StudentInfo("John", 100, 1);

            //Act
            book.AddGrade(studentInfo);

            //Assert
            Assert.Contains(studentInfo, book.Grades);
        }

        [Fact]
        public void BookTests_AddRecordMemoryBook()
        {
            //Arrange
            IBook book = new MemoryBook("Grades");
            StudentInfo studentInfo = new StudentInfo("John", 100, 1);

            //Act
            book.AddGrade(studentInfo);

            //Assert
            Assert.Contains(studentInfo, book.Grades);
        }
        
        [Fact] //Attribute 
        public void BookTests_CalculateMemoryBookStats()
        {
            //Arrange Section - Arrange your data
            IBook book = new MemoryBook("Grades");

            StudentInfo[] students = new StudentInfo[] { 
                                                        new StudentInfo("John", 100, 1), 
                                                        new StudentInfo("Dave", 50, 1), 
                                                        new StudentInfo("Howard", 50, 1) 
                                                       };


            for (int i = 0; i < students.Length; i++)
                book.AddGrade(students[i]);

            //Act Section - Invoke a method to perform a computation to get the actual result
            Statistics result = book.CalculateStatistics();

            //Assert Section - Assert the actual result with expected result
            //Check to 1 decimal place
            Assert.Equal(66.7, result.Average, 1);
            Assert.Equal(100, result.High);
            Assert.Equal(50, result.Low);
            Assert.Equal(200, result.Total, 1);
        }
    }
}
