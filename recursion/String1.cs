//String1.cs : Program to find the length of a string.

using System;

namespace String1Demo
{
    class String1Demo
    {
        static int Length(char[] str, int index)
        {
            if (str[index] == '\0')
                return 0;

            return (1 + Length(str, index + 1));
        }//End of Length()

        static void Main(string[] args)
        {
		    char[] stringArr = {'S','u','r','e','s','h','\0'};

		    Console.WriteLine("String is : " + new String(stringArr));
            Console.WriteLine("Length : " + Length(stringArr, 0));
        }//End of Main()
    }//End of class String1Demo
}//ENd of namespace String1Demo
