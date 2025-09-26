//TRFactorial.cs : Program to find the factorial of a number using tail recursion.

using System;

namespace TRFactorialDemo
{
    class TRFactorialDemo
    {
        static long TRFactorial(int n, int result)
        {
            if(n == 0)
                return result;

            return TRFactorial(n-1, n*result);
        }//End of TRFactorial()

        static long TRFactorial(int n)
        {
            return TRFactorial(n, 1);
        }//End of TRFactorial()

        static void Main(string[] args)
        {
		    int num = 5;

		    if(num < 0)
			    Console.WriteLine("No factorial for negative number");
		    else
                Console.WriteLine("Factorial of " + num + " = " + TRFactorial(num));
        }//End of Main()
    }//End of class TRFactorialDemo
}//End of namespace TRFactorialDemo
