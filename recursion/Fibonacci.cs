//Fibonacci.cs : Program to generate fibonacci series.

using System;

namespace FibonacciDemo
{
    class FibonacciDemo
    {
        static int Fib(int n)
        {
            if(n==0 || n==1)
                return 1;

            return (Fib(n-1) + Fib(n-2));
        }//End of Fib()

        static void Main(string[] args)
        {
		    int nterms=10;

		    for(int i=0; i < nterms ; i++)
			    Console.Write(Fib(i) + " ");

		    Console.WriteLine();

        }//End of Main()
    }//End of class FibonacciDemo
}//End of namespace FibonacciDemo
