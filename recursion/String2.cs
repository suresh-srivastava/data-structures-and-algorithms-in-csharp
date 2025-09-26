//String2.cs : Program to display the string.

using System;

namespace String2Demo
{
    class String2
    {
        static void Display(char[] str, int index)
	    {
		    if(str[index] == '\0')
			    return;

		    Console.Write(str[index]);

		    Display(str, index+1);
	    }//End of display()

        static void Main(string[] args)
        {
		    char[] stringArr = {'S','u','r','e','s','h','\0'};

		    Console.Write("String is : ");
		    Display(stringArr, 0);
            Console.WriteLine();
        }//End of Main()
    }//End of class String2Demo
}//End of namespace String2Demo
