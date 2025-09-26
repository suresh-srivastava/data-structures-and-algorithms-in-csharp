//PrimeFactors.cs : Program to find the prime factors of a number.

using System;

namespace PrimeFactorsDemo
{
    class PrimeFactorsDemo
    {
	    static void PrimeFactors(int num)
	    {
		    int i=2;

		    if(num == 1)
			    return;

		    while(num%i != 0)
			    i++;

		    Console.Write(i + " ");
		    PrimeFactors(num/i);
	    }//End of PrimeFactors()

        static void Main(string[] args)
        {
		    int num=84;

		    Console.WriteLine("Prime factors of " + num + " :");
		    PrimeFactors(num);
		    Console.WriteLine();

        }//End of Main()
    }//End of class PrimeFactorsDemo
}//End of namespace PrimeFactorsDemo
