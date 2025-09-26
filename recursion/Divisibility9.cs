//Divisibility9.cs : Program to find a number is divisible from 9 or not.
//A number is divisible by 9 if and only if the sum of digits of the number is divisible by 9.

using System;

namespace Divisibility9Demo
{
    class Divisibility9Demo
    {
        static bool IsDivisibleBy9(long n)
        {
            int sumOfDigits = 0;

            if (n == 9)
                return true;

            if (n < 9)
                return false;

            while (n > 0)
            {
                sumOfDigits += (int)n%10;
                n /= 10;
            }

            return IsDivisibleBy9(sumOfDigits);

        }//End of IsDivisibleBy9()

        static void Main(string[] args)
        {
		    long num = 1469358;

		    Console.WriteLine(num + " is divisible by 9 : " + (IsDivisibleBy9(num) ? "True" : "False"));

        }//End of Main()
    }//End of class Divisibility9Demo
}//End of namespace Divisibility9Demo
