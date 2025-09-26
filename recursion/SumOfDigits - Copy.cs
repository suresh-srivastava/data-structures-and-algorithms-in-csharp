//SumOfDigits.cs : Program to display digits of a number and sum of digits of that number.

using System;

namespace SumOfDigitsDemo
{
    class SumOfDigitsDemo
    {
        ////Displays digits of a number and finds the sum of digits of an integer
        //static long SumOfDigits(long n)
        //{
        //    long sum;

        //    if(n/10 == 0) //if n is a single digit number
        //    {
        //        Console.Write(n%10);
        //        return n;
        //    }

        //    sum = (n%10 + SumOfDigits(n/10));
        //    Console.Write(n%10);

        //    return sum;
        //}//End of SumOfDigits()

        //Finds the sum of digits of an integer
        static long SumOfDigits(long n)
        {
            if (n / 10 == 0) //if n is a single digit number
                return n;
            return n % 10 + SumOfDigits(n / 10);
        }//End of SumOfDigits()

        ////Displays the digits of an integer
        //static void Display(long n)
        //{
        //    if (n / 10 == 0)
        //    {
        //        Console.Write(n);
        //        return;
        //    }
        //    Console.Write(n % 10);
        //    Display(n / 10);
        //}//End of Display()

        //Displays the digits of an integer
        static void Display(long n)
        {
            if(n/10 == 0)
            {
                Console.Write(n);
                return;
            }
            Display(n/10);
            Console.Write(n%10);
        }//End of Display()

        static void Main(string[] args)
        {
            long num = 45329;

            Console.Write("Digits = ");
	        Display(num);
	        Console.WriteLine("\nSum of digits = " + SumOfDigits(num));

        }//End of Main()
    }//End of class SumOfDigitsDemo
}//End of namespace SumOfDigitsDemo

