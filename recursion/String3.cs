//String3.cs : Program to display the string in reverse order.

using System;

namespace String3Demo
{
    class String3Demo
    {
        static void Rdisplay(char[] str, int index)
	    {
		    if(str[index] == '\0')
			    return;

		    Rdisplay(str, index+1);
		    Console.Write(str[index]);
	    }//End of Rdisplay()	

        static void Main(string[] args)
        {
		    char[] stringArr = {'S','u','r','e','s','h','\0'};

		    Console.Write("String is : ");
		    Rdisplay(stringArr, 0);
            Console.WriteLine();
        }//End of Main()
    }//End of class String3Demo
}//End of namespace String3Demo
