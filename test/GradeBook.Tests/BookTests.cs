using System;
using Xunit;
using GradeBook;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookTests_AddGrade()
        {
            Book book = new Book("Grades");
            book.AddGrade(101);

            //Assert.DoesNotContain(book, book.);
        }
        
        [Fact] //Attribute 
        public void BookTests_CalculateBookStats()
        {
            //Arrange Section - Arrange your data
            Book book = new Book("Grades");
            book.AddGrade(90);
            book.AddGrade(80.1);
            book.AddGrade(12);

            //Act Section - Invoke a method to perform a computation to get the actual result
            Statistics result = book.CalculateStats();

            //Assert Section - Assert the actual result with expected result
            //Check to 1 decimal place
            Assert.Equal(60.7, result.Average, 1);
            Assert.Equal(90, result.High);
            Assert.Equal(12, result.Low);
            Assert.Equal(182.1, result.Total, 1);
            Assert.Equal('D', result.Letter);
        }
    }
}
