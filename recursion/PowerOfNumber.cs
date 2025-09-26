//PowerOfNumber.cs : Program to find the exponentiation of a number (a power n, example 2 power 3 = 8).

using System;

namespace PowerOfNumberDemo
{
    class PowerOfNumberDemo
    {
        static long Power(int a, int n)
        {
            if (n == 0)
                return 1;

            return (a * Power(a, n - 1));
        }//End of Power()

        static void Main(string[] args)
        {
		    int a=2, n=4;

		    Console.WriteLine(a + " power " + n + " = " + Power(a, n));

        }//End of Main()
    }//End of class PowerOfNumberDemo
}//End of namespace PowerOfNumberDemo
