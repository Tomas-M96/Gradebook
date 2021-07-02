using System;
using Xunit;
using GradeBook;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void TypesTests_StringBehaveLikeValueType()   
        {
            string name = "Tomas";
            string uppercaseName = MakeUpperCase(name);

            Assert.Equal("TOMAS", uppercaseName);
        }


        [Fact]
        public void TypesTests_ValueTypePassByValue()
        {
            //Arrange
            var x = GetInt();
            SetInt(x);
            var y = GetInt();
            SetInt(ref y);

            //Assert
            Assert.Equal(3, x);
            Assert.Equal(42, y);
        }

        [Fact]
        public void TypesTests_SetNamePassByReference()
        {
            

            //Arrange
            Book bookOne = GetBook("bookOne");
            GetBookSetName(ref bookOne, "New Name");

            //Assert
            //This will be asserted as bookOne as GetBookSetName is only changing the value of the copied variable - not the book object itself 
            //So bookOne will still be pointing at the same book - but book in GetBookSetName will have the value of a new book object
            Assert.Equal("New Name", bookOne.Name);
        }

        [Fact]
        public void TypesTests_SetNamePassByValue()
        {
            //Arrange
            Book bookOne = GetBook("bookOne");
            GetBookSetName(bookOne, "New Name");

            //Assert
            //This will be asserted as bookOne as GetBookSetName is only changing the value of the copied variable - not the book object itself 
            //So bookOne will still be pointing at the same book - but book in GetBookSetName will have the value of a new book object
            Assert.Equal("bookOne", bookOne.Name);
        }

        [Fact]
        public void TypesTests_SetNameFromReference()
        {
            //Arrange
            Book bookOne = GetBook("bookOne");
            SetName(bookOne, "New Name");

            //Assert
            Assert.Equal("New Name", bookOne.Name);
        }

        [Fact]
        public void TypeTests_GetBookReturnDifferentObjects()
        {
            //Arrange
            Book bookOne = GetBook("BookOne");
            Book bookTwo = GetBook("BookTwo");

            //Assert
            Assert.Equal("BookOne", bookOne.Name);
            Assert.Equal("BookTwo", bookTwo.Name);
            //NotSame can be used to assert that object the two variables reference are not the same
            Assert.NotSame(bookOne, bookTwo);
            Assert.False(Object.ReferenceEquals(bookOne, bookTwo));
        }

        [Fact]
        public void TypeTests_GetBookReturnSameObject()
        {
            //Arrange
            Book bookOne = GetBook("BookOne");
            Book bookTwo = bookOne;

            //Assert
            Assert.Equal("BookOne", bookOne.Name);
            Assert.Equal("BookOne", bookTwo.Name);
            //Same can be used to assert that the object the two variables reference are the same
            Assert.Same(bookOne, bookTwo);
            //Object.ReferenceEquals uses the base class to see if both variables contain the same reference
            Assert.True(Object.ReferenceEquals(bookOne, bookTwo));
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        private int GetInt()
        {
            return 3;
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }


        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }
    }
}
