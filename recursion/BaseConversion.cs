//BaseConversion.cs : Program to convert a positive decimal number to Binary, Octal or Hexadecimal

using System;

namespace BaseConversionDemo
{
	class BaseConversionDemo
	{
		static void ConvertBase(int num, int b)
		{
			int rem = num%b;

			if(num == 0)
				return;

			ConvertBase(num/b, b);

			if(rem < 10)
				Console.Write(rem);
			else
				Console.Write(Convert.ToChar(rem-10+'A'));
		}//End of ConvertBase()

		static void Main(string[] args)
		{
			int num = 15;

			Console.Write("Binary : ");		    ConvertBase(num, 2);	Console.WriteLine();
			Console.Write("Octal : ");	        ConvertBase(num, 8);	Console.WriteLine();
			Console.Write("Hexadecimal : ");    ConvertBase(num, 16);   Console.WriteLine();

		}//End of Main()
	}//End of class BaseConversionDemo
}//End of namespace BaseConversionDemo
