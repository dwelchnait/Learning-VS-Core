//using System;
//using System.Collections; why, contains a Stack class itself
using Xunit;

namespace SrackDemo.Specs
{
    public class Simple_Stack_Specs
    {
        //refactoring code results in recongizing that the
        // creation of myStack is common, so to reduce code
        // we can move the instanation of the instance out
        // out the tests and place it as a class data member
        Stack myStack = new Stack();

        [Fact]
        public void Stack_Is_Empty()
        {
            //Stack myStack = new Stack(); //refactored
            Assert.True(myStack.IsEmpty);
        }
        [Fact]
        public void Stack_Is_Not_Empty()
        {
            //Arrange - setup whatever is needed
            //Stack myStack = new Stack(); //refactored

            //Action - work that you do on the SUT (subject under test)
            myStack.Push(0);

            //Assert - Prove that it works
            Assert.False(myStack.IsEmpty);
        }

        [Fact]
        public void Will_Throw_Underflow_When_Empty_Stack_Is_Popped()
        {
            Assert.Throws<UnderflowException>(()=> myStack.Pop());
        }

        [Fact]
        public void After_One_Push_And_One_Pop_Stack_Will_Be_Empty()
        {
            myStack.Push(0);
            myStack.Pop();
            Assert.True(myStack.IsEmpty);
        }
    
        //Remember: Each test I write should force me to make a better
        //   solution
        //Rule: Everything I do to the tests makes the tests more
        //      specific. Everything I do to the production code 
        //      makes it more general.

        [Fact]
        public void After_Two_Pushes_And_One_Pop_Stack_Will_Not_Be_Emtpy()
        {
            myStack.Push(0);
            myStack.Push(7);
            myStack.Pop();
            Assert.False(myStack.IsEmpty);
        }

        [Theory]
        [InlineData(9)]
        [InlineData(7)]
        public void After_Pushing_X_Will_Pop_X(int expected)
        {
            myStack.Push(expected);
            int actual = myStack.Pop();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void After_Pushing_X_Then_Y_Will_Pop_Y_Then_X()
        {
            myStack.Push(9);
            myStack.Push(7);
            int actual = myStack.Pop();
            Assert.Equal(7, actual);
            actual = myStack.Pop();
            Assert.Equal(9, actual);
        }

        //Can you tell when the stack is full
        [Fact]
        public void Stack_Is_Full()
        {
            myStack.Push(9);
            myStack.Push(7);
            Assert.True(myStack.IsFull);
        }
        
        //what happens if you push when the stack is full
        [Fact]
        public void Will_Throw_Overflow_When_Full_Stack_Is_Pushed()
        {
            myStack.Push(9);
            myStack.Push(7);
            Assert.Throws<OverflowException>(() => myStack.Push(8));
        }
        
        //what happens if you want to set the stack's upperLimit
        //   when you create the stack


    }

    
}
