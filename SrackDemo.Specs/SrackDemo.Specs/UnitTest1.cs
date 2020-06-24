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
        Stack myStack;

        public void Create_Stack()
        {
            myStack = new Stack(2);
        }
        //what happens if you want to set the stack's upperLimit
        //   when you create the stack

        [Theory]
        [InlineData(9)]
        [InlineData(7)]
        [InlineData(2)]
        public void Can_Specify_Stack_Size_On_Create_Stack(int expected)
        {
            myStack = new Stack(expected);
            for(int i = 0; i< expected; i++)
            {
                myStack.Push(i);
            }
            Assert.True(myStack.IsFull);
        }

        [Fact]
        public void Stack_Is_Empty()
        {
            Create_Stack();

            //Stack myStack = new Stack(); //refactored
            Assert.True(myStack.IsEmpty);
        }
        [Fact]
        public void Stack_Is_Not_Empty()
        {
            //Arrange - setup whatever is needed
            //Stack myStack = new Stack(); //refactored
            Create_Stack();

            //Action - work that you do on the SUT (subject under test)
            myStack.Push(0);

            //Assert - Prove that it works
            Assert.False(myStack.IsEmpty);
        }

        [Fact]
        public void Will_Throw_Underflow_When_Empty_Stack_Is_Popped()
        {
            Create_Stack();
            Assert.Throws<UnderflowException>(()=> myStack.Pop());
        }

        [Fact]
        public void After_One_Push_And_One_Pop_Stack_Will_Be_Empty()
        {
            Create_Stack();
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
            Create_Stack();
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
            Create_Stack();
            myStack.Push(expected);
            int actual = myStack.Pop();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void After_Pushing_X_Then_Y_Will_Pop_Y_Then_X()
        {
            Create_Stack();
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
            Create_Stack();
            myStack.Push(9);
            myStack.Push(7);
            Assert.True(myStack.IsFull);
        }
        
        //what happens if you push when the stack is full
        [Fact]
        public void Will_Throw_Overflow_When_Full_Stack_Is_Pushed()
        {
            Create_Stack();
            myStack.Push(9);
            myStack.Push(7);
            Assert.Throws<OverflowException>(() => myStack.Push(8));
        }

        

    }

    
}
