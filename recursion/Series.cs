//Series.cs : Program to display and find out the sum of series.
//Series : 1 + 2 + 3 + 4 + 5 +.......

using System;

namespace SeriesDemo
{
    class SeriesDemo
    {
        static int Rseries(int n)
        {
            int sum;
            if (n == 0)
                return 0;
            sum = (n + Rseries(n - 1));
            Console.Write(n + " + ");
            return sum;
        }//End of Rseries()

        static void Main(string[] args)
        {
            int num = 5;

            Console.WriteLine("\b\b= " + Rseries(num)); //\b to erase last + sign
        }//End of Main()
    }//End of class SeriesDemo
}//End of namespace SeriesDemo


