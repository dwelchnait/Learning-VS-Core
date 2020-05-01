//import other libraries required for program
//these are namespaces
using System;

//used to group and organize code
namespace Branching
{
    class Program
    {
        //entry point into your program

        static void Main(string[] args)
        {
            int a = 5;
            int b = 6;

            //interesting doing a relative test outside of if
            //bool result = a + b > 10;
            //if (result)
            if (a + b > 10)
            {
                Console.WriteLine("Athis answer is greater than 10.");
            }
            else
            {
                Console.WriteLine("Athis answer is not greater than 10.");
            }
        }
    }
}
