//Factorial.cs : Program to find the factorial of a number using recursion.

using System;

namespace FactorialDemo
{
    class FactorialDemo
    {

        static long Factorial(int n)
        {
	        if(n==0)
		        return 1;

	        return (n * Factorial(n-1));
        }//End of Factorial()

        static void Main(string[] args)
        {
            int num=5;

            if (num < 0)
                Console.WriteLine("No factorial for negative number");
            else
                Console.WriteLine("Factorial of " + num + " = " + Factorial(num));

        }//End of Main()
    }//End of class FactorialDemo
}//End of namespace FactorialDemo
