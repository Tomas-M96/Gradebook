using System;
using Xunit;
using GradeBook;
using GradeBook.Classes;

namespace GradeBook.Tests
{ 
    //Tests to demonstrate delegates and reference vs value types
    public class DelegateTests
    {
        public delegate string WriteLogDelegate(string message);

        int count = 0;

        [Fact]
        public void DelegateTests_WriteLogDelegateMultiCast()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementMessage;

            var result = log("Hello");

            Assert.Equal(3, count);
            Assert.Equal("HELLO", result);
        }

        [Fact]
        public void DelegateTests_WriteLogDelegateToConsole()
        {
            WriteLogDelegate log;

            //You can assign a delegate the long way like this
            log = new WriteLogDelegate(ReturnMessage);

            //Or use this shorthand - the CLR will do the rest
            log = ReturnMessage;

            var result = log("Hello from the delegate");

            Assert.Equal("Hello from the delegate", result);
        }

        private string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        private string IncrementMessage(string message)
        {
            count++;
            return message.ToUpper();
        }
    }
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
            return new MemoryBook(name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new MemoryBook(name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new MemoryBook(name);
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
