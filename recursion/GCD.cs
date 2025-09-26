//GCD.cs : Program to find greatest common divisor of two numbers.

using System;

namespace GCDDemo
{
    class GCDDemo
    {
        static int GCD(int a, int b)
        {
            if(b == 0)
                return a;

            return GCD(b, a%b);
        }//End of GCD()

        static void Main(string[] args)
        {
		    int num1=35, num2=21;

		    Console.WriteLine("GCD = " + GCD(num1, num2));

        }//End of Main()
    }//End of class GCD
}//End of namespace GCD
