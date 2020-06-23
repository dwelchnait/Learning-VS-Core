using System;

namespace SrackDemo.Specs
{
    internal class Stack
    {
        private int _LogicalSize = 0;
        private int[] _Element =new int[2];
        public bool IsEmpty => _LogicalSize == 0;

        public bool IsFull => _LogicalSize == 2;

        internal void Push(int number)
        {
            if (IsFull)
                throw new SrackDemo.Specs.OverflowException();
            _Element[_LogicalSize] = number;
            _LogicalSize++;
        }

        internal int Pop()
        {
            if (IsEmpty)
                throw new UnderflowException();
            int number = _Element[_LogicalSize - 1];
            _LogicalSize--;
            return number;
        }
    }
}