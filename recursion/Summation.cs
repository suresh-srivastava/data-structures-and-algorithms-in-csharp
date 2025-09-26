//Summation.cs : Program to find summation of numbers from 1 to n

using System;

namespace SummationDemo
{
    class SummationDemo
    {
        static int Summation(int n)
        {
            if(n == 0)
                return 0;

            return (n + Summation(n-1));
        }//End of Summation()

        static void Main(string[] args)
        {
		    int num = 5;

            Console.WriteLine("Summation(" + num + ") = " + Summation(num));
        }//End of Main()
    }//End of class SummationDemo
}//End of namespace SummationDemo
