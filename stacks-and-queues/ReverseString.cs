//ReverseString.cs : Program of reversing a string using stack.

using System;
using System.Collections.Generic;

namespace ReverseStringDemo
{
    class ReverseStringDemo
    {
        static String ReverseString(String str)
        {
            String temp = "";
            Stack<char> st = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
                st.Push(str[i]);

            while(st.Count != 0)
                temp += st.Pop();

            return temp;
        }//End of ReverseString()

        static void Main(string[] args)
        {
		    String str = "algorithms";
		    Console.WriteLine("String is : " + str);

            Console.WriteLine("Reversed string is : " + ReverseString(str));
        }//End of Main()
    }//End of class ReverseStringDemo
}//End of namespace ReverseStringDemo
