//Display.cs : Program to display numbers 1 to n and n to 1

using System;

namespace DisplayDemo
{
    class DisplayDemo
    {
        static void Display1(int n)
        {
            if(n == 0)
                return;

            Console.WriteLine(n);
            Display1(n-1);
        }//End of Display1()

        static void Display2(int n)
        {
            if(n == 0)
                return;

            Display2(n-1);
            Console.WriteLine(n);
        }//End of Display2()

        static void Main(string[] args)
        {
            int num = 5;

            Console.WriteLine(num + " to 1 :");
            Display1(num);

		    Console.WriteLine("1 to " + num + " :");
		    Display2(num);

        }//End of Main()
    }//End of class DisplayDemo
}//End of namespace DisplayDemo

