using System;

namespace SrackDemo.Specs
{
    internal class Stack
    {
        private int _LogicalSize = 0;
        private int[] _Element;
        private int _MaxSize = 0;
        public bool IsEmpty => _LogicalSize == 0;

        public bool IsFull => _LogicalSize == 2;

        public Stack(int maxsize)
        {
            _MaxSize = maxsize;
            _Element = new int[_MaxSize];
        }
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