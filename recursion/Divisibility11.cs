//Divisibility11.cs : Program to find a number is divisible from 11 or not.
//A number is divisible by 11 if and only if the difference of the sums of digits at odd positions and even positions 
//is either zero or divisible by 11.

using System;

namespace Divisibility11Demo
{
    class Divisibility11Demo
    {
        static bool IsDivisibleBy11(long n)
        {
            int s1=0, s2=0, diff;

            if (n == 0)
                return true;

            if (n < 10)
                return false;

            while (n > 0)
            {
                s1 += (int)n%10;
                n /= 10;

                s2 += (int)n%10;
                n /= 10;
            }

            diff = s1>s2 ? (s1-s2) : (s2-s1);

            return IsDivisibleBy11(diff);
        }//End of IsDivisibleBy11()

        static void Main(string[] args)
        {
		    long num = 62938194;

		    Console.WriteLine(num + " is divisible by 11 : " + (IsDivisibleBy11(num) ? "True" : "False"));

        }//End of Main()
    }//End of class Divisibility11Demo
}//End of namespace Divisibility11Demo
